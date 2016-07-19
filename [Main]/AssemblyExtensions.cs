using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
#if FileInfo && Assembly_Location
using System.IO;
#endif
using System.Reflection;
using JetBrains.Annotations;
using Contracts = System.Diagnostics.Contracts;
using PureAttribute = JetBrains.Annotations.PureAttribute;

namespace AshMind.Extensions {
    /// <summary>Provides a set of extension methods for operations on <see cref="Assembly" />.</summary>
    public static class AssemblyExtensions {
        #if FileInfo && Assembly_Location
        /// <summary>Gets a <see cref="FileInfo" /> object based on <see cref="Assembly.Location" />.</summary>
        /// <param name="assembly">An <see cref="Assembly" /> object providing the location.</param>
        /// <returns>A <see cref="FileInfo" /> object located at <see cref="Assembly.Location" />.</returns>
        /// <exception cref="NotSupportedException">The assembly is a dynamic assembly.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static FileInfo GetAssemblyFile([NotNull] this Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            Contract.EndContractBlock();

            return new FileInfo(assembly.Location);
        }

        /// <summary>Gets a <see cref="FileInfo" /> object based on <see cref="Assembly.CodeBase" />.</summary>
        /// <param name="assembly">An <see cref="Assembly" /> object providing the code base.</param>
        /// <returns>
        ///  A <see cref="FileInfo" /> object located at <see cref="Assembly.CodeBase" />.
        /// </returns>
        /// <exception cref="NotSupportedException">The assembly is a dynamic assembly.</exception>
        /// <exception cref="NotSupportedException">The <see cref="Assembly.CodeBase" /> does not contain a file:// URL.</exception>
        [Contracts.Pure] [Pure] [NotNull]
        public static FileInfo GetAssemblyFileFromCodeBase([NotNull] this Assembly assembly) {
            if (assembly == null) throw new ArgumentNullException(nameof(assembly));
            Contract.EndContractBlock();

            var uri = new Uri(assembly.EscapedCodeBase);
            if (!uri.IsFile)
                throw new NotSupportedException("GetAssemblyFileFromCodeBase is only supported if CodeBase uses a file:// schema.");

            return new FileInfo(uri.LocalPath);
        }
        #endif
    }
}
