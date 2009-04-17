using MbUnit.Framework;

namespace MoMoney.Testing.MetaData
{
    public class IntegrationAttribute : FixtureCategoryAttribute
    {
        public IntegrationAttribute() : base("Integration")
        {
        }
    }
}