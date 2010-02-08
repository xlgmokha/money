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

        public SelectedFamilyMemberPresenter(QueryBuilder builder)
        {
            this.builder = builder;
        }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public IList<PersonDetails> family_members { get; set; }

        public PersonDetails SelectedMember
        {
            get { return selected_member; }
            set
            {
                selected_member = value;
                first_name = selected_member.first_name;
                last_name = selected_member.last_name;
                update(x => x.first_name, x => x.last_name);
            }
        }

        public void present()
        {
            family_members = builder.build<FindAllFamily>().fetch().ToList();
            update(x => x.family_members);
        }

        public void notify(AddedNewFamilyMember message)
        {
            family_members.Add(builder.build<FindMemberIdentifiedBy>().fetch(message.id));
            update(x => x.family_members);
        }
    }
}