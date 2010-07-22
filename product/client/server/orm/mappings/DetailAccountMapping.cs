using FluentNHibernate.Mapping;
using presentation.windows.server.domain.accounting;

namespace presentation.windows.server.orm.mappings
{
    public class DetailAccountMapping : ClassMap<DetailAccount>
    {
        public DetailAccountMapping()
        {
            Id(x => x.id).GeneratedBy.GuidComb();
        }
    }
}