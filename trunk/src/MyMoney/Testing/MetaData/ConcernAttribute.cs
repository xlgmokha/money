using System;

namespace MyMoney.Testing.MetaData
{
    public class ConcernAttribute : bdddoc.core.ConcernAttribute
    {
        public ConcernAttribute(Type concern) : base(concern)
        {
        }
    }
}