using MyMoney.Domain.Core;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.Infrastructure.transactions
{
    public class unit_of_work_specs
    {}

    [Concern(typeof (unit_of_work<IEntity>))]
    public class when_committing_a_unit_of_work : old_context_specification<IUnitOfWork<IEntity>>
    {
        [Observation]
        public void it_should_save_each_registered_item()
        {
            repository.was_told_to(x => x.save(first_item));
            repository.was_told_to(x => x.save(second_item));
        }

        protected override IUnitOfWork<IEntity> context()
        {
            repository = an<IRepository>();

            first_item = an<IEntity>();
            second_item = an<IEntity>();

            return new unit_of_work<IEntity>(repository);
        }

        protected override void because()
        {
            sut.register(first_item);
            sut.register(second_item);
            sut.commit();
        }

        private IRepository repository;
        private IEntity first_item;
        private IEntity second_item;
    }
}