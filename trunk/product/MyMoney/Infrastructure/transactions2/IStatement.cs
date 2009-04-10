namespace MoMoney.Infrastructure.transactions2
{
    public interface IStatement
    {
        void prepare(IDatabaseConnection connection);
    }
}