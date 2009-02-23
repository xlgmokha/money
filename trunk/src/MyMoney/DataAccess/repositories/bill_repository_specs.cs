using System.Collections.Generic;
using MyMoney.Domain.accounting.billing;
using MyMoney.Domain.Core;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;

namespace MyMoney.DataAccess.repositories
{
    public class bill_repository_specs
    {
    }

    [Concern(typeof (IRepository))]
    public class when_loading_all_the_bills_from_the_repository : database_context_spec
    {
        [Observation]
        public void it_should_return_all_the_bills_in_the_database()
        {
            results.should_contain(first_bill);
        }

        protected override IRepository context()
        {
            var repository = base.context();
            first_bill = an<IBill>();
            repository.save(first_bill);
            return repository;
        }

        protected override void because()
        {
            results = sut.all<IBill>();
        }

        private IEnumerable<IBill> results;
        private IBill first_bill;
    }
}