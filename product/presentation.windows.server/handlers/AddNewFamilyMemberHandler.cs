using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.server.domain;
using presentation.windows.server.orm;

namespace presentation.windows.server.handlers
{
    public class AddNewFamilyMemberHandler : Handler<FamilyMemberToAdd>
    {
        PersonRepository people;
        ServiceBus bus;

        public AddNewFamilyMemberHandler(PersonRepository people, ServiceBus bus)
        {
            this.people = people;
            this.bus = bus;
        }

        public void handle(FamilyMemberToAdd item)
        {
            var person = Person.New(item.first_name, item.last_name, item.date_of_birth);
            people.save(person);
            bus.publish<AddedNewFamilyMember>(x =>
            {
                x.id = person.id;
                x.first_name = person.first_name;
            });
        }
    }
}