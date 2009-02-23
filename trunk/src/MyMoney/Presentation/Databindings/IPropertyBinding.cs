namespace MyMoney.Presentation.Databindings
{
    public interface IPropertyBinding<PropertyType>
    {
        PropertyType current_value();
    }
}