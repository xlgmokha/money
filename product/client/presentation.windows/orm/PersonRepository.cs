using System;
using System.Collections.Generic;
using presentation.windows.domain;

namespace presentation.windows.orm
{
    public interface PersonRepository
    {
        void save(Person person);
        Person find_by(Guid id);
        IEnumerable<Person> find_all();
    }
}