## ArrayExtensions

    int IndexOf<T>(this T[] array, T value)

    int IndexOf<T>(this T[] array, T value, int startIndex)

    int IndexOf<T>(this T[] array, T value, int startIndex, int count)

    int LastIndexOf<T>(this T[] array, T value)

    int LastIndexOf<T>(this T[] array, T value, int startIndex)

    int LastIndexOf<T>(this T[] array, T value, int startIndex, int count)

    void Reverse<T>(this T[] array)

    void Reverse<T>(this T[] array, int index, int length)

    void Sort<T>(this T[] array)

    void Sort<T>(this T[] array, Comparison<T> comparison)

    void Sort<T>(this T[] array, IComparer<T> comparer)

    void Sort<T>(this T[] array, int index, int length)

    void Sort<T>(this T[] array, int index, int length, IComparer<T> comparer)


## CharExtensions

    bool IsControl(this char c)

    bool IsDigit(this char c)

    bool IsHighSurrogate(this char c)

    bool IsLetter(this char c)

    bool IsLetterOrDigit(this char c)

    bool IsLower(this char c)

    bool IsLowSurrogate(this char c)

    bool IsNumber(this char c)

    bool IsPunctuation(this char c)

    bool IsSeparator(this char c)

    bool IsSurrogate(this char c)

    bool IsSymbol(this char c)

    bool IsUpper(this char c)

    bool IsWhiteSpace(this char c)

    char ToLower(this char c)

    char ToLower(this char c, CultureInfo culture)

    char ToLowerInvariant(this char c)

    char ToUpper(this char c)

    char ToUpper(this char c, CultureInfo culture)

    char ToUpperInvariant(this char c)


## CollectionExtensions

    void AddRange<T>(this ICollection<T> collection, IEnumerable<T> values)

    void RemoveAll<T>(this ICollection<T> collection, IEnumerable<T> values)

    int RemoveWhere<T>(this ICollection<T> collection, Func<T, bool> predicate)

    int RemoveWhere<T>(this ICollection<T> collection, Func<T, int, bool> predicate)


## ComparableExtensions

    bool IsBetween<TComparable, T>(this TComparable value, T left, T right)

    bool IsGreaterThan<TComparable, T>(this TComparable left, T right)

    bool IsGreaterThanOrEqual<TComparable, T>(this TComparable left, T right)

    bool IsLesserThan<TComparable, T>(this TComparable left, T right)

    bool IsLesserThanOrEqual<TComparable, T>(this TComparable left, T right)


## DelegateExtensions

    Comparison<T> AsComparison<T>(this Func<T, T, int> function)

    Func<T, bool> AsFunction<T>(this Predicate<T> predicate)

    Func<T, T, int> AsFunction<T>(this Comparison<T> comparison)

    Predicate<T> AsPredicate<T>(this Func<T, bool> function)

    IComparer<T> ToComparer<T>(this Comparison<T> comparison)

    IComparer<T> ToComparer<T>(this Func<T, T, int> function)


## DictionaryExtensions

    ReadOnlyDictionary<TKey, TValue> AsReadOnly<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)

    TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)

    TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> valueFactory)

    TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)

    TDefault GetValueOrDefault<TKey, TValue, TDefault>(this IDictionary<TKey, TValue> dictionary, TKey key, TDefault default)

    TValue GetValueOrDefault<TKey, TValue>(this IReadOnlyDictionary<TKey, TValue> dictionary, TKey key)


## DoubleExtensions

    bool IsInfinity(this Double value)

    bool IsNaN(this Double value)

    bool IsNegativeInfinity(this Double value)

    bool IsPositiveInfinity(this Double value)


