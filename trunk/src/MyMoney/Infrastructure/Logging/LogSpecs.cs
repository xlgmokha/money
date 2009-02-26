using jpboodhoo.bdd.contexts;
using MyMoney.Infrastructure.Container;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

namespace MyMoney.Infrastructure.Logging
{
    [Concern(typeof (Log))]
    public class when_creating_a_logger_for_a_particular_type_ : concerns_for
    {
        it should_return_the_logger_created_for_that_type = () => result.should_be_equal_to(logger);

        context c = () =>
                        {
                            var factory = an<ILogFactory>();
                            var registry = an<IDependencyRegistry>();
                            logger = an<ILogger>();
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(registry, x => x.find_an_implementation_of<ILogFactory>()), factory);

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(factory, x => x.create_for(typeof (string))), logger);

                            resolve.initialize_with(registry);
                        };

        because b = () => { result = Log.For("mo"); };

        after_each_observation a = () => resolve.initialize_with(null);

        static ILogger result;
        static ILogger logger;
    }
}