using AutoMapper;
using presentation.windows.domain;
using presentation.windows.queries;

namespace presentation.windows.bootstrappers
{
    public class ConfigureMappings : NeedStartup
    {
        public void run()
        {
            Mapper
                .CreateMap<Person, PersonDetails>()
                .ConvertUsing(x => new PersonDetails
                                   {
                                       id = x.id,
                                       first_name = x.first_name,
                                       last_name = x.last_name,
                                   });
        }
    }
}