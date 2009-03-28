namespace MoMoney.Infrastructure.proxies
{
    public interface IConstraintSelector<TypeToPutConstraintOn>
    {
        TypeToPutConstraintOn intercept_on { get; }
        void intercept_all();
    }
}