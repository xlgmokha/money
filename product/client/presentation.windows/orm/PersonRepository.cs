using presentation.windows.domain;

namespace presentation.windows.orm
{
    public interface PersonRepository
    {
        void save(Person person);
    }
}