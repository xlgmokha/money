using System;
using MoMoney.Service.Infrastructure.Threading;
using presentation.windows.commands;
using presentation.windows.commands.dto;
using presentation.windows.views;

namespace presentation.windows.presenters
{
    public class AddFamilyMemberPresenter : DialogPresenter
    {
        CommandBuilder command_builder;
        CommandProcessor processor;

        public AddFamilyMemberPresenter(CommandBuilder command_builder, CommandProcessor processor)
        {
            this.command_builder = command_builder;
            this.processor = processor;
        }

        public void present()
        {
            Save = new SimpleCommand(() =>
            {
                processor.add(command_builder
                                  .prepare(new FamilyMemberToAdd
                                           {
                                               first_name = first_name,
                                               last_name = last_name,
                                               date_of_birth = date_of_birth
                                           })
                                  .build<AddMemberToFamily>("Adding Family Member")
                    );
                close();
            });
            Cancel = new SimpleCommand(() =>
            {
                close();
            });
        }

        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_of_birth { get; set; }
        public IObservableCommand Save { get; set; }
        public IObservableCommand Cancel { get; set; }

        public Action close { get; set; }
    }
}