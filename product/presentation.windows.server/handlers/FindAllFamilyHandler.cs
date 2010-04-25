using gorilla.commons.utility;
using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.server.domain;
using presentation.windows.server.orm;

namespace presentation.windows.server.handlers
{
    public class FindAllFamilyHandler : AbstractHandler<FindAllFamily>
    {
        PersonRepository people;
        Mapper mapper;
        ServiceBus bus;

        public FindAllFamilyHandler(PersonRepository people, Mapper mapper, ServiceBus bus)
        {
            this.people = people;
            this.bus = bus;
            this.mapper = mapper;
        }

        public override void handle(FindAllFamily item)
        {
            people
                .find_all()
                .map_all_using<Person, AddedNewFamilyMember>(mapper)
                .each(x => bus.publish(x));
        }
    }
}