using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Constructs.Interfaces {
    public interface ISwitchCaseOrOtherwiseWithResult<TBase, TResult> : ISwitchCaseWithResult<TBase, TResult>
        where TBase : class
    {
        IWithResult<TResult> Otherwise(Func<TBase, TResult> func);
        IWithResult<TResult> Otherwise(TResult result);

        IWithResult<TResult> OtherwiseThrow<TException>()
            where TException : Exception, new();

        IWithResult<TResult> OtherwiseOutOfRange(string argumentName);
    }
}