## EnumerableExtensions

    bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)

    ICollection<TElement> AsCollection<TElement>(this IEnumerable<TElement> source)

    IList<TElement> AsList<TElement>(this IEnumerable<TElement> source)

    IReadOnlyCollection<TElement> AsReadOnlyCollection<TElement>(this IEnumerable<TElement> source)

    IReadOnlyList<TElement> AsReadOnlyList<TElement>(this IEnumerable<TElement> source)

    IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> source, TSource item)

    IEnumerable<TSource> EmptyIfNull<TSource>(this IEnumerable<TSource> source)

    IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> source, TSource item)

    void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)

    void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)

    IEnumerable<IGrouping<TKey, TSource>> GroupAdjacentBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)

    IEnumerable<IGrouping<TKey, TSource>> GroupAdjacentBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)

    IEnumerable<IGrouping<TKey, TElement>> GroupAdjacentBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector)

    IEnumerable<IGrouping<TKey, TElement>> GroupAdjacentBy<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)

    IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector)

    IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector)

    IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TKey, IEnumerable<TSource>, TResult> resultSelector, IEqualityComparer<TKey> comparer)

    IEnumerable<TResult> GroupAdjacentBy<TSource, TKey, TElement, TResult>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, Func<TKey, IEnumerable<TElement>, TResult> resultSelector, IEqualityComparer<TKey> comparer)

    IEnumerable<TSource> HavingMax<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)

    IEnumerable<TSource> HavingMin<TSource, TValue>(this IEnumerable<TSource> source, Func<TSource, TValue> selector)

    IEnumerable<TSource> OnAfterEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)

    IEnumerable<TSource> OnAfterEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)

    IEnumerable<TSource> OnAfterLast<TSource>(this IEnumerable<TSource> source, Action<TSource> action)

    IEnumerable<TSource> OnBeforeEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)

    IEnumerable<TSource> OnBeforeEach<TSource>(this IEnumerable<TSource> source, Action<TSource, int> action)

    IEnumerable<TSource> OnBeforeFirst<TSource>(this IEnumerable<TSource> source, Action<TSource> action)

    HashSet<TSource> ToSet<TSource>(this IEnumerable<TSource> source)

    HashSet<TSource> ToSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)


