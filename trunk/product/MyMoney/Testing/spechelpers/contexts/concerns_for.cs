using jpboodhoo.bdd.mbunit.standard.observations;
using MyMoney.Testing.Extensions;
using Rhino.Mocks;

namespace MyMoney.Testing.spechelpers.contexts
{
    public abstract class concerns_for<Contract> : observations_for_a_sut_without_a_contract<Contract>,
                                                   IHideObjectMembers
    {
    }

    public abstract class concerns_for<Contract, Implementation> :
        observations_for_a_sut_with_a_contract<Contract, Implementation>, IHideObjectMembers
        where Implementation : Contract
    {
        static protected T when_the<T>(T item)
        {
            return item;
        }

        static protected T dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }
    }

    public abstract class concerns_for : observations_for_a_static_sut, IHideObjectMembers
    {
        static protected T dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        static public T when_the<T>(T item)
        {
            return item;
        }
    }
}