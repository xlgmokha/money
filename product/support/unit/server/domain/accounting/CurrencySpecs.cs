using Machine.Specifications;
using presentation.windows.server.domain.accounting;

namespace unit.server.domain.accounting
{
    public class CurrencySpecs
    {
        public abstract class concern 
        {
            Cleanup cleanup = () =>
            {
                SimpleUnitOfMeasure.provide_rate((x, y) => ConversionRatio.Default);
            };
        }

        [Subject(typeof (Currency))]
        public class when_converting_one_USD_dollar_to_CAD : concern
        {
            Establish c = () =>
            {
                SimpleUnitOfMeasure.provide_rate((x, y) => new ConversionRatio(1.05690034));
            };

            It should_return_the_correct_amount = () =>
            {
                Currency.USD.convert(1, Currency.CAD).should_be_equal_to(1.05690034);
            };
        }

        [Subject(typeof (Currency))]
        public class when_converting_one_CAD_dollar_to_USD : concern
        {
            Establish c = () =>
            {
                SimpleUnitOfMeasure.provide_rate((x, y) => new ConversionRatio(0.95057));
            };

            It should_return_the_correct_amount = () =>
            {
                Currency.CAD.convert(1.05690034d, Currency.USD).should_be_equal_to(1.0046577561938002d);
            };
        }
    }
}