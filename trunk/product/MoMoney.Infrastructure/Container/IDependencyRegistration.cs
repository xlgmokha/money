using System;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.proxies;

namespace MoMoney.Infrastructure.Container
{
    public interface IDependencyRegistration : IBuilder<IDependencyRegistry>
    {
        void singleton<Contract, Implementation>() where Implementation : Contract;
        void singleton<Contract>(Func<Contract> instance_of_the_contract);
        void transient<Contract, Implementation>() where Implementation : Contract;
        void transient(Type contract, Type implementation);
        void proxy<T>(IConfiguration<IProxyBuilder<T>> configuration, Func<T> target);
        void proxy<T, Configuration>(Func<T> target) where Configuration : IConfiguration<IProxyBuilder<T>>, new();
    }
}