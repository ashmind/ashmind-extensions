using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AshMind.Constructs.Research.ObjectModel;

namespace AshMind.Constructs.Research
{
    public static class Switch3
    {
        public static S3A<T> Type<T>(T value) {
            return new S3A<T>(value);
        }
    }

    public class S3A<T> {
        private T m_value;

        public S3A(T value) {
            m_value = value;
        }

        public static S3A<T> operator |(S3A<T> left, Action<T> right) {
            return left;
        }
    }

    //public class S3A<TR> {
    //    //public static S3A<TR> operator |(S3A<TR> left, S3A<TR> right) {
    //    //    return right;
    //    //}

    //    //public static S3A<TR> operator |(S3A<TR> left, Func<TR> right) {
    //    //    return left;
    //    //}

    //    //public static implicit operator S3A<TR>(Delegate value) {
    //    //    return value;
    //    //}

    //    public static S3A<TR> operator |(S3A<TR> left, Delegate right) {
    //        return left;
    //    }
    //}

    //public class S3B<TC, TR> : S3A<TR> {
    //    public static implicit operator S3B<TC, TR>(Func<TC, TR> func) {
    //        return new S3B<TC, TR>();
    //    }
    //}

    public class S3Test {
        public static void TestCompile() {
            var test = Switch3.Type<XmlDocument>(new XsltDocument());
            //test = test | ((XsltDocument doc) => { });
        }
    }
}
