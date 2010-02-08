using gorilla.commons.utility;
using MoMoney.Service.Infrastructure.Eventing;
using presentation.windows.commands.dto;
using presentation.windows.domain;
using presentation.windows.events;
using presentation.windows.orm;

namespace presentation.windows.commands
{
    public class AddFamilyMemberCommand : ArgCommand<FamilyMemberToAdd>
    {
        PersonRepository people;
        EventAggregator event_aggregator;

        public AddFamilyMemberCommand(PersonRepository people, EventAggregator event_aggregator)
        {
            this.people = people;
            this.event_aggregator = event_aggregator;
        }

        public void run_against(FamilyMemberToAdd item)
        {
            var person = Person.New(item.first_name, item.last_name, item.date_of_birth);
            people.save(person);
            event_aggregator.publish(new SelectedFamilyMember
                                     {
                                         id = person.id,
                                     });
        }
    }
}