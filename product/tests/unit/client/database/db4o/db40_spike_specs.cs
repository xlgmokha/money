using System.Collections.Generic;
using System.IO;
using Db4objects.Db4o;
using gorilla.commons.utility;

namespace tests.unit.client.database.db4o
{
    [Concern(typeof (Db4oFactory))]
    public class when_opening_an_existing_database_ : concerns
    {
        context c = () =>
        {
            original = new TestObject(88, "mo");
            the_database_file = Path.GetTempFileName();
            var configuration = Db4oFactory.NewConfiguration();
            configuration.LockDatabaseFile(false);
            database = Db4oFactory.OpenFile(configuration, the_database_file);
        };

        because b = () =>
        {
            database.Store(original);
            database.Close();
            database.Dispose();
            database = Db4oFactory.OpenFile(the_database_file);
            results = database.Query<ITestObject>().databind();
        };

        it should_be_able_to_load_the_original_contents = () => results.should_contain(original);

        it they_should_be_equal = () => new TestObject(99, "gretzky").Equals(new TestObject(99, "gretzky"));

        it should_only_contain_the_original_item = () => results.Count.should_be_equal_to(1);

        after_all ae = () =>
        {
            database.Close();
            database.Dispose();
        };

        static ITestObject original;
        static string the_database_file;
        static IList<ITestObject> results;
        static IObjectContainer database;
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
            unchecked
            {
                return (Id*397) ^ (Name != null ? Name.GetHashCode() : 0);
            }
        }
    }
}