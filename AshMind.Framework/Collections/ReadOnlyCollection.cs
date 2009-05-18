using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AshMind.Framework.Collections {
    [Serializable]
    public class ReadOnlyCollection<T> : IList<T>, IList {
        private readonly IList<T> innerList;
        
        public ReadOnlyCollection(IList<T> list) {
            this.innerList = list;
        }

        protected virtual IList<T> InnerList {
            get { return this.innerList; }
        }

        public bool Contains(T value) {
            return this.InnerList.Contains(value);
        }

        public void CopyTo(T[] array, int index) {
            this.InnerList.CopyTo(array, index);
        }

        public IEnumerator<T> GetEnumerator() {
            return this.InnerList.GetEnumerator();
        }

        public int IndexOf(T value) {
            return this.InnerList.IndexOf(value);
        }

        void ICollection<T>.Add(T value) {
            throw new NotSupportedException();
        }

        void ICollection<T>.Clear() {
            throw new NotSupportedException();
        }

        bool ICollection<T>.Remove(T value) {
            throw new NotSupportedException();
        }

        void IList<T>.Insert(int index, T value) {
            throw new NotSupportedException();
        }

        void IList<T>.RemoveAt(int index) {
            throw new NotSupportedException();
        }

        void ICollection.CopyTo(Array array, int index) {
            ((ICollection)this.InnerList).CopyTo(array, index);
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return this.InnerList.GetEnumerator();
        }

        int IList.Add(object value) {
            throw new NotSupportedException();
        }

        void IList.Clear() {
            throw new NotSupportedException();
        }

        bool IList.Contains(object value) {
            return this.Contains((T)value);
        }

        int IList.IndexOf(object value) {
            return this.IndexOf((T)value);
        }

        void IList.Insert(int index, object value) {
            throw new NotSupportedException();
        }

        void IList.Remove(object value) {
            throw new NotSupportedException();
        }

        void IList.RemoveAt(int index) {
            throw new NotSupportedException();
        }

        public int Count {
            get { return this.InnerList.Count; }
        }

        public T this[int index] {
            get { return this.InnerList[index]; }
        }

        bool ICollection<T>.IsReadOnly {
            get { return true; }
        }

        T IList<T>.this[int index] {
            get { return this.InnerList[index]; }
            set { throw new NotSupportedException(); }
        }

        bool ICollection.IsSynchronized {
            get { return false; }
        }

        object ICollection.SyncRoot {
            get { return ((ICollection)this.InnerList).SyncRoot; }
        }

        bool IList.IsFixedSize {
            get { return true; }
        }

        bool IList.IsReadOnly {
            get { return true; }
        }

        object IList.this[int index] {
            get { return this.InnerList[index]; }
            set { throw new NotSupportedException(); }
        }
    }
}