namespace momoney.database.transactions
{
    public interface IStatement
    {
        void prepare(IDatabaseConnection connection);
    }
}