using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces {
    public interface ISwitchCaseOrOtherwiseWithResult<TBase, TResult> : ISwitchCaseWithResult<TBase, TResult>, IOtherwiseThrow
        where TBase : class
    {
        IWithResult<TResult> Otherwise(Func<TBase, TResult> func);
        IWithResult<TResult> Otherwise(TResult result);
    }
}
