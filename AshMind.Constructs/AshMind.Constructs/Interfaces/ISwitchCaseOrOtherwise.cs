using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Constructs.Interfaces {
    public interface ISwitchCaseOrOtherwise<TBase> : ISwitchCase<TBase>
        where TBase : class 
    {
        void Otherwise(Action<TBase> action);
        void Otherwise(Action action);

        void OtherwiseThrow<TException>()
            where TException : Exception, new();

        void OtherwiseOutOfRange(string argumentName);
    }
}
