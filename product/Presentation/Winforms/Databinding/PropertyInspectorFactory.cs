namespace MoMoney.Presentation.Winforms.Databinding
{
    public interface IPropertyInspectorFactory
    {
        IPropertyInspector<TypeToInspect, TypeOfProperty> create<TypeToInspect, TypeOfProperty>();
    }

    public class PropertyInspectorFactory : IPropertyInspectorFactory
    {
        public IPropertyInspector<TypeToInspect, TypeOfProperty> create<TypeToInspect, TypeOfProperty>()
        {
            return new PropertyInspector<TypeToInspect, TypeOfProperty>();
        }
    }
}