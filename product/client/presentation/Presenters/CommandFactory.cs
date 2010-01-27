using gorilla.commons.utility;

namespace MoMoney.Presentation.Presenters
{
    public interface CommandFactory
    {
        Command create_for<T>(Callback<T> item, Query<T> query);
    }
}