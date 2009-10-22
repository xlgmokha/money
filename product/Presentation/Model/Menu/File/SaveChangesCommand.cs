using System;
using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;

namespace MoMoney.Presentation.Model.Menu.File
{
    public interface ISaveChangesCommand : ParameterizedCommand<ISaveChangesCallback> {}

    public interface ISaveChangesPresenter : IPresenter
    {
        void save();
        void dont_save();
        void cancel();
    }

    public interface ISaveChangesCallback
    {
        void saved();
        void not_saved();
        void cancelled();
    }

    public class SaveChangesCommand : ISaveChangesCommand, ISaveChangesPresenter
    {
        readonly IProjectController current_project;
        readonly ISaveChangesView view;
        readonly ISaveAsCommand save_as_command;
        ISaveChangesCallback callback;

        public SaveChangesCommand(IProjectController current_project, ISaveChangesView view, ISaveAsCommand save_as_command)
        {
            this.current_project = current_project;
            this.save_as_command = save_as_command;
            this.view = view;
        }

        public void run()
        {
            throw new NotImplementedException();
        }

        public void run(ISaveChangesCallback item)
        {
            callback = item;
            if (current_project.has_unsaved_changes())
            {
                view.attach_to(this);
                view.prompt_user_to_save();
            }
            else
            {
                item.not_saved();
            }
        }

        public void save()
        {
            if (current_project.has_been_saved_at_least_once())
            {
                current_project.save_changes();
            }
            else
            {
                save_as_command.run();
            }
            callback.saved();
        }

        public void dont_save()
        {
            callback.not_saved();
        }

        public void cancel()
        {
            callback.cancelled();
        }
    }
}