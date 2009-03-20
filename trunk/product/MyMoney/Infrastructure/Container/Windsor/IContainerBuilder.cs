using System;
using MoMoney.Infrastructure.proxies;
using MoMoney.Utility.Core;

namespace MoMoney.Infrastructure.Container.Windsor
{
    public interface IContainerBuilder
    {
        void singleton<Interface, Implementation>() where Implementation : Interface;
        void singleton<Interface>(Interface instanceOfTheInterface);
        void transient<Interface, Implementation>() where Implementation : Interface;
        void proxy<T>(IConfiguration<IProxyBuilder<T>> configuration, Func<T> target);
    }
}