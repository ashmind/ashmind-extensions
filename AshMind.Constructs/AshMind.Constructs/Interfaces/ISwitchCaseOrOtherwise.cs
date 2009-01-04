using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Constructs.Interfaces {
    public interface ISwitchCaseOrOtherwise<TBase> : ISwitchCase<TBase>, IOtherwiseThrow
        where TBase : class 
    {
        void Otherwise(Action<TBase> action);
        void Otherwise(Action action);
    }
}
