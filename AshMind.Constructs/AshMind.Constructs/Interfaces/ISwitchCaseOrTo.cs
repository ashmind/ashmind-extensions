using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces {
    public interface ISwitchCaseOrTo<TBase> : ISwitchCase<TBase> 
        where TBase : class 
    {
        ISwitchCaseWithResult<TBase, TResult> Case<TCase, TResult>(Func<TCase, TResult> func)
            where TCase : class, TBase;

        ISwitchCaseWithResult<TBase, TResult> To<TResult>();
    }
}
