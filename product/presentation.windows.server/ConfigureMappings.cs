using AutoMapper;
using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.server.domain;

namespace presentation.windows.server
{
    public class ConfigureMappings : NeedStartup
    {
        public void run()
        {
            Mapper
                .CreateMap<Person, AddedNewFamilyMember>()
                .ConvertUsing(x => new AddedNewFamilyMember
                                   {
                                       id = x.id,
                                       first_name = x.first_name,
                                       last_name = x.last_name,
                                   });
        }
    }
}