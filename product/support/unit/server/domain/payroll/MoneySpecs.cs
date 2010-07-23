using Machine.Specifications;
using presentation.windows.server.domain.payroll;

namespace unit.server.domain.payroll
{
    public class MoneySpecs
    {
        [Subject(typeof (Money))]
        public class when_two_monies_are_the_same
        {
            Establish c = () =>
            {
                sut = 100.00;
            };

            It should_be_equal = () =>
            {
                sut.Equals(100.00);
            };

            static Money sut;
        }
    }
}