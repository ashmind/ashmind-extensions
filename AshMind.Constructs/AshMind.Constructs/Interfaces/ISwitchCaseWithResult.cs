using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces
{
    public interface ISwitchCaseWithResult<TBase, TResult> : IWithResult<TResult>
        where TBase : class
    {
        ISwitchCaseWithResult<TBase, TResult> Case<TCase>(Func<TCase, TResult> func)
            where TCase : class, TBase;

        ISwitchCaseWithResult<TBase, TResult> Case<TCase>(TResult result)
            where TCase : class, TBase;

        IWithResult<TResult> Otherwise(Func<TBase, TResult> func);
        IWithResult<TResult> Otherwise(TResult result);
    }
}
