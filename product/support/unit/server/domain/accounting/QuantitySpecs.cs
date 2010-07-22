using Machine.Specifications;
using presentation.windows.server.domain.accounting;

namespace unit.server.domain.accounting
{
    public class QuantitySpecs
    {
        public abstract class concern 
        {
            Establish c = () =>
            {
                sut = new Quantity(100, Currency.CAD);
            };

            static protected Quantity sut;
        }

        [Subject(typeof (Quantity))]
        public class when_checking_if_two_quantities_are_equal : concern
        {
            It should_return_true_when_they_represent_the_same_amount_and_units = () =>
            {
                sut.should_be_equal_to(new Quantity(100, Currency.CAD));
            };

            It should_return_false_when_they_are_not_the_same_amount = () =>
            {
                sut.should_not_be_equal_to(new Quantity(1, Currency.CAD));
            };

            It should_return_false_when_they_represent_different_currencies = () =>
            {
                sut.should_not_be_equal_to(new Quantity(100, Currency.USD));
            };
        }
    }
}