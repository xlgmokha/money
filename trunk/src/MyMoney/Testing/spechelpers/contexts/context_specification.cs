using MbUnit.Framework;
using MyMoney.Domain.Core;
using MyMoney.Testing.MetaData;
using Rhino.Mocks;

namespace MyMoney.Testing.spechelpers.contexts
{
    //[Observations]
    //public abstract class context_specification
    //{
    //    [SetUp]
    //    public virtual void before_each_observation()
    //    {
    //        context();
    //        initialize_the_sut();
    //        because();
    //    }

    //    [TearDown]
    //    public virtual void after_each_observation()
    //    {
    //        Clock.reset();
    //    }

    //    protected abstract void context();

    //    protected virtual void initialize_the_sut()
    //    {
    //    }

    //    protected abstract void because();

    //    protected TypeToMock the_dependency<TypeToMock>() where TypeToMock : class
    //    {
    //        return MockRepository.GenerateMock<TypeToMock>();
    //    }

    //    protected TypeToMock an<TypeToMock>() where TypeToMock : class
    //    {
    //        return MockRepository.GenerateMock<TypeToMock>();
    //    }

    //    protected T when_the<T>(T item)
    //    {
    //        return item;
    //    }
    //}
}