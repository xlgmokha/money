using System.Collections.Generic;
using System.Linq;
using MoMoney.Service.Infrastructure.Eventing;
using presentation.windows.events;
using presentation.windows.queries;

namespace presentation.windows.presenters
{
    public class SelectedFamilyMemberPresenter : Observable<SelectedFamilyMemberPresenter>, Presenter, EventSubscriber<AddedNewFamilyMember>
    {
        PersonDetails selected_member;
        QueryBuilder builder;
        EventAggregator event_aggregator;

        public SelectedFamilyMemberPresenter(QueryBuilder builder, EventAggregator event_aggregator)
        {
            this.builder = builder;
            this.event_aggregator = event_aggregator;
        }

        public IList<PersonDetails> family_members { get; set; }

        public PersonDetails SelectedMember
        {
            get { return selected_member; }
            set
            {
                selected_member = value;
                update(x => x.SelectedMember);
                event_aggregator.publish(new SelectedFamilyMember {id = value.id});
            }
        }

        public void present()
        {
            builder.build<FindAllFamily>(x => family_members = x.fetch().ToList());
            update(x => x.family_members);
        }

        public void notify(AddedNewFamilyMember message)
        {
            builder.build<FindMemberIdentifiedBy>(x => family_members.Add(x.fetch(message.id)));
            update(x => x.family_members);
        }
    }
}