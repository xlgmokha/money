using AutoMapper;
using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.presenters;

namespace presentation.windows.bootstrappers
{
    public class ConfigureMappings : NeedStartup
    {
        public void run()
        {
            Mapper.CreateMap<AddedNewFamilyMember, PersonDetails>()
                .ConvertUsing(x =>
                {
                    return new PersonDetails
                           {
                               id = x.id,
                               first_name = x.first_name,
                               last_name = x.last_name,
                           };
                });
        }
    }
}