using System.Collections.Generic;
using gorilla.commons.utility;
using presentation.windows.domain;
using presentation.windows.orm;

namespace presentation.windows.queries
{
    public class FindAllFamily : Query<IEnumerable<PersonDetails>>
    {
        PersonRepository people;
        Mapper mapper;

        public FindAllFamily(PersonRepository people, Mapper mapper)
        {
            this.people = people;
            this.mapper = mapper;
        }

        public IEnumerable<PersonDetails> fetch()
        {
            return people.find_all().map_all_using<Person, PersonDetails>(mapper);
        }
    }
}