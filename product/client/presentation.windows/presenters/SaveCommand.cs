using MoMoney.Service.Infrastructure.Threading;
using presentation.windows.commands;
using presentation.windows.commands.dto;

namespace presentation.windows.presenters
{
    public class SaveCommand : UICommand<AddFamilyMemberPresenter>
    {
        CommandBuilder command_builder;
        CommandProcessor processor;

        public SaveCommand(CommandBuilder command_builder, CommandProcessor processor)
        {
            this.command_builder = command_builder;
            this.processor = processor;
        }

        protected override void run(AddFamilyMemberPresenter presenter)
        {
            processor.add(command_builder
                              .prepare(new FamilyMemberToAdd
                                       {
                                           first_name = presenter.first_name,
                                           last_name = presenter.last_name,
                                           date_of_birth = presenter.date_of_birth
                                       })
                              .build<AddFamilyMemberCommand>("Adding Family Member")
                );
            presenter.close();
        }
    }
}