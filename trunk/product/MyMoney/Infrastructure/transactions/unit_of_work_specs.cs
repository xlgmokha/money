using jpboodhoo.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.transactions
{
    [Concern(typeof (unit_of_work<IEntity>))]
    public abstract class behaves_like_a_unit_of_work : concerns_for<IUnitOfWork<IEntity>, unit_of_work<IEntity>>
    {
        public override IUnitOfWork<IEntity> create_sut()
        {
            return new unit_of_work<IEntity>(repository, factory);
        }

        context c = () =>
                        {
                            repository = the_dependency<IRepository>();
                            factory = the_dependency<IUnitOfWorkRegistrationFactory<IEntity>>();
                        };

        protected static IRepository repository;
        protected static IUnitOfWorkRegistrationFactory<IEntity> factory;
    }

    public class when_committing_a_unit_of_work : behaves_like_a_unit_of_work
    {
        it should_save_each_registered_item = () =>
                                                  {
                                                      repository.was_told_to(x => x.save(first_item));
                                                      repository.was_told_to(x => x.save(second_item));
                                                  };

        context c = () =>
                        {
                            first_item = an<IEntity>();
                            second_item = an<IEntity>();

                            var first_registration = an<IUnitOfWorkRegistration<IEntity>>();
                            var second_registration = an<IUnitOfWorkRegistration<IEntity>>();

                            when_the(factory).is_told_to(x => x.map_from(first_item)).it_will_return(first_registration);
                            when_the(factory).is_told_to(x => x.map_from(second_item)).it_will_return(
                                second_registration);
                            when_the(first_registration).is_told_to(x => x.contains_changes()).it_will_return(true);
                            when_the(second_registration).is_told_to(x => x.contains_changes()).it_will_return(true);
                            when_the(first_registration).is_told_to(x => x.current).it_will_return(first_item);
                            when_the(second_registration).is_told_to(x => x.current).it_will_return(second_item);
                        };

        because b = () =>
                        {
                            sut.register(first_item);
                            sut.register(second_item);
                            sut.commit();
                        };

        static IEntity first_item;
        static IEntity second_item;
    }

    public class when_checking_if_there_are_changes_and_there_are : behaves_like_a_unit_of_work
    {
        it should_tell_the_truth = () => result.should_be_true();

        context c = () =>
                        {
                            first_item = an<IEntity>();
                            var first_registration = an<IUnitOfWorkRegistration<IEntity>>();

                            when_the(factory).is_told_to(x => x.map_from(first_item)).it_will_return(first_registration);
                            when_the(first_registration).is_told_to(x => x.contains_changes()).it_will_return(true);
                            when_the(first_registration).is_told_to(x => x.current).it_will_return(first_item);
                        };

        because b = () =>
                        {
                            sut.register(first_item);
                            result = sut.is_dirty();
                        };

        static bool result;
        static IEntity first_item;
    }

    public class when_checking_if_there_are_changes_and_there_are_not : behaves_like_a_unit_of_work
    {
        it should_tell_the_truth = () => result.should_be_false();

        context c = () =>
                        {
                            first_item = an<IEntity>();
                            var first_registration = an<IUnitOfWorkRegistration<IEntity>>();

                            when_the(factory).is_told_to(x => x.map_from(first_item)).it_will_return(first_registration);
                            when_the(first_registration).is_told_to(x => x.contains_changes()).it_will_return(false);
                        };

        because b = () =>
                        {
                            sut.register(first_item);
                            result = sut.is_dirty();
                        };

        static bool result;
        static IEntity first_item;
    }
}