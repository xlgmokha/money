namespace MoMoney.boot.container.registration.mapping
{
    public interface IMapInitializationStep<T>
    {
        T initialize();
    }
}