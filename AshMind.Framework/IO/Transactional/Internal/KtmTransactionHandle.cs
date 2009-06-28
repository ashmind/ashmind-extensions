using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

using Microsoft.Win32.SafeHandles;

namespace AshMind.Framework.IO.Transactional.Internal {
    public class KtmTransactionHandle : SafeHandleZeroOrMinusOneIsInvalid {
        internal KtmTransactionHandle(IntPtr handle) : base(true) {
            this.handle = handle;
        }

        public static bool IsAvailable {
            get { return Transaction.Current != null; }
        }

        public static KtmTransactionHandle Get() {
            if (!IsAvailable)
                throw new InvalidOperationException("KTM handle is not available.");

            return KtmTransactionHandle.Get(Transaction.Current);
        }

        public static KtmTransactionHandle Get(Transaction managedTransaction) {
            var dtcTransaction = TransactionInterop.GetDtcTransaction(managedTransaction);
            var ktmInterface = (IKernelTransaction)dtcTransaction;

            IntPtr ktmTxHandle;
            var hr = ktmInterface.GetHandle(out ktmTxHandle);
            HandleError(hr);
            return new KtmTransactionHandle(ktmTxHandle);
        }

        protected override bool ReleaseHandle() {
            return NativeMethods.CloseHandle(this.handle);
        }

        private static void HandleError(int error) {
            if (error != NativeMethods.ERROR_SUCCESS)
                throw new System.ComponentModel.Win32Exception(error);
        }
    }
}
