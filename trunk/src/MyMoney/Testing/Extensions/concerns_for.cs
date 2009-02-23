using jpboodhoo.bdd.mbunit.standard.observations;
using Rhino.Mocks;

namespace MyMoney.Testing.Extensions
{
    public abstract class concerns_for<Contract> : observations_for_a_sut_without_a_contract<Contract>,
                                                   IHideObjectMembers
    {
        protected static T when_the<T>(T item)
        {
            return item;
        }
    }

    public abstract class concerns_for<Contract, Implementation> : concerns_for<Contract>, IHideObjectMembers
        where Implementation : Contract
    {
        protected static T dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }
    }

    public abstract class concerns_for : observations_for_a_static_sut, IHideObjectMembers
    {
        protected static T dependency<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        public static T when_the<T>(T item)
        {
            return item;
        }
    }
}