using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Framework.Collections {
    [Serializable]
    public class LazyReadOnlyCollection<T> : ReadOnlyCollection<T> {
        private readonly Func<IList<T>> listProvider;
        private IList<T> innerList;

        public LazyReadOnlyCollection(Func<IList<T>> listProvider) : base(null) {
            this.listProvider = listProvider;
        }

        protected override IList<T> InnerList {
            get {
                if (this.innerList == null)
                    this.innerList = this.listProvider();

                return this.innerList;
            }
        }
    }
}