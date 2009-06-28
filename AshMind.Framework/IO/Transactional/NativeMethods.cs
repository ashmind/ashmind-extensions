using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

using AshMind.Framework.IO.Transactional.Internal;
using Microsoft.Win32.SafeHandles;

namespace AshMind.Framework.IO.Transactional {
    // ReSharper disable InconsistentNaming
    [SuppressUnmanagedCodeSecurity]
    internal static class NativeMethods {
        [Flags]
        public enum FileShare {
            FILE_SHARE_NONE = 0x00,
            FILE_SHARE_READ = 0x01,
            FILE_SHARE_WRITE = 0x02,
            FILE_SHARE_DELETE = 0x04
        }

        public enum FileMode {
            CREATE_NEW = 1,
            CREATE_ALWAYS = 2,
            OPEN_EXISTING = 3,
            OPEN_ALWAYS = 4,
            TRUNCATE_EXISTING = 5
        }

        public enum FileAccess {
            GENERIC_READ = unchecked((int)0x80000000),
            GENERIC_WRITE = 0x40000000
        }

        [Flags]
        internal enum CopyFileFlags : uint {
            COPY_FILE_FAIL_IF_EXISTS = 0x00000001,
            COPY_FILE_RESTARTABLE = 0x00000002,
            COPY_FILE_OPEN_SOURCE_FOR_WRITE = 0x00000004,
            COPY_FILE_ALLOW_DECRYPTED_DESTINATION = 0x00000008,
            COPY_FILE_COPY_SYMLINK = 0x00000800
        }

        [Flags]
        public enum MoveFileFlags : uint {
            MOVEFILE_REPLACE_EXISTING = 0x00000001,
            MOVEFILE_COPY_ALLOWED = 0x00000002,
            MOVEFILE_DELAY_UNTIL_REBOOT = 0x00000004,
            MOVEFILE_WRITE_THROUGH = 0x00000008,
            MOVEFILE_CREATE_HARDLINK = 0x00000010,
            MOVEFILE_FAIL_IF_NOT_TRACKABLE = 0x00000020
        }

        // Win32 Error codes.
        internal const int ERROR_SUCCESS = 0;
        internal const int ERROR_FILE_NOT_FOUND = 2;
        internal const int ERROR_NO_MORE_FILES = 18;
        internal const int ERROR_RECOVERY_NOT_NEEDED = 6821;

        [DllImport("kernel32.dll", EntryPoint = "CreateFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        internal static extern SafeFileHandle CreateFileTransacted(
            [In] string lpFileName,
            [In] NativeMethods.FileAccess dwDesiredAccess,
            [In] NativeMethods.FileShare dwShareMode,
            [In] IntPtr lpSecurityAttributes,
            [In] NativeMethods.FileMode dwCreationDisposition,
            [In] int dwFlagsAndAttributes,
            [In] IntPtr hTemplateFile,
            [In] KtmTransactionHandle hTransaction,
            [In] IntPtr pusMiniVersion,
            [In] IntPtr pExtendedParameter
        );

        [DllImport("kernel32.dll", EntryPoint = "MoveFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool MoveFileTransacted(
            [In] string lpExistingFileName,
            [In] string lpNewFileName,
            [In] IntPtr lpProgressRoutine,
            [In] IntPtr lpData,
            [In] MoveFileFlags dwFlags,
            [In] KtmTransactionHandle hTransaction
        );

        [DllImport("kernel32.dll", EntryPoint = "CopyFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CopyFileTransacted(
            [In] string lpExistingFileName,
            [In] string lpNewFileName,
            [In] IntPtr lpProgressRoutine,
            [In] IntPtr lpData,
            [In] [MarshalAs(UnmanagedType.Bool)] ref bool pbCancel,
            [In] CopyFileFlags dwCopyFlags,
            [In] KtmTransactionHandle hTransaction
        );

        [DllImport("kernel32.dll", EntryPoint = "DeleteFileTransacted", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool DeleteFileTransacted(
            [In] string lpFileName,
            [In] KtmTransactionHandle hTransaction
        );

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CloseHandle([In] IntPtr handle);
     
    }
    // ReSharper restore InconsistentNaming
}
