using System;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Constructs.Interfaces {
    public interface IOtherwiseThrow {
        void OtherwiseThrow<TException>()
            where TException : Exception, new();

        void OtherwiseOutOfRange(string argumentName);
    }
}
