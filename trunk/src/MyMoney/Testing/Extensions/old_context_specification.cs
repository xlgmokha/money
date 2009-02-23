using MbUnit.Framework;
using MyMoney.Testing.MetaData;
using Rhino.Mocks;

namespace MyMoney.Testing.Extensions
{
    [Observations]
    public abstract class old_context_specification<SystemUnderTest>
    {
        protected SystemUnderTest sut { get; private set; }

        [SetUp]
        public virtual void before_each_specification()
        {
            sut = context();
            because();
        }

        [TearDown]
        public virtual void after_each_specification()
        {
        }

        protected abstract SystemUnderTest context();

        protected abstract void because();

        protected TypeToMock an<TypeToMock>() where TypeToMock : class
        {
            return MockRepository.GenerateMock<TypeToMock>();
        }

        protected T when_the<T>(T item)
        {
            return item;
        }
    }
}