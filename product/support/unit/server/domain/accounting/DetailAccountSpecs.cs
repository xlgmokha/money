using Machine.Specifications;
using presentation.windows.server.domain.accounting;

namespace unit.server.domain.accounting
{
    public class DetailAccountSpecs
    {
        public abstract class concern
        {
            Establish c = () =>
            {
                sut = DetailAccount.New(Currency.CAD);
            };

            static protected DetailAccount sut;
        }

        [Subject(typeof (DetailAccount))]
        public class when_depositing_money_in_to_an_account : concern
        {
            Because b = () =>
            {
                sut.deposit(100.01, Currency.CAD);
            };

            It should_adjust_the_balance = () =>
            {
                sut.balance().should_be_equal_to(new Quantity(100.01, Currency.CAD));
            };
        }

        [Subject(typeof (DetailAccount))]
        public class when_withdrawing_money_from_an_account : concern
        {
            Because b = () =>
            {
                sut.deposit(100.01);
                sut.withdraw(10.00, Currency.CAD);
            };

            It should_adjust_the_balance = () =>
            {
                sut.balance().should_be_equal_to(new Quantity(90.01, Currency.CAD));
            };
        }
    }
}