using System;

namespace tests
{
    public class ConcernAttribute : bdddoc.core.ConcernAttribute
    {
        public ConcernAttribute(Type concern) : base(concern)
        {
        }
    }
}