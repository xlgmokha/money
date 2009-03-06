using jpboodhoo.bdd.contexts;
using MoMoney.Domain.Core;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Infrastructure.transactions
{
    [Concern(typeof (UnitOfWorkRegistry))]
    public abstract class behaves_like_unit_of_work_registery : concerns_for<IUnitOfWorkRegistry,UnitOfWorkRegistry>
    {
        //public override IUnitOfWorkRegistry create_sut()
        //{
        //    return new UnitOfWorkRegistry(factory);
        //}

        context c = () => { factory = the_dependency<IUnitOfWorkFactory>(); };

        protected static IUnitOfWorkFactory factory;
    }

    public class when_starting_a_unit_of_work_for_a_new_type : behaves_like_unit_of_work_registery
    {
        it should_register_a_new_unit_of_work = () => factory.was_told_to(x => x.create_for<IEntity>());

        it should_return_the_new_unit_of_work = () => result.should_be_equal_to(unit_of_work);

        context c = () =>
                        {
                            unit_of_work = an<IUnitOfWork<IEntity>>();
                            factory.is_told_to(x => x.create_for<IEntity>()).it_will_return( unit_of_work);
                        };

        because b = () => { result = sut.start_unit_of_work_for<IEntity>(); };

        static IUnitOfWork<IEntity> unit_of_work;
        static IUnitOfWork<IEntity> result;
    }

    public class when_attempting_to_start_a_unit_of_work_for_a_type_that_already_has_one_started :
        behaves_like_unit_of_work_registery
    {
        it should_return_the_already_started_unit_of_work = () => result.should_be_equal_to(unit_of_work);

        context c = () =>
                        {
                            unit_of_work = an<IUnitOfWork<IEntity>>();

                            factory.is_told_to(x => x.create_for<IEntity>()).it_will_return( unit_of_work).Repeat.Once();
                        };

        because b = () =>
                        {
                            sut.start_unit_of_work_for<IEntity>();
                            result = sut.start_unit_of_work_for<IEntity>();
                        };

        static IUnitOfWork<IEntity> unit_of_work;
        static IUnitOfWork<IEntity> result;
    }

    public class when_committing_all_the_active_units_of_work : behaves_like_unit_of_work_registery
    {
        it should_commit_each_one = () => unit_of_work.was_told_to(x => x.commit());

        context c = () =>
                        {
                            unit_of_work = an<IUnitOfWork<IEntity>>();
                            factory.is_told_to(x => x.create_for<IEntity>()).it_will_return( unit_of_work).Repeat.Once();
                        };

        because b = () =>
                        {
                            sut.start_unit_of_work_for<IEntity>();
                            sut.commit_all();
                        };

        static IUnitOfWork<IEntity> unit_of_work;
    }
}