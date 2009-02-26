using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyMoney.Infrastructure.Container.Windsor.configuration;
using MyMoney.Utility.Core;

namespace MyMoney.Infrastructure.Container.Windsor
{
    public interface IWindsorContainerFactory : IFactory<IWindsorContainer>
    {
    }

    public class windsor_container_factory : IWindsorContainerFactory
    {
        static IWindsorContainer container;
        static readonly object mutex = new object();
        readonly IComponentExclusionSpecification criteria_to_satisfy;
        readonly IRegistrationConfiguration configuration;

        public windsor_container_factory()
            : this(new component_exclusion_specification(), new component_registration_configuration())
        {
        }

        public windsor_container_factory(IComponentExclusionSpecification criteria_to_satisfy,
                                         IRegistrationConfiguration configuration)
        {
            this.criteria_to_satisfy = criteria_to_satisfy;
            this.configuration = configuration;
        }

        public IWindsorContainer create()
        {
            if (null == container)
            {
                lock (mutex)
                {
                    if (null == container)
                    {
                        container = register_components_into_container();
                    }
                }
            }
            return container;
        }

        IWindsorContainer register_components_into_container()
        {
            var the_container = new WindsorContainer();
            the_container.Register(
                AllTypes
                    .Pick()
                    .FromAssembly(GetType().Assembly)
                    .WithService
                    .FirstInterface()
                    .Unless(criteria_to_satisfy.is_satisfied_by)
                    .Configure(configuration.configure)
                );
            return the_container;
        }
    }
}