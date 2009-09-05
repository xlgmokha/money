namespace MoMoney.Presentation.Winforms.Databinding
{
    public interface IPropertyBinding<PropertyType>
    {
        PropertyType current_value();
    }
}