using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AshMind.Framework.IO.Transactional.Internal {
    [Guid("79427A2B-F895-40e0-BE79-B57DC82ED231")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IKernelTransaction {
        int GetHandle(out IntPtr pHandle);
    }
}
