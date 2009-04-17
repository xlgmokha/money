using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Domain.Core;

namespace MoMoney.Infrastructure.transactions2
{
    public class ChangeTrackerFactorySpecs
    {
    }

    public class when_creating_a_change_tracker_for_an_item : concerns_for<IChangeTrackerFactory, ChangeTrackerFactory>
    {
        it should_return_a_new_tracker = () => { result.should_not_be_null(); };

        because b = () => { result = sut.create_for<IEntity>(); };

        static IChangeTracker<IEntity> result;
    }
}