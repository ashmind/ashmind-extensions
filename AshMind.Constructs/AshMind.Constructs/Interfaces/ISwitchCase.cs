using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces
{
    public interface ISwitchCase<TBase>
        where TBase : class
    {
        ISwitchCase<TBase> Case<TCase>(Action<TCase> action)
            where TCase : class, TBase;

        ISwitchCaseWithResult<TBase, TResult> Case<TCase, TResult>(Func<TCase, TResult> func)
            where TCase : class, TBase;

        ISwitchCaseWithResult<TBase, TResult> To<TResult>();

        void Otherwise(Action<TBase> action);
    }
}
