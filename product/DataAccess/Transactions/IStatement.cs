namespace MoMoney.DataAccess.Transactions
{
    public interface IStatement
    {
        void prepare(IDatabaseConnection connection);
    }
}