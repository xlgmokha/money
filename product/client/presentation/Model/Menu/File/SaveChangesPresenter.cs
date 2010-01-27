using System;
using MoMoney.Presentation.Core;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Model.Menu.File
{
    public class SaveChangesPresenter : ISaveChangesCommand, DialogPresenter
    {
        readonly IProjectController current_project;
        readonly ISaveChangesView view;
        readonly ISaveAsCommand save_as_command;
        ISaveChangesCallback callback;

        protected SaveChangesPresenter()
        {
        }

        public SaveChangesPresenter(IProjectController current_project, ISaveChangesView view, ISaveAsCommand save_as_command)
        {
            this.current_project = current_project;
            this.save_as_command = save_as_command;
            this.view = view;
        }

        public virtual void present(Shell shell)
        {
            throw new NotImplementedException();
        }

        public virtual void run(ISaveChangesCallback item)
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

        public virtual void save()
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

        public virtual void dont_save()
        {
            callback.not_saved();
        }

        public virtual void cancel()
        {
            callback.cancelled();
        }
    }
}