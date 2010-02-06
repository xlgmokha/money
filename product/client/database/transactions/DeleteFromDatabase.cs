namespace momoney.database.transactions
{
    public class DeleteFromDatabase<T> : DatabaseCommand
    {
        readonly T entity;

        public DeleteFromDatabase(T entity)
        {
            this.entity = entity;
        }

        public void run_against(DatabaseConnection connection)
        {
            connection.delete(entity);
        }
    }
}