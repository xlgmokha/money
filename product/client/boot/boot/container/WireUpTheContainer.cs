using Autofac.Builder;
using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Reflection;
using gorilla.commons.infrastructure.thirdparty.Autofac;
using gorilla.commons.utility;
using MoMoney.boot.container.registration;
using momoney.database;
using MoMoney.Presentation;
using momoney.service.infrastructure;
using Assembly = System.Reflection.Assembly;

namespace MoMoney.boot.container
{
    class WireUpTheContainer : Command
    {
        public void run()
        {
            var builder = new ContainerBuilder();
            var registry = new AutofacDependencyRegistryBuilder(builder);

            new AutoWireComponentsInToThe(registry)
                .then(new WireUpTheEssentialServicesIntoThe(registry))
                .then(new WireUpTheDataAccessComponentsIntoThe(registry))
                .then(new WireUpTheInfrastructureInToThe(registry))
                .then(new WireUpTheMappersInToThe(registry))
                .then(new WireUpTheServicesInToThe(registry))
                .then(new WireUpThePresentationModules(registry))
                .then(new WireUpTheViewsInToThe(registry))
                .then(new WireUpTheReportsInToThe(registry))
                .run(new ApplicationAssembly(
                         Assembly.GetExecutingAssembly(),
                         typeof (DatabaseAssembly).Assembly,
                         typeof (PresentationAssembly).Assembly,
                         typeof (InfrastructureAssembly).Assembly
                         ));

            Resolve.initialize_with(registry.build());
        }
    }
}