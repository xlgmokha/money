using System;
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
            Map<Person, AddedNewFamilyMember>(x =>
            {
                return new AddedNewFamilyMember
                       {
                           id = x.id,
                           first_name = x.first_name,
                           last_name = x.last_name,
                       };
            });

            //Map<Message, object>(x =>
            //{
            //    using (var stream = new MemoryStream(x.Data))
            //    {
            //        return Serializer.NonGeneric.Deserialize(Type.GetType(x.Headers["type"]), stream);
            //    }
            //});
        }

        void Map<Input, Output>(Func<Input, Output> conversion)
        {
            Mapper
                .CreateMap<Input, Output>()
                .ConvertUsing(conversion);
        }
    }
}