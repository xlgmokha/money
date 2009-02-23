using System.Collections.Generic;
using System.IO;
using Db4objects.Db4o;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Utility.Extensions;

namespace MyMoney.DataAccess.db40.spiking
{
    public class db40_spike_specs
    {}

    [Concern(typeof(Db4oFactory))]
    public class when_opening_an_existing_database_ : context_specification
    {
        public override void before_each_observation()
        {
            the_database_file = Path.GetTempFileName();
            database = Db4oFactory.OpenFile(the_database_file);
            base.before_each_observation();
        }

        protected override void context()
        {
            original = new TestObject(88, "mo");
            database.Store(original);
        }

        protected override void because()
        {
            database.Close();
            database.Dispose();
            database = Db4oFactory.OpenFile(the_database_file);
            results = database.Query<ITestObject>().databind();
        }

        [Observation]
        public void it_should_be_able_to_load_the_original_contents()
        {
            results.should_contain(original);
        }

        [Observation]
        public void they_should_be_equal()
        {
            new TestObject(99, "gretzky").Equals(new TestObject(99, "gretzky"));
        }

        [Observation]
        public void it_should_only_contain_the_original_item()
        {
            results.Count.should_be_equal_to(1);
        }

        public override void after_each_observation()
        {
            database.Close();
            database.Dispose();
        }

        private ITestObject original;
        private string the_database_file;
        private IList<ITestObject> results;
        private IObjectContainer database;
    }

    public interface ITestObject
    {
        int Id { get; }
        string Name { get; }
    }

    public class TestObject : ITestObject
    {
        public TestObject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }

        public bool Equals(TestObject obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.Id == Id && Equals(obj.Name, Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (TestObject)) return false;
            return Equals((TestObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked {
                return (Id*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}