using MoMoney.Service.Infrastructure.Eventing;
using presentation.windows.events;

namespace presentation.windows.presenters
{
    public class SelectedFamilyMemberPresenter : Observable<SelectedFamilyMemberPresenter>, Presenter, EventSubscriber<SelectedFamilyMember>
    {
        public void present() {}

        public void notify(SelectedFamilyMember message) {}
    }
}