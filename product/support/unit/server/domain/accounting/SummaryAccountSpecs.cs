using Machine.Specifications;
using presentation.windows.server.domain.accounting;

namespace unit.server.domain.accounting
{
    public class SummaryAccountSpecs
    {
        [Subject(typeof (SummaryAccount))]
        public class when_retrieving_the_balance_from_a_summary_account
        {
            Establish c = () =>
            {
                var cash = DetailAccount.New(Currency.CAD);
                var credit = DetailAccount.New(Currency.CAD);

                cash.deposit(50, Currency.CAD);
                credit.deposit(50, Currency.CAD);

                sut = SummaryAccount.New(Currency.CAD);
                sut.add(cash);
                sut.add(credit);
            };

            Because b = () =>
            {
                result = sut.balance();
            };

            It should_sum_the_balance_for_each_detail_account = () =>
            {
                result.should_be_equal_to(new Quantity(100.00, Currency.CAD));
            };

            static Quantity result;
            static SummaryAccount sut;
        }
    }
}