using System;
using System.Collections.Generic;
using NUnit.Framework;
using tests.unit;

public delegate void it();

public delegate void because();

public delegate void context();

public delegate void after_all();

namespace tests
{
    public abstract class test
    {
        IDictionary<string, it> tests = new Dictionary<string, it>();
        static public IMockFactory mock_factory = new RhinoMockFactory();

        [TestFixtureSetUp]
        public virtual void initialize()
        {
            context();
            because();
            Console.Out.WriteLine();
            Console.Out.WriteLine(GetType().Name);
        }

        [Test]
        public void output()
        {
            GetType().run_all<it>(this);
            tests.each(test => test.run());
            GetType().run_single<after_all>(this);
        }

        protected void it(string should, it test)
        {
            tests[should] = test;
        }

        protected virtual void context()
        {
            GetType().run_stacked<context>(this);
        }

        protected virtual void because()
        {
            GetType().run_stacked<because>(this);
        }

        static protected T an<T>() where T : class
        {
            return mock_factory.create<T>();
        }

        static protected T dependency<T>() where T : class
        {
            return mock_factory.create<T>();
        }
    }
}