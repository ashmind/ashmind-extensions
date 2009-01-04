using System;
using System.Linq;

using AshMind.Constructs.Interfaces;

namespace AshMind.Constructs
{
    public static partial class Switch
    {
        #region CaseReceiver<TBase> Class

        private class CaseReceiver<TBase, TResult> : ISwitchCaseOrTo<TBase>, ISwitchCaseOrOtherwise<TBase>, ISwitchCaseOrOtherwiseWithResult<TBase, TResult>
            where TBase : class
        {
            private readonly TBase m_object;
            private bool m_matched;
            private TResult m_result;

            public CaseReceiver(TBase @object)
            {
                m_object = @object;
            }

            private TCase Try<TCase>()
                where TCase : class, TBase
            {
                if (m_matched)
                    return null;

                var cast = m_object as TCase;
                if (cast != null)
                    m_matched = true;

                return cast;
            }

            #region ISwitchCase<TBase> Members

            public ISwitchCaseOrOtherwise<TBase> Case<TCase>(Action<TCase> action)
                where TCase : class, TBase
            {
                var cast = this.Try<TCase>();
                if (cast != null)
                    action(cast);

                return this;
            }

            public ISwitchCaseWithResult<TBase, TResult2> Case<TCase, TResult2>(Func<TCase, TResult2> func)
                where TCase : class, TBase
            {
                return this.To<TResult2>().Case(func);
            }

            public ISwitchCaseWithResult<TBase, TResult2> To<TResult2>()
            {
                return new CaseReceiver<TBase, TResult2>(m_object);
            }

            #endregion

            #region ISwitchCaseWithResult<TBase,TResult> Members

            public ISwitchCaseOrOtherwiseWithResult<TBase, TResult> Case<TCase>(Func<TCase, TResult> func)
                where TCase : class, TBase
            {
                var cast = this.Try<TCase>();
                if (cast != null)
                    m_result = func(cast);

                return this;
            }

            public ISwitchCaseOrOtherwiseWithResult<TBase, TResult> Case<TCase>(TResult result)
                where TCase : class, TBase
            {
                var cast = this.Try<TCase>();
                if (cast != null)
                    m_result = result;

                return this;
            }

            #endregion

            #region IWithResult<TResult> Members

            public TResult Result
            {
                get { return m_result; }
            }

            #endregion

            #region ISwitchCaseOrOtherwise<TBase> Members

            public void Otherwise(Action<TBase> action) {
                if (m_matched)
                    return;

                action(m_object);
            }

            public void Otherwise(Action action) {
                if (m_matched)
                    return;

                action();
            }

            #endregion

            #region ISwitchCaseOrOtherwiseWithResult<TBase,TResult> Members

            public IWithResult<TResult> Otherwise(Func<TBase, TResult> func) {
                if (m_matched)
                    return this;

                m_result = func(m_object);
                return this;
            }

            public IWithResult<TResult> Otherwise(TResult result) {
                if (m_matched)
                    return this;

                m_result = result;
                return this;
            }

            #endregion

            #region IOtherwiseThrow Members

            public void OtherwiseThrow<TException>() 
                where TException : Exception, new()
            {
                throw new TException();
            }

            public void OtherwiseOutOfRange(string argumentName) {
                throw new ArgumentOutOfRangeException(argumentName);
            }

            #endregion
        }

        #endregion

        public static ISwitchCase<T> Type<T>(T value)
            where T : class
        {
            return new CaseReceiver<T, object>(value);
        }
    }
}
