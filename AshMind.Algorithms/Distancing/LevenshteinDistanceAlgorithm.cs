/*
    This is an implementation of Levenshtein distance:
    http://en.wikipedia.org/wiki/Levenshtein_distance
 
    I tried to make it generic enough to support any kind of sequences.
  
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

namespace AshMind.Algorithms.Distancing {
    public class LevenshteinDistanceAlgorithm<T> : IDistanceAlgorithm<T> {
        protected IEqualityComparer<T> Comparer { get; private set; }

        public LevenshteinDistanceAlgorithm() : this(EqualityComparer<T>.Default) {
        }

        public LevenshteinDistanceAlgorithm(IEqualityComparer<T> comparer) {
            this.Comparer = comparer;
        }

        public int GetDistance(IEnumerable<T> left, IEnumerable<T> right) {
            return GetDistance(
                (left as IList<T>)  ?? left.ToArray(),
                (right as IList<T>) ?? right.ToArray()
            );
        }

        private int GetDistance(IList<T> left, IList<T> right) {
            var leftCount = left.Count;
            var rightCount = right.Count;

            var d = new int[leftCount + 1, rightCount + 1];

            for (var i = 0; i <= leftCount; i++) {
                d[i, 0] = i;
            }

            for (var i = 0; i <= rightCount; i++) {
                d[0, i] = i;
            }

            for (var i = 1; i <= leftCount; i++) {
                for (var j = 1; j <= rightCount; j++) {
                    var cost = this.Comparer.Equals(left[i - 1], right[j - 1]) ? 0 : 1;

                    var deleted  = d[i - 1, j] + 1;
                    var inserted = d[i, j - 1] + 1;
                    var substituted = d[i - 1, j - 1] + cost;

                    d[i, j] = Math.Min(deleted, Math.Min(inserted, substituted));

                    this.ApplyCorrection(left, right, d, i, j, cost);
                }
            }

            return d[leftCount, rightCount];
        }

        protected virtual void ApplyCorrection(IList<T> left, IList<T> right, int[,] d, int i, int j, int cost) {
        }
    }
}
