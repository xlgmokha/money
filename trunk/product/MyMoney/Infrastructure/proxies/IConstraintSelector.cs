namespace MoMoney.Infrastructure.proxies
{
    public interface IConstraintSelector<TypeToPutConstraintOn>
    {
        TypeToPutConstraintOn InterceptOn { get; }
        void InterceptAll();
    }
}