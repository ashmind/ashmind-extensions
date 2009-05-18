using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace AshMind.Framework {
    public class WeakReference<T> : WeakReference 
        where T : class
    {
        public WeakReference(T target) : base(target) {
        }
        
        public WeakReference(T target, bool trackResurrection) : base(target, trackResurrection) {
        }

        protected WeakReference(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        public virtual new T Target {
            get { return (T)base.Target; }
            set { base.Target = value; }
        }
    }
}
