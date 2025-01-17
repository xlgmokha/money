using Gorilla.Commons.Infrastructure.Container;
using Gorilla.Commons.Infrastructure.Logging;

namespace tests.unit.commons.infrastructure
{
    [Concern(typeof (Log))]
    public class when_creating_a_logger_for_a_particular_type_ : concerns
    {
        it should_return_the_logger_created_for_that_type = () => result.should_be_equal_to(logger);

        context c =
            () =>
            {
                var factory = an<LogFactory>();
                var registry = an<DependencyRegistry>();
                logger = an<Logger>();
                registry.is_told_to(x => x.get_a<LogFactory>()).it_will_return(factory);
                factory.is_told_to(x => x.create_for(typeof (string))).it_will_return(logger);

                Resolve.initialize_with(registry);
            };

        because b = () =>
        {
            result = Log.For("mo");
        };

        after_all a = () => Resolve.initialize_with(null);

        static Logger result;
        static Logger logger;
    }
}