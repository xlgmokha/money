namespace MoMoney.boot.container.registration.mapping
{
    public interface IMappingStep<Source, Destination>
    {
        void map(Source source, Destination destination);
    }
}