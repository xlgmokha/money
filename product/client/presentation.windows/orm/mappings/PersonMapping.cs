using FluentNHibernate.Mapping;
using presentation.windows.domain;

namespace presentation.windows.orm.mappings
{
    public class PersonMapping : ClassMap<Person>
    {
        public PersonMapping()
        {
            Id(x => x.id).GeneratedBy.GuidComb();
            Map(x => x.first_name, "first_name");
            Map(x => x.last_name, "last_name");
            Map(x => x.date_of_birth, "date_of_birth").CustomType<DateUserType>();
        }
    }
}