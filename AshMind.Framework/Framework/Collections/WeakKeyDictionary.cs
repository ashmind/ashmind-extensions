using System;
using System.Collections.Generic;
using System.Linq;

// Copyright (c) Nick Guerrera (http://blogs.msdn.com/nicholg/archive/2006/06/04/617466.aspx)

namespace AshMind.Framework.Collections {
    /// <summary>
    /// A generic dictionary, which allows both its keys and values 
    /// to be garbage collected if there are no other references
    /// to them than from the dictionary itself.
    /// </summary>
    /// 
    /// <remarks>
    /// If either the key or value of a particular entry in the dictionary
    /// has been collected, then both the key and value become effectively
    /// unreachable. However, left-over WeakReference objects for the key
    /// and value will physically remain in the dictionary until
    /// RemoveCollectedEntries is called. This will lead to a discrepancy
    /// between the Count property and the number of iterations required
    /// to visit all of the elements of the dictionary using its
    /// enumerator or those of the Keys and Values collections. Similarly,
    /// CopyTo will copy fewer than Count elements in this situation.
    /// </remarks>
    public sealed class WeakKeyDictionary<TKey, TValue> : BaseDictionary<TKey, TValue>
        where TKey : class
    {

        private readonly Dictionary<object, TValue> dictionary;
        private readonly WeakKeyComparer<TKey> comparer;

        public WeakKeyDictionary()
            : this(0, null) { }

        public WeakKeyDictionary(int capacity)
            : this(capacity, null) { }

        public WeakKeyDictionary(IEqualityComparer<TKey> comparer)
            : this(0, comparer) { }

        public WeakKeyDictionary(int capacity, IEqualityComparer<TKey> comparer) {
            this.comparer = new WeakKeyComparer<TKey>(comparer);
            this.dictionary = new Dictionary<object, TValue>(capacity, this.comparer);
        }

        // WARNING: The count returned here may include entries for which
        // the key object has already been garbage collected. Call
        // RemoveCollectedEntries to weed out collected entries and update
        // the count accordingly.
        public override int Count {
            get { return this.dictionary.Count; }
        }

        public override void Add(TKey key, TValue value) {
            if (key == null)
                throw new ArgumentNullException("key");

            var weakKey = new WeakKeyReference<TKey>(key, this.comparer);

            this.dictionary.Add(weakKey, value);
        }

        public override bool ContainsKey(TKey key) {
            return this.dictionary.ContainsKey(key);
        }

        public override bool Remove(TKey key) {
            return this.dictionary.Remove(key);
        }

        public override bool TryGetValue(TKey key, out TValue value) {
            return this.dictionary.TryGetValue(key, out value);
        }

        protected override void SetValue(TKey key, TValue value) {
            var weakKey = new WeakKeyReference<TKey>(key, this.comparer);
            this.dictionary[weakKey] = value;
        }

        public override void Clear() {
            this.dictionary.Clear();
        }

        public override IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            foreach (var pair in this.dictionary) {
                var weakKey = (WeakReference<TKey>)(pair.Key);
                var key = weakKey.Target;
                var value = pair.Value;

                if (weakKey.IsAlive)
                    yield return new KeyValuePair<TKey, TValue>(key, value);
            }
        }

        // Removes the left-over weak references for entries in the dictionary
        // whose key has already been reclaimed by the garbage collector. This
        // will reduce the dictionary's Count by the number of dead key-value
        // pairs that were eliminated.
        public void Compact() {
            List<object> toRemove = null;
            foreach (var pair in this.dictionary) {
                var weakKey = (WeakReference<TKey>)(pair.Key);

                if (!weakKey.IsAlive) {
                    if (toRemove == null)
                        toRemove = new List<object>();
                    toRemove.Add(weakKey);
                }
            }

            if (toRemove != null) {
                foreach (var key in toRemove)
                    this.dictionary.Remove(key);
            }
        }
    }
}
