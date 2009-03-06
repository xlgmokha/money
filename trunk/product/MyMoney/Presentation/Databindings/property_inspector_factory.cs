namespace MoMoney.Presentation.Databindings
{
    public interface IPropertyInspectorFactory
    {
        IPropertyInspector<TypeToInspect, TypeOfProperty> create<TypeToInspect, TypeOfProperty>();
    }

    public class property_inspector_factory : IPropertyInspectorFactory
    {
        public IPropertyInspector<TypeToInspect, TypeOfProperty> create<TypeToInspect, TypeOfProperty>()
        {
            return new property_inspector<TypeToInspect, TypeOfProperty>();
        }
    }
}