using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Framework {
    public class WeakReferenceTargetEqualityComparer : IEqualityComparer<WeakReference> {
        private static readonly object NullObject = new object();

        public bool Equals(WeakReference x, WeakReference y) {
            if (object.Equals(x, y))
                return true;

            if (x == null || y == null)
                return false;

            return object.Equals(x.Target, y.Target);
        }

        public int GetHashCode(WeakReference obj) {
            if (obj == null || obj.Target == null)
                return NullObject.GetHashCode();
        }
    }
}
