using jpboodhoo.bdd.contexts;
using MyMoney.Domain.Core;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Infrastructure.transactions
{
    [Concern(typeof (unit_of_work<IEntity>))]
    public class when_committing_a_unit_of_work : concerns_for<IUnitOfWork<IEntity>>
    {
        it should_save_each_registered_item = () =>
                                                  {
                                                      repository.was_told_to(x => x.save(first_item));
                                                      repository.was_told_to(x => x.save(second_item));
                                                  };

        public override IUnitOfWork<IEntity> create_sut()
        {
            return new unit_of_work<IEntity>(repository);
        }

        context c = () =>
                        {
                            repository = an<IRepository>();

                            first_item = an<IEntity>();
                            second_item = an<IEntity>();
                        };

        because b = () =>
                        {
                            sut.register(first_item);
                            sut.register(second_item);
                            sut.commit();
                        };

        static IRepository repository;
        static IEntity first_item;
        static IEntity second_item;
    }
}