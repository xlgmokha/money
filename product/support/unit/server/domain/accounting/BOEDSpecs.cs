using Machine.Specifications;
using presentation.windows.server.domain.accounting;

namespace unit.server.domain.accounting
{
    public class BOEDSpecs
    {
        public abstract class concern
        {
            Establish context = () =>
            {
                sut = new BOED();
            };

            Cleanup c = () =>
            {
                SimpleUnitOfMeasure.provide_rate((x, y) => ConversionRatio.Default);
            };

            static protected BOED sut;
        }

        [Subject(typeof (BOED))]
        public class when_converting_one_barrel_of_oil_equivalent_to_one_mcf : concern
        {
            Establish c = () =>
            {
                SimpleUnitOfMeasure.provide_rate((x, y) =>
                {
                    return new ConversionRatio(6);
                });
            };

            Because b = () =>
            {
                result = sut.convert(1, new MCF());
            };

            It should_return_the_corrent_value = () =>
            {
                result.should_be_equal_to(6);
            };

            static double result;
        }
    }
}