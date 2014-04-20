using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq.Expressions;
using JetBrains.Annotations;

// ReSharper disable AnnotationRedundanceAtValueType
namespace AshMind.Extensions {
    /// <summary>
    /// Provides a set of extension methods for operations on <see cref="Expression"/>.
    /// </summary>
    [Obsolete("Will be removed later on (around 2.0): signficantly increases library size without providing that much benefit.")]
    public static class ExpressionExtensions {
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic addition operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Add" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The addition operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Add([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Add(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic addition operation that does not have overflow checking. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Add" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the addition operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Add([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Add(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an addition assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AddAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.AddAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an addition assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AddAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.AddAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an addition assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AddAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.AddAssign(left, right, method, conversion);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an addition assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AddAssignChecked([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.AddAssignChecked(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an addition assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AddAssignChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.AddAssignChecked(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an addition assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AddAssignChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.AddAssignChecked(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic addition operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The addition operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression AddChecked([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.AddChecked(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic addition operation that has overflow checking. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AddChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the addition operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression AddChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.AddChecked(left, right, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise AND operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.And" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The bitwise AND operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression And([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.And(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise AND operation. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.And" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the bitwise AND operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression And([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.And(left, right, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a conditional AND operation that evaluates the second operand only if the first operand evaluates to true.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AndAlso" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The bitwise AND operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.-or-<paramref name="left" />.Type and <paramref name="right" />.Type are not the same Boolean type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression AndAlso([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.AndAlso(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a conditional AND operation that evaluates the second operand only if the first operand is resolved to true. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AndAlso" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the bitwise AND operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.-or-<paramref name="method" /> is null and <paramref name="left" />.Type and <paramref name="right" />.Type are not the same Boolean type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression AndAlso([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.AndAlso(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise AND assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AndAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AndAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.AndAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise AND assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AndAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AndAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.AndAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise AND assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.AndAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression AndAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.AndAssign(left, right, method, conversion);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates an <see cref="T:System.Linq.Expressions.IndexExpression" /> to access an array.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.IndexExpression" />.</returns>
        /// <param name="array">An expression representing the array to index.</param>
        /// <param name="indexes">An array that contains expressions used to index the array.</param>
        [Pure] [NotNull]
        public static IndexExpression ArrayAccess([NotNull] this Expression array, [NotNull] Expression[] indexes) {
            return Expression.ArrayAccess(array, indexes);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates an <see cref="T:System.Linq.Expressions.IndexExpression" /> to access a multidimensional array.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.IndexExpression" />.</returns>
        /// <param name="array">An expression that represents the multidimensional array.</param>
        /// <param name="indexes">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> containing expressions used to index the array.</param>
        [Pure] [NotNull]
        public static IndexExpression ArrayAccess([NotNull] this Expression array, [NotNull] IEnumerable<Expression> indexes) {
            return Expression.ArrayAccess(array, indexes);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents applying an array index operator to a multidimensional array.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> and <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> properties set to the specified values.</returns>
        /// <param name="array">An array of <see cref="T:System.Linq.Expressions.Expression" /> instances - indexes for the array index operation.</param>
        /// <param name="indexes">An array of <see cref="T:System.Linq.Expressions.Expression" /> objects to use to populate the <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> or <paramref name="indexes" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array" />.Type does not represent an array type.-or-The rank of <paramref name="array" />.Type does not match the number of elements in <paramref name="indexes" />.-or-The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of one or more elements of <paramref name="indexes" /> does not represent the <see cref="T:System.Int32" /> type.</exception>
        [Pure] [NotNull]
        public static MethodCallExpression ArrayIndex([NotNull] this Expression array, [NotNull] Expression[] indexes) {
            return Expression.ArrayIndex(array, indexes);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents applying an array index operator to an array of rank more than one.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> and <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> properties set to the specified values.</returns>
        /// <param name="array">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> property equal to.</param>
        /// <param name="indexes">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains <see cref="T:System.Linq.Expressions.Expression" /> objects to use to populate the <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> or <paramref name="indexes" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array" />.Type does not represent an array type.-or-The rank of <paramref name="array" />.Type does not match the number of elements in <paramref name="indexes" />.-or-The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of one or more elements of <paramref name="indexes" /> does not represent the <see cref="T:System.Int32" /> type.</exception>
        [Pure] [NotNull]
        public static MethodCallExpression ArrayIndex([NotNull] this Expression array, [NotNull] IEnumerable<Expression> indexes) {
            return Expression.ArrayIndex(array, indexes);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents applying an array index operator to an array of rank one.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ArrayIndex" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="array">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="index">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> or <paramref name="index" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array" />.Type does not represent an array type.-or-<paramref name="array" />.Type represents an array type whose rank is not 1.-or-<paramref name="index" />.Type does not represent the <see cref="T:System.Int32" /> type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression ArrayIndex([NotNull] this Expression array, [NotNull] Expression index) {
            return Expression.ArrayIndex(array, index);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an expression for obtaining the length of a one-dimensional array.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ArrayLength" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to <paramref name="array" />.</returns>
        /// <param name="array">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="array" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="array" />.Type does not represent an array type.</exception>
        [Pure] [NotNull]
        public static UnaryExpression ArrayLength([NotNull] this Expression array) {
            return Expression.ArrayLength(array);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Assign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression Assign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Assign(left, right);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents a call to an instance method that takes no arguments.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> and <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="instance">An <see cref="T:System.Linq.Expressions.Expression" /> that specifies the instance for an instance method call (pass null for a static (Shared in Visual Basic) method).</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="method" /> is null.-or-<paramref name="instance" /> is null and <paramref name="method" /> represents an instance method.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="instance" />.Type is not assignable to the declaring type of the method represented by <paramref name="method" />.</exception>
        [Pure] [NotNull]
        public static MethodCallExpression Call([NotNull] this Expression instance, [NotNull] MethodInfo method) {
            return Expression.Call(instance, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents a call to a method that takes arguments.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" />, <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" />, and <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> properties set to the specified values.</returns>
        /// <param name="instance">An <see cref="T:System.Linq.Expressions.Expression" /> that specifies the instance fo an instance method call (pass null for a static (Shared in Visual Basic) method).</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> property equal to.</param>
        /// <param name="arguments">An array of <see cref="T:System.Linq.Expressions.Expression" /> objects to use to populate the <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="method" /> is null.-or-<paramref name="instance" /> is null and <paramref name="method" /> represents an instance method.-or-<paramref name="arguments" /> is not null and one or more of its elements is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="instance" />.Type is not assignable to the declaring type of the method represented by <paramref name="method" />.-or-The number of elements in <paramref name="arguments" /> does not equal the number of parameters for the method represented by <paramref name="method" />.-or-One or more of the elements of <paramref name="arguments" /> is not assignable to the corresponding parameter for the method represented by <paramref name="method" />.</exception>
        [Pure] [NotNull]
        public static MethodCallExpression Call([NotNull] this Expression instance, [NotNull] MethodInfo method, [NotNull] Expression[] arguments) {
            return Expression.Call(instance, method, arguments);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents a call to a static method that takes two arguments.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> and <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="instance">An <see cref="T:System.Linq.Expressions.Expression" /> that specifies the instance for an instance call. (pass null for a static (Shared in Visual Basic) method).</param>
        /// <param name="method">The <see cref="T:System.Reflection.MethodInfo" /> that represents the target method.</param>
        /// <param name="arg0">The <see cref="T:System.Linq.Expressions.Expression" /> that represents the first argument.</param>
        /// <param name="arg1">The <see cref="T:System.Linq.Expressions.Expression" /> that represents the second argument.</param>
        [Pure] [NotNull]
        public static MethodCallExpression Call([NotNull] this Expression instance, [NotNull] MethodInfo method, [NotNull] Expression arg0, [NotNull] Expression arg1) {
            return Expression.Call(instance, method, arg0, arg1);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents a call to a method that takes no arguments.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> and <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="instance">An <see cref="T:System.Linq.Expressions.Expression" /> that specifies the instance for an instance call. (pass null for a static (Shared in Visual Basic) method).</param>
        /// <param name="method">The <see cref="T:System.Reflection.MethodInfo" /> that represents the target method.</param>
        /// <param name="arg0">The <see cref="T:System.Linq.Expressions.Expression" /> that represents the first argument.</param>
        /// <param name="arg1">The <see cref="T:System.Linq.Expressions.Expression" /> that represents the second argument.</param>
        /// <param name="arg2">The <see cref="T:System.Linq.Expressions.Expression" /> that represents the third argument.</param>
        [Pure] [NotNull]
        public static MethodCallExpression Call([NotNull] this Expression instance, [NotNull] MethodInfo method, [NotNull] Expression arg0, [NotNull] Expression arg1, [NotNull] Expression arg2) {
            return Expression.Call(instance, method, arg0, arg1, arg2);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents a call to an instance method by calling the appropriate factory method.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" />, the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> property equal to <paramref name="instance" />, <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> set to the <see cref="T:System.Reflection.MethodInfo" /> that represents the specified instance method, and <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> set to the specified arguments.</returns>
        /// <param name="instance">An <see cref="T:System.Linq.Expressions.Expression" /> whose <see cref="P:System.Linq.Expressions.Expression.Type" /> property value will be searched for a specific method.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <param name="typeArguments">An array of <see cref="T:System.Type" /> objects that specify the type parameters of the generic method. This argument should be null when methodName specifies a non-generic method.</param>
        /// <param name="arguments">An array of <see cref="T:System.Linq.Expressions.Expression" /> objects that represents the arguments to the method.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="instance" /> or <paramref name="methodName" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">No method whose name is <paramref name="methodName" />, whose type parameters match <paramref name="typeArguments" />, and whose parameter types match <paramref name="arguments" /> is found in <paramref name="instance" />.Type or its base types.-or-More than one method whose name is <paramref name="methodName" />, whose type parameters match <paramref name="typeArguments" />, and whose parameter types match <paramref name="arguments" /> is found in <paramref name="instance" />.Type or its base types.</exception>
        [Pure] [NotNull]
        public static MethodCallExpression Call([NotNull] this Expression instance, [NotNull] String methodName, [NotNull] Type[] typeArguments, [NotNull] Expression[] arguments) {
            return Expression.Call(instance, methodName, typeArguments, arguments);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that represents a call to a method that takes arguments.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MethodCallExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Call" /> and the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" />, <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" />, and <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> properties set to the specified values.</returns>
        /// <param name="instance">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.MethodCallExpression.Object" /> property equal to (pass null for a static (Shared in Visual Basic) method).</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.MethodCallExpression.Method" /> property equal to.</param>
        /// <param name="arguments">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains <see cref="T:System.Linq.Expressions.Expression" /> objects to use to populate the <see cref="P:System.Linq.Expressions.MethodCallExpression.Arguments" /> collection.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="method" /> is null.-or-<paramref name="instance" /> is null and <paramref name="method" /> represents an instance method.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="instance" />.Type is not assignable to the declaring type of the method represented by <paramref name="method" />.-or-The number of elements in <paramref name="arguments" /> does not equal the number of parameters for the method represented by <paramref name="method" />.-or-One or more of the elements of <paramref name="arguments" /> is not assignable to the corresponding parameter for the method represented by <paramref name="method" />.</exception>
        [Pure] [NotNull]
        public static MethodCallExpression Call([NotNull] this Expression instance, [NotNull] MethodInfo method, [NotNull] IEnumerable<Expression> arguments) {
            return Expression.Call(instance, method, arguments);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a coalescing operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Coalesce" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of <paramref name="left" /> does not represent a reference type or a nullable value type.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="left" />.Type and <paramref name="right" />.Type are not convertible to each other.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Coalesce([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Coalesce(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a coalescing operation, given a conversion function.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Coalesce" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="left" />.Type and <paramref name="right" />.Type are not convertible to each other.-or-<paramref name="conversion" /> is not null and <paramref name="conversion" />.Type is a delegate type that does not take exactly one argument.</exception>
        /// <exception cref="T:System.InvalidOperationException">The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of <paramref name="left" /> does not represent a reference type or a nullable value type.-or-The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of <paramref name="left" /> represents a type that is not assignable to the parameter type of the delegate type <paramref name="conversion" />.Type.-or-The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of <paramref name="right" /> is not equal to the return type of the delegate type <paramref name="conversion" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Coalesce([NotNull] this Expression left, [NotNull] Expression right, [NotNull] LambdaExpression conversion) {
            return Expression.Coalesce(left, right, conversion);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents a type conversion operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Convert" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> and <see cref="P:System.Linq.Expressions.Expression.Type" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="type">A <see cref="T:System.Type" /> to set the <see cref="P:System.Linq.Expressions.Expression.Type" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="type" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">No conversion operator is defined between <paramref name="expression" />.Type and <paramref name="type" />.</exception>
        [Pure] [NotNull]
        public static UnaryExpression Convert([NotNull] this Expression expression, [NotNull] Type type) {
            return Expression.Convert(expression, type);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents a conversion operation for which the implementing method is specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Convert" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" />, <see cref="P:System.Linq.Expressions.Expression.Type" />, and <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="type">A <see cref="T:System.Type" /> to set the <see cref="P:System.Linq.Expressions.Expression.Type" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="type" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly one argument.</exception>
        /// <exception cref="T:System.InvalidOperationException">No conversion operator is defined between <paramref name="expression" />.Type and <paramref name="type" />.-or-<paramref name="expression" />.Type is not assignable to the argument type of the method represented by <paramref name="method" />.-or-The return type of the method represented by <paramref name="method" /> is not assignable to <paramref name="type" />.-or-<paramref name="expression" />.Type or <paramref name="type" /> is a nullable value type and the corresponding non-nullable value type does not equal the argument type or the return type, respectively, of the method represented by <paramref name="method" />.</exception>
        /// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method that matches the <paramref name="method" /> description was found.</exception>
        [Pure] [NotNull]
        public static UnaryExpression Convert([NotNull] this Expression expression, [NotNull] Type type, [NotNull] MethodInfo method) {
            return Expression.Convert(expression, type, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents a conversion operation that throws an exception if the target type is overflowed.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ConvertChecked" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> and <see cref="P:System.Linq.Expressions.Expression.Type" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="type">A <see cref="T:System.Type" /> to set the <see cref="P:System.Linq.Expressions.Expression.Type" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="type" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">No conversion operator is defined between <paramref name="expression" />.Type and <paramref name="type" />.</exception>
        [Pure] [NotNull]
        public static UnaryExpression ConvertChecked([NotNull] this Expression expression, [NotNull] Type type) {
            return Expression.ConvertChecked(expression, type);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents a conversion operation that throws an exception if the target type is overflowed and for which the implementing method is specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ConvertChecked" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" />, <see cref="P:System.Linq.Expressions.Expression.Type" />, and <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="type">A <see cref="T:System.Type" /> to set the <see cref="P:System.Linq.Expressions.Expression.Type" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="type" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly one argument.</exception>
        /// <exception cref="T:System.InvalidOperationException">No conversion operator is defined between <paramref name="expression" />.Type and <paramref name="type" />.-or-<paramref name="expression" />.Type is not assignable to the argument type of the method represented by <paramref name="method" />.-or-The return type of the method represented by <paramref name="method" /> is not assignable to <paramref name="type" />.-or-<paramref name="expression" />.Type or <paramref name="type" /> is a nullable value type and the corresponding non-nullable value type does not equal the argument type or the return type, respectively, of the method represented by <paramref name="method" />.</exception>
        /// <exception cref="T:System.Reflection.AmbiguousMatchException">More than one method that matches the <paramref name="method" /> description was found.</exception>
        [Pure] [NotNull]
        public static UnaryExpression ConvertChecked([NotNull] this Expression expression, [NotNull] Type type, [NotNull] MethodInfo method) {
            return Expression.ConvertChecked(expression, type, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the decrementing of the expression by 1.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the decremented expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to decrement.</param>
        [Pure] [NotNull]
        public static UnaryExpression Decrement([NotNull] this Expression expression) {
            return Expression.Decrement(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the decrementing of the expression by 1.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the decremented expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to decrement.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression Decrement([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.Decrement(expression, method);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic division operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Divide" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The division operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Divide([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Divide(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic division operation. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Divide" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the division operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Divide([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Divide(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a division assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.DivideAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression DivideAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.DivideAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a division assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.DivideAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression DivideAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.DivideAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a division assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.DivideAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression DivideAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.DivideAssign(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an equality comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Equal" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The equality operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Equal([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Equal(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an equality comparison. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Equal" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to false.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the equality operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Equal([NotNull] this Expression left, [NotNull] Expression right, [NotNull] Boolean liftToNull, [NotNull] MethodInfo method) {
            return Expression.Equal(left, right, liftToNull, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise XOR operation, using op_ExclusiveOr for user-defined types. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ExclusiveOr" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the XOR operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression ExclusiveOr([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.ExclusiveOr(left, right, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise XOR operation, using op_ExclusiveOr for user-defined types.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ExclusiveOr" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The XOR operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression ExclusiveOr([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.ExclusiveOr(left, right);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise XOR assignment operation, using op_ExclusiveOr for user-defined types.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ExclusiveOrAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ExclusiveOrAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.ExclusiveOrAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise XOR assignment operation, using op_ExclusiveOr for user-defined types.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ExclusiveOrAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ExclusiveOrAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.ExclusiveOrAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise XOR assignment operation, using op_ExclusiveOr for user-defined types.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ExclusiveOrAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ExclusiveOrAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.ExclusiveOrAssign(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a field.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MemberExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess" /> and the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> and <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property equal to. For static (Shared in Visual Basic), <paramref name="expression" /> must be null.</param>
        /// <param name="field">The <see cref="T:System.Reflection.FieldInfo" /> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="field" /> is null.-or-The field represented by <paramref name="field" /> is not static (Shared in Visual Basic) and <paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="expression" />.Type is not assignable to the declaring type of the field represented by <paramref name="field" />.</exception>
        [Pure] [NotNull]
        public static MemberExpression Field([NotNull] this Expression expression, [NotNull] FieldInfo field) {
            return Expression.Field(expression, field);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a field given the name of the field.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MemberExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess" />, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property set to <paramref name="expression" />, and the <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> property set to the <see cref="T:System.Reflection.FieldInfo" /> that represents the field denoted by <paramref name="fieldName" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> whose <see cref="P:System.Linq.Expressions.Expression.Type" /> contains a field named <paramref name="fieldName" />. This can be null for static fields.</param>
        /// <param name="fieldName">The name of a field to be accessed.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="fieldName" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException">No field named <paramref name="fieldName" /> is defined in <paramref name="expression" />.Type or its base types.</exception>
        [Pure] [NotNull]
        public static MemberExpression Field([NotNull] this Expression expression, [NotNull] String fieldName) {
            return Expression.Field(expression, fieldName);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a field.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.MemberExpression" />.</returns>
        /// <param name="expression">The containing object of the field. This can be null for static fields.</param>
        /// <param name="type">The <see cref="P:System.Linq.Expressions.Expression.Type" /> that contains the field.</param>
        /// <param name="fieldName">The field to be accessed.</param>
        [Pure] [NotNull]
        public static MemberExpression Field([NotNull] this Expression expression, [NotNull] Type type, [NotNull] String fieldName) {
            return Expression.Field(expression, type, fieldName);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "greater than" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.GreaterThan" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The "greater than" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression GreaterThan([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.GreaterThan(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "greater than" numeric comparison. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.GreaterThan" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to false.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the "greater than" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression GreaterThan([NotNull] this Expression left, [NotNull] Expression right, [NotNull] Boolean liftToNull, [NotNull] MethodInfo method) {
            return Expression.GreaterThan(left, right, liftToNull, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "greater than or equal" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.GreaterThanOrEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The "greater than or equal" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression GreaterThanOrEqual([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.GreaterThanOrEqual(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "greater than or equal" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.GreaterThanOrEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to false.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the "greater than or equal" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression GreaterThanOrEqual([NotNull] this Expression left, [NotNull] Expression right, [NotNull] Boolean liftToNull, [NotNull] MethodInfo method) {
            return Expression.GreaterThanOrEqual(left, right, liftToNull, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.ConditionalExpression" /> that represents a conditional block with an if statement.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.ConditionalExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Conditional" /> and the <see cref="P:System.Linq.Expressions.ConditionalExpression.Test" />, <see cref="P:System.Linq.Expressions.ConditionalExpression.IfTrue" />, properties set to the specified values. The <see cref="P:System.Linq.Expressions.ConditionalExpression.IfFalse" /> property is set to default expression and the type of the resulting <see cref="T:System.Linq.Expressions.ConditionalExpression" /> returned by this method is <see cref="T:System.Void" />.</returns>
        /// <param name="test">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.ConditionalExpression.Test" /> property equal to.</param>
        /// <param name="ifTrue">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.ConditionalExpression.IfTrue" /> property equal to.</param>
        [Pure] [NotNull]
        public static ConditionalExpression IfThen([NotNull] this Expression test, [NotNull] Expression ifTrue) {
            return Expression.IfThen(test, ifTrue);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.ConditionalExpression" /> that represents a conditional block with if and else statements.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.ConditionalExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Conditional" /> and the <see cref="P:System.Linq.Expressions.ConditionalExpression.Test" />, <see cref="P:System.Linq.Expressions.ConditionalExpression.IfTrue" />, and <see cref="P:System.Linq.Expressions.ConditionalExpression.IfFalse" /> properties set to the specified values. The type of the resulting <see cref="T:System.Linq.Expressions.ConditionalExpression" /> returned by this method is <see cref="T:System.Void" />.</returns>
        /// <param name="test">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.ConditionalExpression.Test" /> property equal to.</param>
        /// <param name="ifTrue">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.ConditionalExpression.IfTrue" /> property equal to.</param>
        /// <param name="ifFalse">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.ConditionalExpression.IfFalse" /> property equal to.</param>
        [Pure] [NotNull]
        public static ConditionalExpression IfThenElse([NotNull] this Expression test, [NotNull] Expression ifTrue, [NotNull] Expression ifFalse) {
            return Expression.IfThenElse(test, ifTrue, ifFalse);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the incrementing of the expression value by 1.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the incremented expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to increment.</param>
        [Pure] [NotNull]
        public static UnaryExpression Increment([NotNull] this Expression expression) {
            return Expression.Increment(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the incrementing of the expression by 1.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the incremented expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to increment.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression Increment([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.Increment(expression, method);
        }
        #endif

        /// <summary>Creates an <see cref="T:System.Linq.Expressions.InvocationExpression" /> that applies a delegate or lambda expression to a list of argument expressions.</summary>
        /// <returns>An <see cref="T:System.Linq.Expressions.InvocationExpression" /> that applies the specified delegate or lambda expression to the provided arguments.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> that represents the delegate or lambda expression to be applied to.</param>
        /// <param name="arguments">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> that contains <see cref="T:System.Linq.Expressions.Expression" /> objects that represent the arguments that the delegate or lambda expression is applied to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="expression" />.Type does not represent a delegate type or an <see cref="T:System.Linq.Expressions.Expression`1" />.-or-The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of an element of <paramref name="arguments" /> is not assignable to the type of the corresponding parameter of the delegate represented by <paramref name="expression" />.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="arguments" /> does not contain the same number of elements as the list of parameters for the delegate represented by <paramref name="expression" />.</exception>
        [Pure] [NotNull]
        public static InvocationExpression Invoke([NotNull] this Expression expression, [NotNull] IEnumerable<Expression> arguments) {
            return Expression.Invoke(expression, arguments);
        }

        /// <summary>Creates an <see cref="T:System.Linq.Expressions.InvocationExpression" /> that applies a delegate or lambda expression to a list of argument expressions.</summary>
        /// <returns>An <see cref="T:System.Linq.Expressions.InvocationExpression" /> that applies the specified delegate or lambda expression to the provided arguments.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> that represents the delegate or lambda expression to be applied.</param>
        /// <param name="arguments">An array of <see cref="T:System.Linq.Expressions.Expression" /> objects that represent the arguments that the delegate or lambda expression is applied to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="expression" />.Type does not represent a delegate type or an <see cref="T:System.Linq.Expressions.Expression`1" />.-or-The <see cref="P:System.Linq.Expressions.Expression.Type" /> property of an element of <paramref name="arguments" /> is not assignable to the type of the corresponding parameter of the delegate represented by <paramref name="expression" />.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="arguments" /> does not contain the same number of elements as the list of parameters for the delegate represented by <paramref name="expression" />.</exception>
        [Pure] [NotNull]
        public static InvocationExpression Invoke([NotNull] this Expression expression, [NotNull] Expression[] arguments) {
            return Expression.Invoke(expression, arguments);
        }

        #if Net4_Expressions
        /// <summary>Returns whether the expression evaluates to false.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to evaluate.</param>
        [Pure] [NotNull]
        public static UnaryExpression IsFalse([NotNull] this Expression expression) {
            return Expression.IsFalse(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Returns whether the expression evaluates to false.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to evaluate.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression IsFalse([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.IsFalse(expression, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Returns whether the expression evaluates to true.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to evaluate.</param>
        [Pure] [NotNull]
        public static UnaryExpression IsTrue([NotNull] this Expression expression) {
            return Expression.IsTrue(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Returns whether the expression evaluates to true.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to evaluate.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression IsTrue([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.IsTrue(expression, method);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise left-shift operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LeftShift" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The left-shift operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression LeftShift([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.LeftShift(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise left-shift operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LeftShift" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the left-shift operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression LeftShift([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.LeftShift(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise left-shift assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LeftShiftAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression LeftShiftAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.LeftShiftAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise left-shift assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LeftShiftAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression LeftShiftAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.LeftShiftAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise left-shift assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LeftShiftAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression LeftShiftAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.LeftShiftAssign(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "less than" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LessThan" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The "less than" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression LessThan([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.LessThan(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "less than" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LessThan" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to false.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the "less than" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression LessThan([NotNull] this Expression left, [NotNull] Expression right, [NotNull] Boolean liftToNull, [NotNull] MethodInfo method) {
            return Expression.LessThan(left, right, liftToNull, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a " less than or equal" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LessThanOrEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The "less than or equal" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression LessThanOrEqual([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.LessThanOrEqual(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a "less than or equal" numeric comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.LessThanOrEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to false.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the "less than or equal" operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression LessThanOrEqual([NotNull] this Expression left, [NotNull] Expression right, [NotNull] Boolean liftToNull, [NotNull] MethodInfo method) {
            return Expression.LessThanOrEqual(left, right, liftToNull, method);
        }

        #if Net4_Expressions
        /// <summary>Creates an <see cref="T:System.Linq.Expressions.IndexExpression" /> that represents accessing an indexed property in an object.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.IndexExpression" />.</returns>
        /// <param name="instance">The object to which the property belongs. It should be null if the property is static (shared in Visual Basic).</param>
        /// <param name="indexer">An <see cref="T:System.Linq.Expressions.Expression" /> representing the property to index.</param>
        /// <param name="arguments">An IEnumerable&lt;Expression&gt; (IEnumerable (Of Expression) in Visual Basic) that contains the arguments that will be used to index the property.</param>
        [Pure] [NotNull]
        public static IndexExpression MakeIndex([NotNull] this Expression instance, [NotNull] PropertyInfo indexer, [NotNull] IEnumerable<Expression> arguments) {
            return Expression.MakeIndex(instance, indexer, arguments);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing either a field or a property.</summary>
        /// <returns>The <see cref="T:System.Linq.Expressions.MemberExpression" /> that results from calling the appropriate factory method.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> that represents the object that the member belongs to. This can be null for static members.</param>
        /// <param name="member">The <see cref="T:System.Reflection.MemberInfo" /> that describes the field or property to be accessed.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="member" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="member" /> does not represent a field or property.</exception>
        [Pure] [NotNull]
        public static MemberExpression MakeMemberAccess([NotNull] this Expression expression, [NotNull] MemberInfo member) {
            return Expression.MakeMemberAccess(expression, member);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic remainder operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Modulo" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The modulus operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Modulo([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Modulo(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic remainder operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Modulo" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the modulus operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Modulo([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Modulo(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a remainder assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ModuloAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ModuloAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.ModuloAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a remainder assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ModuloAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ModuloAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.ModuloAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a remainder assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.ModuloAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ModuloAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.ModuloAssign(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic multiplication operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Multiply" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The multiplication operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Multiply([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Multiply(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic multiplication operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Multiply" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the multiplication operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Multiply([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Multiply(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a multiplication assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.MultiplyAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a multiplication assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.MultiplyAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a multiplication assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.MultiplyAssign(left, right, method, conversion);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a multiplication assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyAssignChecked([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.MultiplyAssignChecked(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a multiplication assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyAssignChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.MultiplyAssignChecked(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a multiplication assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyAssignChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.MultiplyAssignChecked(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic multiplication operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The multiplication operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyChecked([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.MultiplyChecked(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic multiplication operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MultiplyChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the multiplication operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression MultiplyChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.MultiplyChecked(left, right, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an arithmetic negation operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Negate" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property set to the specified value.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The unary minus operator is not defined for <paramref name="expression" />.Type.</exception>
        [Pure] [NotNull]
        public static UnaryExpression Negate([NotNull] this Expression expression) {
            return Expression.Negate(expression);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an arithmetic negation operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Negate" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> and <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly one argument.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the unary minus operator is not defined for <paramref name="expression" />.Type.-or-<paramref name="expression" />.Type (or its corresponding non-nullable type if it is a nullable value type) is not assignable to the argument type of the method represented by <paramref name="method" />.</exception>
        [Pure] [NotNull]
        public static UnaryExpression Negate([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.Negate(expression, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an arithmetic negation operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.NegateChecked" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property set to the specified value.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The unary minus operator is not defined for <paramref name="expression" />.Type.</exception>
        [Pure] [NotNull]
        public static UnaryExpression NegateChecked([NotNull] this Expression expression) {
            return Expression.NegateChecked(expression);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an arithmetic negation operation that has overflow checking. The implementing method can be specified.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.NegateChecked" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> and <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly one argument.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the unary minus operator is not defined for <paramref name="expression" />.Type.-or-<paramref name="expression" />.Type (or its corresponding non-nullable type if it is a nullable value type) is not assignable to the argument type of the method represented by <paramref name="method" />.</exception>
        [Pure] [NotNull]
        public static UnaryExpression NegateChecked([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.NegateChecked(expression, method);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an inequality comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.NotEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The inequality operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression NotEqual([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.NotEqual(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an inequality comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.NotEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="liftToNull">true to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to true; false to set <see cref="P:System.Linq.Expressions.BinaryExpression.IsLiftedToNull" /> to false.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the inequality operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression NotEqual([NotNull] this Expression left, [NotNull] Expression right, [NotNull] Boolean liftToNull, [NotNull] MethodInfo method) {
            return Expression.NotEqual(left, right, liftToNull, method);
        }

        #if Net4_Expressions
        /// <summary>Returns the expression representing the ones complement.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" />.</param>
        [Pure] [NotNull]
        public static UnaryExpression OnesComplement([NotNull] this Expression expression) {
            return Expression.OnesComplement(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Returns the expression representing the ones complement.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" />.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression OnesComplement([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.OnesComplement(expression, method);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise OR operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Or" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The bitwise OR operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Or([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Or(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise OR operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Or" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the bitwise OR operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Or([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Or(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise OR assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.OrAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression OrAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.OrAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise OR assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.OrAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression OrAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.OrAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise OR assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.OrAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression OrAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.OrAssign(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a conditional OR operation that evaluates the second operand only if the first operand evaluates to false.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.OrElse" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The bitwise OR operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.-or-<paramref name="left" />.Type and <paramref name="right" />.Type are not the same Boolean type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression OrElse([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.OrElse(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a conditional OR operation that evaluates the second operand only if the first operand evaluates to false.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.OrElse" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the bitwise OR operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.-or-<paramref name="method" /> is null and <paramref name="left" />.Type and <paramref name="right" />.Type are not the same Boolean type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression OrElse([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.OrElse(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the assignment of the expression followed by a subsequent decrement by 1 of the original expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        [Pure] [NotNull]
        public static UnaryExpression PostDecrementAssign([NotNull] this Expression expression) {
            return Expression.PostDecrementAssign(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the assignment of the expression followed by a subsequent decrement by 1 of the original expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression PostDecrementAssign([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.PostDecrementAssign(expression, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the assignment of the expression followed by a subsequent increment by 1 of the original expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        [Pure] [NotNull]
        public static UnaryExpression PostIncrementAssign([NotNull] this Expression expression) {
            return Expression.PostIncrementAssign(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the assignment of the expression followed by a subsequent increment by 1 of the original expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression PostIncrementAssign([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.PostIncrementAssign(expression, method);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents raising a number to a power.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Power" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The exponentiation operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.-or-<paramref name="left" />.Type and/or <paramref name="right" />.Type are not <see cref="T:System.Double" />.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Power([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Power(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents raising a number to a power.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Power" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the exponentiation operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.-or-<paramref name="method" /> is null and <paramref name="left" />.Type and/or <paramref name="right" />.Type are not <see cref="T:System.Double" />.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Power([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Power(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents raising an expression to a power and assigning the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.PowerAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression PowerAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.PowerAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents raising an expression to a power and assigning the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.PowerAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression PowerAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.PowerAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents raising an expression to a power and assigning the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.PowerAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression PowerAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.PowerAssign(left, right, method, conversion);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that decrements the expression by 1 and assigns the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        [Pure] [NotNull]
        public static UnaryExpression PreDecrementAssign([NotNull] this Expression expression) {
            return Expression.PreDecrementAssign(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that decrements the expression by 1 and assigns the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression PreDecrementAssign([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.PreDecrementAssign(expression, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that increments the expression by 1 and assigns the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        [Pure] [NotNull]
        public static UnaryExpression PreIncrementAssign([NotNull] this Expression expression) {
            return Expression.PreIncrementAssign(expression);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that increments the expression by 1 and assigns the result back to the expression.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the resultant expression.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to apply the operations on.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> that represents the implementing method.</param>
        [Pure] [NotNull]
        public static UnaryExpression PreIncrementAssign([NotNull] this Expression expression, [NotNull] MethodInfo method) {
            return Expression.PreIncrementAssign(expression, method);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a property.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MemberExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess" />, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property set to <paramref name="expression" />, and the <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> property set to the <see cref="T:System.Reflection.PropertyInfo" /> that represents the property denoted by <paramref name="propertyName" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> whose <see cref="P:System.Linq.Expressions.Expression.Type" /> contains a property named <paramref name="propertyName" />. This can be null for static properties.</param>
        /// <param name="propertyName">The name of a property to be accessed.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="propertyName" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException">No property named <paramref name="propertyName" /> is defined in <paramref name="expression" />.Type or its base types.</exception>
        [Pure] [NotNull]
        public static MemberExpression Property([NotNull] this Expression expression, [NotNull] String propertyName) {
            return Expression.Property(expression, propertyName);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> accessing a property.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.MemberExpression" />.</returns>
        /// <param name="expression">The containing object of the property. This can be null for static properties.</param>
        /// <param name="type">The <see cref="P:System.Linq.Expressions.Expression.Type" /> that contains the property.</param>
        /// <param name="propertyName">The property to be accessed.</param>
        [Pure] [NotNull]
        public static MemberExpression Property([NotNull] this Expression expression, [NotNull] Type type, [NotNull] String propertyName) {
            return Expression.Property(expression, type, propertyName);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a property.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MemberExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess" /> and the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> and <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property equal to. This can be null for static properties.</param>
        /// <param name="property">The <see cref="T:System.Reflection.PropertyInfo" /> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="property" /> is null.-or-The property that <paramref name="property" /> represents is not static (Shared in Visual Basic) and <paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="expression" />.Type is not assignable to the declaring type of the property that <paramref name="property" /> represents.</exception>
        [Pure] [NotNull]
        public static MemberExpression Property([NotNull] this Expression expression, [NotNull] PropertyInfo property) {
            return Expression.Property(expression, property);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a property by using a property accessor method.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MemberExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess" />, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property set to <paramref name="expression" /> and the <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> property set to the <see cref="T:System.Reflection.PropertyInfo" /> that represents the property accessed in <paramref name="propertyAccessor" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property equal to. This can be null for static properties.</param>
        /// <param name="propertyAccessor">The <see cref="T:System.Reflection.MethodInfo" /> that represents a property accessor method.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="propertyAccessor" /> is null.-or-The method that <paramref name="propertyAccessor" /> represents is not static (Shared in Visual Basic) and <paramref name="expression" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="expression" />.Type is not assignable to the declaring type of the method represented by <paramref name="propertyAccessor" />.-or-The method that <paramref name="propertyAccessor" /> represents is not a property accessor method.</exception>
        [Pure] [NotNull]
        public static MemberExpression Property([NotNull] this Expression expression, [NotNull] MethodInfo propertyAccessor) {
            return Expression.Property(expression, propertyAccessor);
        }

        #if Net4_Expressions
        /// <summary>Creates an <see cref="T:System.Linq.Expressions.IndexExpression" /> representing the access to an indexed property.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.IndexExpression" />.</returns>
        /// <param name="instance">The object to which the property belongs. If the property is static/shared, it must be null.</param>
        /// <param name="propertyName">The name of the indexer.</param>
        /// <param name="arguments">An array of <see cref="T:System.Linq.Expressions.Expression" /> objects that are used to index the property.</param>
        [Pure] [NotNull]
        public static IndexExpression Property([NotNull] this Expression instance, [NotNull] String propertyName, [NotNull] Expression[] arguments) {
            return Expression.Property(instance, propertyName, arguments);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates an <see cref="T:System.Linq.Expressions.IndexExpression" /> representing the access to an indexed property.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.IndexExpression" />.</returns>
        /// <param name="instance">The object to which the property belongs. If the property is static/shared, it must be null.</param>
        /// <param name="indexer">The <see cref="T:System.Reflection.PropertyInfo" /> that represents the property to index.</param>
        /// <param name="arguments">An array of <see cref="T:System.Linq.Expressions.Expression" /> objects that are used to index the property.</param>
        [Pure] [NotNull]
        public static IndexExpression Property([NotNull] this Expression instance, [NotNull] PropertyInfo indexer, [NotNull] Expression[] arguments) {
            return Expression.Property(instance, indexer, arguments);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates an <see cref="T:System.Linq.Expressions.IndexExpression" /> representing the access to an indexed property.</summary>
        /// <returns>The created <see cref="T:System.Linq.Expressions.IndexExpression" />.</returns>
        /// <param name="instance">The object to which the property belongs. If the property is static/shared, it must be null.</param>
        /// <param name="indexer">The <see cref="T:System.Reflection.PropertyInfo" /> that represents the property to index.</param>
        /// <param name="arguments">An <see cref="T:System.Collections.Generic.IEnumerable`1" /> of <see cref="T:System.Linq.Expressions.Expression" /> objects that are used to index the property.</param>
        [Pure] [NotNull]
        public static IndexExpression Property([NotNull] this Expression instance, [NotNull] PropertyInfo indexer, [NotNull] IEnumerable<Expression> arguments) {
            return Expression.Property(instance, indexer, arguments);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.MemberExpression" /> that represents accessing a property or field.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.MemberExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.MemberAccess" />, the <see cref="P:System.Linq.Expressions.MemberExpression.Expression" /> property set to <paramref name="expression" />, and the <see cref="P:System.Linq.Expressions.MemberExpression.Member" /> property set to the <see cref="T:System.Reflection.PropertyInfo" /> or <see cref="T:System.Reflection.FieldInfo" /> that represents the property or field denoted by <paramref name="propertyOrFieldName" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> whose <see cref="P:System.Linq.Expressions.Expression.Type" /> contains a property or field named <paramref name="propertyOrFieldName" />. This can be null for static members.</param>
        /// <param name="propertyOrFieldName">The name of a property or field to be accessed.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="propertyOrFieldName" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException">No property or field named <paramref name="propertyOrFieldName" /> is defined in <paramref name="expression" />.Type or its base types.</exception>
        [Pure] [NotNull]
        public static MemberExpression PropertyOrField([NotNull] this Expression expression, [NotNull] String propertyOrFieldName) {
            return Expression.PropertyOrField(expression, propertyOrFieldName);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an expression that has a constant value of type <see cref="T:System.Linq.Expressions.Expression" />.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Quote" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property set to the specified value.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> is null.</exception>
        [Pure] [NotNull]
        public static UnaryExpression Quote([NotNull] this Expression expression) {
            return Expression.Quote(expression);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a reference equality comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Equal" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ReferenceEqual([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.ReferenceEqual(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a reference inequality comparison.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.NotEqual" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression ReferenceNotEqual([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.ReferenceNotEqual(left, right);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise right-shift operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.RightShift" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The right-shift operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression RightShift([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.RightShift(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise right-shift operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.RightShift" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the right-shift operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression RightShift([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.RightShift(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise right-shift assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.RightShiftAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression RightShiftAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.RightShiftAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise right-shift assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.RightShiftAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression RightShiftAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.RightShiftAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a bitwise right-shift assignment operation.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.RightShiftAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression RightShiftAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.RightShiftAssign(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic subtraction operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Subtract" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The subtraction operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Subtract([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.Subtract(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic subtraction operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.Subtract" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the subtraction operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression Subtract([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.Subtract(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a subtraction assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression SubtractAssign([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.SubtractAssign(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a subtraction assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression SubtractAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.SubtractAssign(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a subtraction assignment operation that does not have overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractAssign" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression SubtractAssign([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.SubtractAssign(left, right, method, conversion);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a subtraction assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression SubtractAssignChecked([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.SubtractAssignChecked(left, right);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a subtraction assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression SubtractAssignChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.SubtractAssignChecked(left, right, method);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents a subtraction assignment operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractAssignChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Method" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> properties set to the specified values.</returns>
        /// <param name="left">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <param name="conversion">A <see cref="T:System.Linq.Expressions.LambdaExpression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Conversion" /> property equal to.</param>
        [Pure] [NotNull]
        public static BinaryExpression SubtractAssignChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method, [NotNull] LambdaExpression conversion) {
            return Expression.SubtractAssignChecked(left, right, method, conversion);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic subtraction operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> and <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.InvalidOperationException">The subtraction operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression SubtractChecked([NotNull] this Expression left, [NotNull] Expression right) {
            return Expression.SubtractChecked(left, right);
        }

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.BinaryExpression" /> that represents an arithmetic subtraction operation that has overflow checking.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.BinaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.SubtractChecked" /> and the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" />, <see cref="P:System.Linq.Expressions.BinaryExpression.Right" />, and <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> properties set to the specified values.</returns>
        /// <param name="left">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Left" /> property equal to.</param>
        /// <param name="right">A <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Right" /> property equal to.</param>
        /// <param name="method">A <see cref="T:System.Reflection.MethodInfo" /> to set the <see cref="P:System.Linq.Expressions.BinaryExpression.Method" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="left" /> or <paramref name="right" /> is null.</exception>
        /// <exception cref="T:System.ArgumentException"><paramref name="method" /> is not null and the method it represents returns void, is not static (Shared in Visual Basic), or does not take exactly two arguments.</exception>
        /// <exception cref="T:System.InvalidOperationException"><paramref name="method" /> is null and the subtraction operator is not defined for <paramref name="left" />.Type and <paramref name="right" />.Type.</exception>
        [Pure] [NotNull]
        public static BinaryExpression SubtractChecked([NotNull] this Expression left, [NotNull] Expression right, [NotNull] MethodInfo method) {
            return Expression.SubtractChecked(left, right, method);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents a throwing of an exception.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the exception.</returns>
        /// <param name="value">An <see cref="T:System.Linq.Expressions.Expression" />.</param>
        [Pure] [NotNull]
        public static UnaryExpression Throw([NotNull] this Expression value) {
            return Expression.Throw(value);
        }
        #endif

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents a throwing of an exception with a given type.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents the exception.</returns>
        /// <param name="value">An <see cref="T:System.Linq.Expressions.Expression" />.</param>
        /// <param name="type">The new <see cref="T:System.Type" /> of the expression.</param>
        [Pure] [NotNull]
        public static UnaryExpression Throw([NotNull] this Expression value, [NotNull] Type type) {
            return Expression.Throw(value, type);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an explicit reference or boxing conversion where null is supplied if the conversion fails.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.UnaryExpression" /> that has the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property equal to <see cref="F:System.Linq.Expressions.ExpressionType.TypeAs" /> and the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> and <see cref="P:System.Linq.Expressions.Expression.Type" /> properties set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.UnaryExpression.Operand" /> property equal to.</param>
        /// <param name="type">A <see cref="T:System.Type" /> to set the <see cref="P:System.Linq.Expressions.Expression.Type" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="type" /> is null.</exception>
        [Pure] [NotNull]
        public static UnaryExpression TypeAs([NotNull] this Expression expression, [NotNull] Type type) {
            return Expression.TypeAs(expression, type);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.TypeBinaryExpression" /> that compares run-time type identity.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.TypeBinaryExpression" /> for which the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property is equal to <see cref="M:System.Linq.Expressions.Expression.TypeEqual(System.Linq.Expressions.Expression,System.Type)" /> and for which the <see cref="T:System.Linq.Expressions.Expression" /> and <see cref="P:System.Linq.Expressions.TypeBinaryExpression.TypeOperand" /> properties are set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="T:System.Linq.Expressions.Expression" /> property equal to.</param>
        /// <param name="type">A <see cref="P:System.Linq.Expressions.Expression.Type" /> to set the <see cref="P:System.Linq.Expressions.TypeBinaryExpression.TypeOperand" /> property equal to.</param>
        [Pure] [NotNull]
        public static TypeBinaryExpression TypeEqual([NotNull] this Expression expression, [NotNull] Type type) {
            return Expression.TypeEqual(expression, type);
        }
        #endif

        /// <summary>Creates a <see cref="T:System.Linq.Expressions.TypeBinaryExpression" />.</summary>
        /// <returns>A <see cref="T:System.Linq.Expressions.TypeBinaryExpression" /> for which the <see cref="P:System.Linq.Expressions.Expression.NodeType" /> property is equal to <see cref="F:System.Linq.Expressions.ExpressionType.TypeIs" /> and for which the <see cref="P:System.Linq.Expressions.TypeBinaryExpression.Expression" /> and <see cref="P:System.Linq.Expressions.TypeBinaryExpression.TypeOperand" /> properties are set to the specified values.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to set the <see cref="P:System.Linq.Expressions.TypeBinaryExpression.Expression" /> property equal to.</param>
        /// <param name="type">A <see cref="P:System.Linq.Expressions.Expression.Type" /> to set the <see cref="P:System.Linq.Expressions.TypeBinaryExpression.TypeOperand" /> property equal to.</param>
        /// <exception cref="T:System.ArgumentNullException"><paramref name="expression" /> or <paramref name="type" /> is null.</exception>
        [Pure] [NotNull]
        public static TypeBinaryExpression TypeIs([NotNull] this Expression expression, [NotNull] Type type) {
            return Expression.TypeIs(expression, type);
        }

        #if Net4_Expressions
        /// <summary>Creates a <see cref="T:System.Linq.Expressions.UnaryExpression" /> that represents an explicit unboxing.</summary>
        /// <returns>An instance of <see cref="T:System.Linq.Expressions.UnaryExpression" />.</returns>
        /// <param name="expression">An <see cref="T:System.Linq.Expressions.Expression" /> to unbox.</param>
        /// <param name="type">The new <see cref="T:System.Type" /> of the expression.</param>
        [Pure] [NotNull]
        public static UnaryExpression Unbox([NotNull] this Expression expression, [NotNull] Type type) {
            return Expression.Unbox(expression, type);
        }
        #endif
    }
}