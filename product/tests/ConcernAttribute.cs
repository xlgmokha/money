using System;
using NUnit.Framework;

namespace tests
{
    public class ConcernAttribute : TestFixtureAttribute
    {
        public Type SUT { get; set; }

        public ConcernAttribute(Type sut)
        {
            SUT = sut;
        }
    }
}