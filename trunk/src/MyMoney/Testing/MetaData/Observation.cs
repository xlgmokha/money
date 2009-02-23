using System;
using MbUnit.Core.Framework;

namespace MyMoney.Testing.MetaData
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class ObservationAttribute : TestPatternAttribute
    {
    }
}