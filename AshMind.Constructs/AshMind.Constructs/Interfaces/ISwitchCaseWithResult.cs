using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Constructs.Interfaces
{
    public interface ISwitchCaseWithResult<TBase, TResult> : IWithResult<TResult>
        where TBase : class
    {
        ISwitchCaseOrOtherwiseWithResult<TBase, TResult> Case<TCase>(Func<TCase, TResult> func)
            where TCase : class, TBase;

        ISwitchCaseOrOtherwiseWithResult<TBase, TResult> Case<TCase>(TResult result)
            where TCase : class, TBase;
    }
}
