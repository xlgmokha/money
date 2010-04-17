using presentation.windows.server.domain.accounting;

namespace presentation.windows.server.orm
{
    public interface AccountRepository
    {
        void save(Account account);
    }
}