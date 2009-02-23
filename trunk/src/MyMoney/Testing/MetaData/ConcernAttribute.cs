using System;

namespace MyMoney.Testing.MetaData
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ConcernAttribute : Attribute
    {
        public ConcernAttribute(Type concern)
        {
            Concern = concern;
        }

        public Type Concern { get; private set; }
    }
}