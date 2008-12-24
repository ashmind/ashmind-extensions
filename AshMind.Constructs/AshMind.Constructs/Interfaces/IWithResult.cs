using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AshMind.Constructs.Interfaces
{
    public interface IWithResult<TResult>
    {
        TResult Result { get; }
    }
}
