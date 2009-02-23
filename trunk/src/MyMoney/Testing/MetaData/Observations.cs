using System;
using MbUnit.Core.Framework;
using MbUnit.Core.Runs;
using MbUnit.Framework;

namespace MyMoney.Testing.MetaData
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class Observations : TestFixturePatternAttribute
    {
        public override IRun GetRun()
        {
            var run = new SequenceRun();
            run.Runs.Add(new OptionalMethodRun(typeof (SetUpAttribute), false));
            run.Runs.Add(new MethodRun(typeof (ObservationAttribute), true, true));
            run.Runs.Add(new OptionalMethodRun(typeof (TearDownAttribute), false));
            return run;
        }
    }
}