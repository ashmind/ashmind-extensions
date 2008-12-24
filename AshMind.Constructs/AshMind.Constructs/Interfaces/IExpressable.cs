using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Linq.Expressions;

namespace AshMind.Constructs.Interfaces
{
    public interface IExpressable<TDelegate>
    {
        Expression<TDelegate> ToExpression();
        TDelegate Compile();
    }
}
