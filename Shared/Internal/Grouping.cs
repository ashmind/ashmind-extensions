using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace AshMind.Extensions.Internal {
    internal sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement> {
        public TKey Key { get; }
        [NotNull] private readonly IEnumerable<TElement> _elements;

        public Grouping(TKey key, [NotNull] IEnumerable<TElement> elements) {
            Key = key;
            _elements = elements;
        }

        public static IGrouping<TKey, TElement> Create(TKey key, [NotNull] IEnumerable<TElement> elements) {
            return new Grouping<TKey, TElement>(key, elements);
        }

        public IEnumerator<TElement> GetEnumerator() {
            return _elements.GetEnumerator();
        }

        #region IEnumerable Members

        IEnumerator IEnumerable.GetEnumerator() {
            return _elements.GetEnumerator();
        }

        #endregion
    }
}
