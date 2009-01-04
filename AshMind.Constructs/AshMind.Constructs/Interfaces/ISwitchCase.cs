using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces
{
    public interface ISwitchCase<TBase>
        where TBase : class
    {
        ISwitchCaseOrOtherwise<TBase> Case<TCase>(Action<TCase> action)
            where TCase : class, TBase;
    }
}
