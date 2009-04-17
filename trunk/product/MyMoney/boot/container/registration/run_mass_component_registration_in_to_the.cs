using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Infrastructure.Container.Windsor.configuration;

namespace MoMoney.boot.container.registration
{
    internal class run_mass_component_registration_in_to_the : ICommand
    {
        readonly IWindsorContainer container;
        readonly IComponentExclusionSpecification criteria_to_satisfy;
        readonly IRegistrationConfiguration configuration;

        public run_mass_component_registration_in_to_the(IWindsorContainer container,
                                                         IComponentExclusionSpecification criteria_to_satisfy,
                                                         IRegistrationConfiguration configuration)
        {
            this.container = container;
            this.criteria_to_satisfy = criteria_to_satisfy;
            this.configuration = configuration;
        }

        public void run()
        {
            container.Register(
                AllTypes
                    .Pick()
                    .FromAssembly(GetType().Assembly)
                    .WithService
                    .LastInterface()
                    //.FirstInterface()
                    .Unless(criteria_to_satisfy.is_satisfied_by)
                    .Configure(x => configuration.configure(x))
                );
        }
    }
}