using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AshMind.Constructs.Interfaces
{
    public interface IExpressionSwitchCase<TBase, TResult> : IExpressable<Func<TBase, TResult>>
        where TBase : class
    {
        IExpressionSwitchCase<TBase, TResult> Case<TCase>(Expression<Func<TCase, TResult>> func)
            where TCase : class, TBase;

        IExpressionSwitchCase<TBase, TResult> Case<TCase>(TResult result)
            where TCase : class, TBase;

        IExpressable<Func<TBase, TResult>> Otherwise(Expression<Func<TBase, TResult>> func);
        IExpressable<Func<TBase, TResult>> Otherwise(TResult result);
    }
}
