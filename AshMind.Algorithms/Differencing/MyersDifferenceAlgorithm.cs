/* 
    API rewritten, underlying algorithm taken as is from 
    http://www.codeproject.com/KB/recipes/DiffAlgorithmCS.aspx
    by Matthias Hertel (http://www.mathertel.de/), 2006
  
    It seems right now there is a newer algorithm at http://www.mathertel.de/Diff/ViewSrc.aspx,
    I will probably update this one when I have time. It works extremely well as is, however.

    Originally released under Creative Commons Attribution 2.0 Germany License (on Code Project).  
    Creative Commons Attribution does not require derivative works to be under the same license.
 
    So re-licensing under BSD:
  
    Copyright (c) 2006, Matthias Hertel
    Copyright (c) 2009, Andrey Shchekin
    All rights reserved.
  
    Redistribution and use in source and binary forms, with or without
    modification, are permitted provided that the following conditions are met:
        * Redistributions of source code must retain the above copyright
          notice, this list of conditions and the following disclaimer.
        * Redistributions in binary form must reproduce the above copyright
          notice, this list of conditions and the following disclaimer in the
          documentation and/or other materials provided with the distribution.
        * Neither the name of the <organization> nor the
          names of its contributors may be used to endorse or promote products
          derived from this software without specific prior written permission.

    THIS SOFTWARE IS PROVIDED BY AUTHOR ''AS IS'' AND ANY
    EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
    WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
    DISCLAIMED. IN NO EVENT SHALL AUTHOR BE LIABLE FOR ANY
    DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
    (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
    LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
    ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
    (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
    SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Algorithms.Differencing {
    public class MyersDifferenceAlgorithm<T> : IDifferenceAlgorithm<T> {
        /// <summary>Data on one input file being compared.  
        /// </summary>
        private class DifferenceData {
            /// <summary>Number of elements (lines).</summary>
            public int Length {
                get { return this.Data.Length; }
            }
            public T[] Data { get; private set; }

            /// <summary>
            /// Array of booleans that flag for modified data.
            /// This is the result of the diff.
            /// This means deletedA in the first Data or inserted in the second Data.
            /// </summary>
            public bool[] Changed { get; private set; }

            /// <summary>
            /// Initialize the Diff-Data buffer.
            /// </summary>
            /// <param name="data">reference to the buffer</param>
            public DifferenceData(IEnumerable<T> data) {
                this.Data = data.ToArray();
                this.Changed = new bool[Length + 2];
            }
        }

        /// <summary>
        /// Shortest Middle Snake Return Data
        /// </summary>
        private struct Smsrd {
            public int X { get; set; }
            public int Y { get; set; }
        }

        private readonly IEqualityComparer<T> comparer;

        public MyersDifferenceAlgorithm() : this(EqualityComparer<T>.Default) {
        }

        public MyersDifferenceAlgorithm(IEqualityComparer<T> comparer) {
            this.comparer = comparer;
        }

        public IEnumerable<Difference> GetDifferences(IEnumerable<T> first, IEnumerable<T> second) {
            // The A-Version of the data (original data) to be compared.
            var dataA = new DifferenceData(first);

            // The B-Version of the data (modified data) to be compared.
            var dataB = new DifferenceData(second);

            var max = dataA.Length + dataB.Length + 1;
            /// vector for the (0,0) to (x,y) search
            var downVector = new int[2 * max + 2];
            /// vector for the (u,v) to (N,M) search
            var upVector = new int[2 * max + 2];

            LCS(dataA, 0, dataA.Length, dataB, 0, dataB.Length, downVector, upVector);

            Optimize(dataA);
            Optimize(dataB);
            return CreateDiffs(dataA, dataB);
        }


        /// <summary>
        /// If a sequence of modified lines starts with a line that contains the same content
        /// as the line that appends the changes, the difference sequence is modified so that the
        /// appended line and not the starting line is marked as modified.
        /// This leads to more readable diff sequences when comparing text files.
        /// </summary>
        /// <param name="data">A Diff data buffer containing the identified changes.</param>
        private void Optimize(DifferenceData data) {
            var startPos = 0;

            while (startPos < data.Length) {
                while ((startPos < data.Length) && !data.Changed[startPos])
                    startPos++;

                var endPos = startPos;
                while ((endPos < data.Length) && data.Changed[endPos])
                    endPos++;

                if ((endPos < data.Length) && comparer.Equals(data.Data[startPos], data.Data[endPos])) {
                    data.Changed[startPos] = false;
                    data.Changed[endPos] = true;
                }
                else {
                    startPos = endPos;
                }
            }
        }

        /// <summary>
        /// This is the algorithm to find the Shortest Middle Snake (SMS).
        /// </summary>
        /// <param name="dataA">sequence A</param>
        /// <param name="lowerA">lower bound of the actual range in dataA</param>
        /// <param name="upperA">upper bound of the actual range in dataA (exclusive)</param>
        /// <param name="dataB">sequence B</param>
        /// <param name="lowerB">lower bound of the actual range in dataB</param>
        /// <param name="upperB">upper bound of the actual range in dataB (exclusive)</param>
        /// <param name="downVector">a vector for the (0,0) to (x,y) search. Passed as a parameter for speed reasons.</param>
        /// <param name="upVector">a vector for the (u,v) to (N,M) search. Passed as a parameter for speed reasons.</param>
        /// <returns>a MiddleSnakeData record containing x,y and u,v</returns>
        private Smsrd SMS(
            DifferenceData dataA, int lowerA, int upperA,
            DifferenceData dataB, int lowerB, int upperB,
            int[] downVector, int[] upVector
            ) {
            var max = dataA.Length + dataB.Length + 1;

            var downK = lowerA - lowerB; // the k-line to start the forward search
            var upK = upperA - upperB; // the k-line to start the reverse search

            var delta = (upperA - lowerA) - (upperB - lowerB);
            var oddDelta = (delta & 1) != 0;

            // The vectors in the publication accepts negative indexes. the vectors implemented here are 0-based
            // and are access using a specific offset: UpOffset upVector and DownOffset for DownVektor
            var downOffset = max - downK;
            var upOffset = max - upK;

            var maxD = ((upperA - lowerA + upperB - lowerB) / 2) + 1;

            // init vectors
            downVector[downOffset + downK + 1] = lowerA;
            upVector[upOffset + upK - 1] = upperA;

            for (var d = 0; d <= maxD; d++) {
                // Extend the forward path.
                for (var k = downK - d; k <= downK + d; k += 2) {
                    // Debug.Write(0, "SMS", "extend forward path " + k.ToString());

                    // find the only or better starting point
                    int x;
                    if (k == downK - d) {
                        x = downVector[downOffset + k + 1]; // down
                    }
                    else {
                        x = downVector[downOffset + k - 1] + 1; // a step to the right
                        if ((k < downK + d) && (downVector[downOffset + k + 1] >= x))
                            x = downVector[downOffset + k + 1]; // down
                    }
                    var y = x - k;

                    // find the end of the furthest reaching forward D-path in diagonal k.
                    while ((x < upperA) && (y < upperB) && comparer.Equals(dataA.Data[x], dataB.Data[y])) {
                        x++; y++;
                    }
                    downVector[downOffset + k] = x;

                    // overlap ?
                    if (oddDelta && (upK - d < k) && (k < upK + d)) {
                        if (upVector[upOffset + k] <= downVector[downOffset + k]) {
                            return new Smsrd {
                                X = downVector[downOffset + k],
                                Y = downVector[downOffset + k] - k
                            };
                        }
                    }

                }

                // Extend the reverse path.
                for (var k = upK - d; k <= upK + d; k += 2) {
                    // Debug.Write(0, "SMS", "extend reverse path " + k.ToString());

                    // find the only or better starting point
                    int x;
                    if (k == upK + d) {
                        x = upVector[upOffset + k - 1]; // up
                    }
                    else {
                        x = upVector[upOffset + k + 1] - 1; // left
                        if ((k > upK - d) && (upVector[upOffset + k - 1] < x))
                            x = upVector[upOffset + k - 1]; // up
                    }
                    var y = x - k;

                    while ((x > lowerA) && (y > lowerB) && comparer.Equals(dataA.Data[x - 1], dataB.Data[y - 1])) {
                        x--; y--; // diagonal
                    }
                    upVector[upOffset + k] = x;

                    // overlap ?
                    if (!oddDelta && (downK - d <= k) && (k <= downK + d)) {
                        if (upVector[upOffset + k] <= downVector[downOffset + k]) {
                            return new Smsrd {
                                X = downVector[downOffset + k],
                                Y = downVector[downOffset + k] - k
                            };
                        }
                    }
                }
            }

            throw new ApplicationException("the algorithm should never come here.");
        } // SMS


        /// <summary>
        /// This is the divide-and-conquer implementation of the longes common-subsequence (LCS) 
        /// algorithm.
        /// The published algorithm passes recursively parts of the A and B sequences.
        /// To avoid copying these arrays the lower and upper bounds are passed while the sequences stay constant.
        /// </summary>
        /// <param name="dataA">sequence A</param>
        /// <param name="lowerA">lower bound of the actual range in dataA</param>
        /// <param name="upperA">upper bound of the actual range in dataA (exclusive)</param>
        /// <param name="dataB">sequence B</param>
        /// <param name="lowerB">lower bound of the actual range in dataB</param>
        /// <param name="upperB">upper bound of the actual range in dataB (exclusive)</param>
        /// <param name="downVector">a vector for the (0,0) to (x,y) search. Passed as a parameter for speed reasons.</param>
        /// <param name="upVector">a vector for the (u,v) to (N,M) search. Passed as a parameter for speed reasons.</param>
        private void LCS(
            DifferenceData dataA, int lowerA, int upperA,
            DifferenceData dataB, int lowerB, int upperB,
            int[] downVector, int[] upVector
            ) {
            // Fast walkthrough equal lines at the start
            while (lowerA < upperA && lowerB < upperB && comparer.Equals(dataA.Data[lowerA], dataB.Data[lowerB])) {
                lowerA++; lowerB++;
            }

            // Fast walkthrough equal lines at the end
            while (lowerA < upperA && lowerB < upperB && comparer.Equals(dataA.Data[upperA - 1], dataB.Data[upperB - 1])) {
                --upperA; --upperB;
            }

            if (lowerA == upperA) {
                // mark as inserted lines.
                while (lowerB < upperB)
                    dataB.Changed[lowerB++] = true;

            }
            else if (lowerB == upperB) {
                // mark as deleted lines.
                while (lowerA < upperA)
                    dataA.Changed[lowerA++] = true;

            }
            else {
                // Find the middle snakea and length of an optimal path for A and B
                var smsrd = SMS(dataA, lowerA, upperA, dataB, lowerB, upperB, downVector, upVector);
                // Debug.Write(2, "MiddleSnakeData", String.Format("{0},{1}", smsrd.x, smsrd.y));

                // The path is from LowerX to (x,y) and (x,y) to UpperX
                LCS(dataA, lowerA, smsrd.X, dataB, lowerB, smsrd.Y, downVector, upVector);
                LCS(dataA, smsrd.X, upperA, dataB, smsrd.Y, upperB, downVector, upVector);  // 2002.09.20: no need for 2 points 
            }
        } // LCS()


        /// <summary>Scan the tables of which lines are inserted and deleted,
        /// producing an edit script in forward order.  
        /// </summary>
        /// dynamic array
        private IEnumerable<Difference> CreateDiffs(DifferenceData dataA, DifferenceData dataB) {
            var lineA = 0;
            var lineB = 0;
            while (lineA < dataA.Length || lineB < dataB.Length) {
                if ((lineA < dataA.Length) && (!dataA.Changed[lineA])
                    && (lineB < dataB.Length) && (!dataB.Changed[lineB])) {
                    // equal lines
                    lineA++;
                    lineB++;

                }
                else {
                    // maybe deleted and/or inserted lines
                    var startA = lineA;
                    var startB = lineB;

                    while (lineA < dataA.Length && (lineB >= dataB.Length || dataA.Changed[lineA]))
                        // while (LineA < dataA.Length && dataA.modified[LineA])
                        lineA++;

                    while (lineB < dataB.Length && (lineA >= dataA.Length || dataB.Changed[lineB]))
                        // while (LineB < dataB.Length && dataB.modified[LineB])
                        lineB++;

                    if ((startA < lineA) || (startB < lineB)) {
                        // store a new difference-item
                        yield return new Difference {
                            FirstStartIndex = startA,
                            SecondStartIndex = startB,
                            CountOfDeletedInFirst = lineA - startA,
                            CountOfInsertedInSecond = lineB - startB
                        };
                    }
                }
            }
        }
    }
}