using System;
using System.Collections.Generic;
using System.Linq;

// Copyright (c) Nick Guerrera (http://blogs.msdn.com/nicholg/archive/2006/06/04/617466.aspx)

namespace AshMind.Framework.Collections {
    // Compares objects of the given type or WeakKeyReferences to them
    // for equality based on the given comparer. Note that we can only
    // implement IEqualityComparer<T> for T = object as there is no 
    // other common base between T and WeakKeyReference<T>. We need a
    // single comparer to handle both types because we don't want to
    // allocate a new weak reference for every lookup.
    internal sealed class WeakKeyComparer<T> : IEqualityComparer<object>
        where T : class {

        private readonly IEqualityComparer<T> comparer;

        internal WeakKeyComparer(IEqualityComparer<T> comparer) {
            if (comparer == null)
                comparer = EqualityComparer<T>.Default;

            this.comparer = comparer;
        }

        public int GetHashCode(object obj) {
            var weakKey = obj as WeakKeyReference<T>;
            if (weakKey != null)
                return weakKey.HashCode;

            return this.comparer.GetHashCode((T)obj);
        }

        // Note: There are actually 9 cases to handle here.
        //
        //  Let Wa = Alive Weak Reference
        //  Let Wd = Dead Weak Reference
        //  Let S  = Strong Reference
        //  
        //  x  | y  | Equals(x,y)
        // -------------------------------------------------
        //  Wa | Wa | comparer.Equals(x.Target, y.Target) 
        //  Wa | Wd | false
        //  Wa | S  | comparer.Equals(x.Target, y)
        //  Wd | Wa | false
        //  Wd | Wd | x == y
        //  Wd | S  | false
        //  S  | Wa | comparer.Equals(x, y.Target)
        //  S  | Wd | false
        //  S  | S  | comparer.Equals(x, y)
        // -------------------------------------------------
        public new bool Equals(object x, object y) {
            bool xIsDead, yIsDead;
            var first = GetTarget(x, out xIsDead);
            var second = GetTarget(y, out yIsDead);

            if (xIsDead)
                return yIsDead ? x == y : false;

            if (yIsDead)
                return false;

            return this.comparer.Equals(first, second);
        }

        private static T GetTarget(object obj, out bool isDead) {
            var wref = obj as WeakKeyReference<T>;
            T target;
            if (wref != null) {
                target = wref.Target;
                isDead = !wref.IsAlive;
            }
            else {
                target = (T)obj;
                isDead = false;
            }
            return target;
        }
    }
}
