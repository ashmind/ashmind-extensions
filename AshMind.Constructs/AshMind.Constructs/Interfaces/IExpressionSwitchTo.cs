using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces
{
    public interface IExpressionSwitchTo<TBase>
        where TBase : class
    {
        IExpressionSwitchCase<TBase, TResult> To<TResult>()
            where TResult : class;
    }
}
