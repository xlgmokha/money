using System;
using System.Data;
using Gorilla.Commons.Utility;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace presentation.windows.orm.mappings
{
    public class DateUserType : IUserType
    {
        public bool Equals(object x, object y)
        {
            return x != null && x.Equals(y);
        }

        public int GetHashCode(object x)
        {
            return x.GetHashCode();
        }

        public object NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var date = (DateTime) NHibernateUtil.DateTime.NullSafeGet(rs, names);
            return new Date(date.Year, date.Month, date.Day);
        }

        public void NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var date = value as Date;
            NHibernateUtil.DateTime.NullSafeSet(cmd, date.to_date_time(), index);
        }

        public object DeepCopy(object value)
        {
            return value;
        }

        public object Replace(object original, object target, object owner)
        {
            return original;
        }

        public object Assemble(object cached, object owner)
        {
            return cached;
        }

        public object Disassemble(object value)
        {
            return value;
        }

        public SqlType[] SqlTypes
        {
            get { return new[] {NHibernateUtil.DateTime.SqlType}; }
        }

        public Type ReturnedType
        {
            get { return typeof (Date); }
        }

        public bool IsMutable
        {
            get { return true; }
        }
    }
}