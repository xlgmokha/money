using MbUnit.Framework;

namespace tests
{
    public class IntegrationAttribute : FixtureCategoryAttribute
    {
        public IntegrationAttribute() : base("Integration")
        {
        }
    }
}