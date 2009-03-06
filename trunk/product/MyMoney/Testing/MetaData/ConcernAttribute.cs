using System;

namespace MoMoney.Testing.MetaData
{
    public class ConcernAttribute : bdddoc.core.ConcernAttribute
    {
        public ConcernAttribute(Type concern) : base(concern)
        {
        }
    }
}