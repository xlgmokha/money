using gorilla.commons.utility;

namespace momoney.database.transactions
{
    public interface DatabaseCommand : ParameterizedCommand<DatabaseConnection>
    {
    }
}