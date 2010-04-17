using presentation.windows.common;
using presentation.windows.common.messages;
using presentation.windows.service.infrastructure;

namespace presentation.windows.presenters
{
    public class SaveCommand : UICommand<AddFamilyMemberPresenter>
    {
        ServiceBus bus;

        public SaveCommand(ServiceBus bus)
        {
            this.bus = bus;
        }

        protected override void run(AddFamilyMemberPresenter presenter)
        {
            bus.publish<FamilyMemberToAdd>(x =>
            {
                x.first_name = presenter.first_name;
                x.last_name = presenter.last_name;
                x.date_of_birth = presenter.date_of_birth;
            });
            presenter.close();
        }
    }
}