## ExpressionExtensions

    BinaryExpression Add(this Expression left, Expression right)

    BinaryExpression Add(this Expression left, Expression right, MethodInfo method)

    BinaryExpression AddAssign(this Expression left, Expression right)

    BinaryExpression AddAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression AddAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression AddAssignChecked(this Expression left, Expression right)

    BinaryExpression AddAssignChecked(this Expression left, Expression right, MethodInfo method)

    BinaryExpression AddAssignChecked(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression AddChecked(this Expression left, Expression right)

    BinaryExpression AddChecked(this Expression left, Expression right, MethodInfo method)

    BinaryExpression And(this Expression left, Expression right)

    BinaryExpression And(this Expression left, Expression right, MethodInfo method)

    BinaryExpression AndAlso(this Expression left, Expression right)

    BinaryExpression AndAlso(this Expression left, Expression right, MethodInfo method)

    BinaryExpression AndAssign(this Expression left, Expression right)

    BinaryExpression AndAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression AndAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    IndexExpression ArrayAccess(this Expression array, Expression[] indexes)

    IndexExpression ArrayAccess(this Expression array, IEnumerable<Expression> indexes)

    MethodCallExpression ArrayIndex(this Expression array, Expression[] indexes)

    MethodCallExpression ArrayIndex(this Expression array, IEnumerable<Expression> indexes)

    BinaryExpression ArrayIndex(this Expression array, Expression index)

    UnaryExpression ArrayLength(this Expression array)

    BinaryExpression Assign(this Expression left, Expression right)

    MethodCallExpression Call(this Expression instance, MethodInfo method)

    MethodCallExpression Call(this Expression instance, MethodInfo method, Expression[] arguments)

    MethodCallExpression Call(this Expression instance, MethodInfo method, Expression arg0, Expression arg1)

    MethodCallExpression Call(this Expression instance, MethodInfo method, Expression arg0, Expression arg1, Expression arg2)

    MethodCallExpression Call(this Expression instance, string methodName, Type[] typeArguments, Expression[] arguments)

    MethodCallExpression Call(this Expression instance, MethodInfo method, IEnumerable<Expression> arguments)

    BinaryExpression Coalesce(this Expression left, Expression right)

    BinaryExpression Coalesce(this Expression left, Expression right, LambdaExpression conversion)

    UnaryExpression Convert(this Expression expression, Type type)

    UnaryExpression Convert(this Expression expression, Type type, MethodInfo method)

    UnaryExpression ConvertChecked(this Expression expression, Type type)

    UnaryExpression ConvertChecked(this Expression expression, Type type, MethodInfo method)

    UnaryExpression Decrement(this Expression expression)

    UnaryExpression Decrement(this Expression expression, MethodInfo method)

    BinaryExpression Divide(this Expression left, Expression right)

    BinaryExpression Divide(this Expression left, Expression right, MethodInfo method)

    BinaryExpression DivideAssign(this Expression left, Expression right)

    BinaryExpression DivideAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression DivideAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression Equal(this Expression left, Expression right)

    BinaryExpression Equal(this Expression left, Expression right, bool liftToNull, MethodInfo method)

    BinaryExpression ExclusiveOr(this Expression left, Expression right, MethodInfo method)

    BinaryExpression ExclusiveOr(this Expression left, Expression right)

    BinaryExpression ExclusiveOrAssign(this Expression left, Expression right)

    BinaryExpression ExclusiveOrAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression ExclusiveOrAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    MemberExpression Field(this Expression expression, FieldInfo field)

    MemberExpression Field(this Expression expression, string fieldName)

    MemberExpression Field(this Expression expression, Type type, string fieldName)

    BinaryExpression GreaterThan(this Expression left, Expression right)

    BinaryExpression GreaterThan(this Expression left, Expression right, bool liftToNull, MethodInfo method)

    BinaryExpression GreaterThanOrEqual(this Expression left, Expression right)

    BinaryExpression GreaterThanOrEqual(this Expression left, Expression right, bool liftToNull, MethodInfo method)

    ConditionalExpression IfThen(this Expression test, Expression ifTrue)

    ConditionalExpression IfThenElse(this Expression test, Expression ifTrue, Expression ifFalse)

    UnaryExpression Increment(this Expression expression)

    UnaryExpression Increment(this Expression expression, MethodInfo method)

    InvocationExpression Invoke(this Expression expression, IEnumerable<Expression> arguments)

    InvocationExpression Invoke(this Expression expression, Expression[] arguments)

    UnaryExpression IsFalse(this Expression expression)

    UnaryExpression IsFalse(this Expression expression, MethodInfo method)

    UnaryExpression IsTrue(this Expression expression)

    UnaryExpression IsTrue(this Expression expression, MethodInfo method)

    BinaryExpression LeftShift(this Expression left, Expression right)

    BinaryExpression LeftShift(this Expression left, Expression right, MethodInfo method)

    BinaryExpression LeftShiftAssign(this Expression left, Expression right)

    BinaryExpression LeftShiftAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression LeftShiftAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression LessThan(this Expression left, Expression right)

    BinaryExpression LessThan(this Expression left, Expression right, bool liftToNull, MethodInfo method)

    BinaryExpression LessThanOrEqual(this Expression left, Expression right)

    BinaryExpression LessThanOrEqual(this Expression left, Expression right, bool liftToNull, MethodInfo method)

    IndexExpression MakeIndex(this Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments)

    MemberExpression MakeMemberAccess(this Expression expression, MemberInfo member)

    BinaryExpression Modulo(this Expression left, Expression right)

    BinaryExpression Modulo(this Expression left, Expression right, MethodInfo method)

    BinaryExpression ModuloAssign(this Expression left, Expression right)

    BinaryExpression ModuloAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression ModuloAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression Multiply(this Expression left, Expression right)

    BinaryExpression Multiply(this Expression left, Expression right, MethodInfo method)

    BinaryExpression MultiplyAssign(this Expression left, Expression right)

    BinaryExpression MultiplyAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression MultiplyAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression MultiplyAssignChecked(this Expression left, Expression right)

    BinaryExpression MultiplyAssignChecked(this Expression left, Expression right, MethodInfo method)

    BinaryExpression MultiplyAssignChecked(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression MultiplyChecked(this Expression left, Expression right)

    BinaryExpression MultiplyChecked(this Expression left, Expression right, MethodInfo method)

    UnaryExpression Negate(this Expression expression)

    UnaryExpression Negate(this Expression expression, MethodInfo method)

    UnaryExpression NegateChecked(this Expression expression)

    UnaryExpression NegateChecked(this Expression expression, MethodInfo method)

    BinaryExpression NotEqual(this Expression left, Expression right)

    BinaryExpression NotEqual(this Expression left, Expression right, bool liftToNull, MethodInfo method)

    UnaryExpression OnesComplement(this Expression expression)

    UnaryExpression OnesComplement(this Expression expression, MethodInfo method)

    BinaryExpression Or(this Expression left, Expression right)

    BinaryExpression Or(this Expression left, Expression right, MethodInfo method)

    BinaryExpression OrAssign(this Expression left, Expression right)

    BinaryExpression OrAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression OrAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression OrElse(this Expression left, Expression right)

    BinaryExpression OrElse(this Expression left, Expression right, MethodInfo method)

    UnaryExpression PostDecrementAssign(this Expression expression)

    UnaryExpression PostDecrementAssign(this Expression expression, MethodInfo method)

    UnaryExpression PostIncrementAssign(this Expression expression)

    UnaryExpression PostIncrementAssign(this Expression expression, MethodInfo method)

    BinaryExpression Power(this Expression left, Expression right)

    BinaryExpression Power(this Expression left, Expression right, MethodInfo method)

    BinaryExpression PowerAssign(this Expression left, Expression right)

    BinaryExpression PowerAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression PowerAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    UnaryExpression PreDecrementAssign(this Expression expression)

    UnaryExpression PreDecrementAssign(this Expression expression, MethodInfo method)

    UnaryExpression PreIncrementAssign(this Expression expression)

    UnaryExpression PreIncrementAssign(this Expression expression, MethodInfo method)

    MemberExpression Property(this Expression expression, string propertyName)

    MemberExpression Property(this Expression expression, Type type, string propertyName)

    MemberExpression Property(this Expression expression, PropertyInfo property)

    MemberExpression Property(this Expression expression, MethodInfo propertyAccessor)

    IndexExpression Property(this Expression instance, string propertyName, Expression[] arguments)

    IndexExpression Property(this Expression instance, PropertyInfo indexer, Expression[] arguments)

    IndexExpression Property(this Expression instance, PropertyInfo indexer, IEnumerable<Expression> arguments)

    MemberExpression PropertyOrField(this Expression expression, string propertyOrFieldName)

    UnaryExpression Quote(this Expression expression)

    BinaryExpression ReferenceEqual(this Expression left, Expression right)

    BinaryExpression ReferenceNotEqual(this Expression left, Expression right)

    BinaryExpression RightShift(this Expression left, Expression right)

    BinaryExpression RightShift(this Expression left, Expression right, MethodInfo method)

    BinaryExpression RightShiftAssign(this Expression left, Expression right)

    BinaryExpression RightShiftAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression RightShiftAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression Subtract(this Expression left, Expression right)

    BinaryExpression Subtract(this Expression left, Expression right, MethodInfo method)

    BinaryExpression SubtractAssign(this Expression left, Expression right)

    BinaryExpression SubtractAssign(this Expression left, Expression right, MethodInfo method)

    BinaryExpression SubtractAssign(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression SubtractAssignChecked(this Expression left, Expression right)

    BinaryExpression SubtractAssignChecked(this Expression left, Expression right, MethodInfo method)

    BinaryExpression SubtractAssignChecked(this Expression left, Expression right, MethodInfo method, LambdaExpression conversion)

    BinaryExpression SubtractChecked(this Expression left, Expression right)

    BinaryExpression SubtractChecked(this Expression left, Expression right, MethodInfo method)

    UnaryExpression Throw(this Expression value)

    UnaryExpression Throw(this Expression value, Type type)

    UnaryExpression TypeAs(this Expression expression, Type type)

    TypeBinaryExpression TypeEqual(this Expression expression, Type type)

    TypeBinaryExpression TypeIs(this Expression expression, Type type)

    UnaryExpression Unbox(this Expression expression, Type type)


## FormattableExtensions

    string ToInvariantString(this IFormattable value)

    string ToString(this IFormattable value, IFormatProvider provider)


## Int32Extensions

    bool IsBetween(this int value, int left, int right)

    void Times(this int count, Action action)

    void Times(this int count, Action<int> action)

    T[] Times<T>(this int count, Func<T> func)

    T[] Times<T>(this int count, Func<int, T> func)


## ListExtensions

    ReadOnlyCollection<T> AsReadOnly<T>(this IList<T> list)

    IEnumerable<T> EnumerateRange<T>(this IList<T> list, int index, int count)

    IEnumerable<T> EnumerateRange<T>(this IReadOnlyList<T> list, int index, int count)

    void InsertRange<T>(this IList<T> list, int index, IEnumerable<T> collection)

    void RemoveRange<T>(this IList<T> list, int index, int count)


## ReflectionExtensions

    TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider, bool inherit)

    TAttribute GetCustomAttribute<TAttribute>(this ICustomAttributeProvider provider)

    TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider member, bool inherit)

    TAttribute[] GetCustomAttributes<TAttribute>(this ICustomAttributeProvider provider)

    Object[] GetCustomAttributes(this ICustomAttributeProvider provider, Type attributeType)

    Object[] GetCustomAttributes(this ICustomAttributeProvider provider)

    object GetValue(this PropertyInfo property, object obj)

    bool HasInterface<TInterface>(this Type type)

    bool HasInterface(this Type type, Type interfaceType)

    bool IsDefined<TAttribute>(this ICustomAttributeProvider provider, bool inherit)

    bool IsGenericTypeDefinedAs(this Type type, Type otherType)

    bool IsSameAsOrSubclassOf(this Type type, Type otherType)

    bool IsSameAsOrSubclassOf<TClass>(this Type type)

    bool IsSubclassOf<T>(this Type type)

    void SetValue(this PropertyInfo property, object obj, object value)


## StringExtensions

    bool Contains(this string original, string value, StringComparison comparisonType)

    bool IsNotNullOrEmpty(this string value)

    bool IsNullOrEmpty(this string value)

    bool IsNullOrWhiteSpace(this string value)

    string NullIfEmpty(this string value)

    string RemoveEnd(this string original, string suffix)

    string RemoveStart(this string original, string prefix)

    String[] Split(this string value, string separator)

    String[] Split(this string value, String[] separator)

    String[] Split(this string value, string separator, StringSplitOptions options)

    string SubstringAfter(this string original, string value)

    string SubstringAfter(this string original, string value, StringComparison comparisonType)

    string SubstringAfterLast(this string original, string value)

    string SubstringAfterLast(this string original, string value, StringComparison comparisonType)

    string SubstringBefore(this string original, string value)

    string SubstringBefore(this string original, string value, StringComparison comparisonType)

    string SubstringBeforeLast(this string original, string value)

    string SubstringBeforeLast(this string original, string value, StringComparison comparisonType)


## TimeExtensions

    DateTime Ago(this TimeSpan value)

    TimeSpan Days(this Double value)

    TimeSpan Days(this int value)

    TimeSpan Hours(this Double value)

    TimeSpan Hours(this int value)

    TimeSpan Milliseconds(this Double value)

    TimeSpan Milliseconds(this int value)

    TimeSpan Minute(this int value)

    TimeSpan Minutes(this Double value)

    TimeSpan Minutes(this int value)

    TimeSpan Seconds(this Double value)

    TimeSpan Seconds(this int value)


