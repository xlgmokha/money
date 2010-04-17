using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface DatabaseCommand : Command<DatabaseConnection> {}
}