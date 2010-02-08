using System;
using gorilla.commons.utility;
using presentation.windows.domain;
using presentation.windows.orm;

namespace presentation.windows.queries
{
    public class FindMemberIdentifiedBy : Query<Guid, PersonDetails>
    {
        PersonRepository people;
        Mapper mapper;

        public FindMemberIdentifiedBy(PersonRepository people, Mapper mapper)
        {
            this.people = people;
            this.mapper = mapper;
        }

        public PersonDetails fetch(Guid item)
        {
            return people.find_by(item).map_using<Person, PersonDetails>(mapper);
        }
    }
}