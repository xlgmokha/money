using MoMoney.Service.Infrastructure.Eventing;
using presentation.windows.events;

namespace presentation.windows.presenters
{
    public class CompensationPresenter : TabPresenter, EventSubscriber<SelectedFamilyMember>
    {
        public string Header
        {
            get { return "Compensation"; }
        }

        public void present() {}

        public void notify(SelectedFamilyMember message) {}
    }
}