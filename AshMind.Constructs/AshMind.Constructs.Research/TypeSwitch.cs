using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AshMind.Constructs.Research
{
    public struct TypeSwitch<TBase, TResult> : IEnumerable
        where TBase : class
    {
        private bool m_matched;
        private object m_value;
        private TResult m_result;

        public TypeSwitch(object value)
        {
            m_value = value;
            m_matched = false;
            m_result = default(TResult);
        }

        public void Add<TCase>(Func<TCase, TResult> func)
            where TCase : class, TBase
        {
            if (m_matched)
                return;

            TCase cast = m_value as TCase;
            if (cast != null)
            {
                m_result = func(cast);
                m_matched = true;
            }
        }

        public void Add(Func<TBase, TResult> func)
        {
            this.Add<TBase>(func);
        }

        public static implicit operator TResult(TypeSwitch<TBase, TResult> typeSwitch) {
            return typeSwitch.m_result;
        }

        #region IEnumerable Members

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
