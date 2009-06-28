using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

using AshMind.Framework.IO.Transactional.Internal;

namespace AshMind.Framework.IO.Transactional {
    public static class File {
        public static FileStream Open(string path, FileMode mode) {
            return File.Open(path, mode, (mode == FileMode.Append) ? FileAccess.Write : FileAccess.ReadWrite, FileShare.None);
        }

        public static FileStream Open(string path, FileMode mode, FileAccess access) {
            return File.Open(path, mode, access, FileShare.None);
        }

        public static FileStream Open(string path, FileMode mode, FileAccess access, FileShare share) {
            if (!KtmTransactionHandle.IsAvailable)
                return System.IO.File.Open(path, mode, access, share);

            using (var transactionHandle = KtmTransactionHandle.Get()) {
                var nativeMode = ToNative(mode);
                var nativeShare = ToNative(share);
                var nativeAccess = ToNative(access);

                // Create the transacted file using P/Invoke.
                var hFile = NativeMethods.CreateFileTransacted(
                    path,
                    nativeAccess,
                    nativeShare,
                    IntPtr.Zero,
                    nativeMode,
                    0,
                    IntPtr.Zero,
                    transactionHandle,
                    IntPtr.Zero,
                    IntPtr.Zero
                );

                // Throw an exception if an error occured.
                if (hFile.IsInvalid)
                    HandleNativeError(Marshal.GetLastWin32Error());

                // Return a FileStream created using the 
                // transacted file's handle.
                var stream = new FileStream(hFile, access);
                return stream;
            }
        }

        public static void Move(string sourceFileName, string destFileName) {
            if (!KtmTransactionHandle.IsAvailable)
                System.IO.File.Move(sourceFileName, destFileName);

            using (var transactionHandle = KtmTransactionHandle.Get()) {
                var moved = NativeMethods.MoveFileTransacted(
                    sourceFileName, destFileName, IntPtr.Zero, IntPtr.Zero, 0, transactionHandle
                );

                if (!moved)
                    HandleNativeError(Marshal.GetLastWin32Error());
            }
        }

        public static void Copy(string sourceFileName, string destFileName) {
            File.Copy(sourceFileName, destFileName, false);
        }

        public static void Copy(string sourceFileName, string destFileName, bool overwrite) {
            if (!KtmTransactionHandle.IsAvailable)
                System.IO.File.Copy(sourceFileName, destFileName, overwrite);

            using (var transactionHandle = KtmTransactionHandle.Get()) {
                var cancel = false;
                var flags = overwrite ? 0 : NativeMethods.CopyFileFlags.COPY_FILE_FAIL_IF_EXISTS;
                var copied = NativeMethods.CopyFileTransacted(
                    sourceFileName, destFileName, IntPtr.Zero, IntPtr.Zero, ref cancel, flags, transactionHandle
                );

                if (!copied)
                    HandleNativeError(Marshal.GetLastWin32Error());
            }
        }

        public static void Delete(string path) {
            if (!KtmTransactionHandle.IsAvailable)
                System.IO.File.Delete(path);

            using (var transactionHandle = KtmTransactionHandle.Get()) {
                var deleted = NativeMethods.DeleteFileTransacted(path, transactionHandle);
                if (!deleted)
                    HandleNativeError(Marshal.GetLastWin32Error());
            }
        }

        private static void HandleNativeError(int error) {
            throw new System.ComponentModel.Win32Exception(error);
        }

        private static NativeMethods.FileMode ToNative(FileMode mode) {
            if (mode == FileMode.Append)
                return (NativeMethods.FileMode)(int)FileMode.OpenOrCreate;

            return (NativeMethods.FileMode)(int)mode;
        }

        private static NativeMethods.FileAccess ToNative(FileAccess access) {
            return access == FileAccess.Read 
                 ? NativeMethods.FileAccess.GENERIC_READ
                 : NativeMethods.FileAccess.GENERIC_WRITE;
        }

        private static NativeMethods.FileShare ToNative(FileShare share) {
            return (NativeMethods.FileShare)(int)share;
        }

    }
}
