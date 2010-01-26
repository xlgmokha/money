using MoMoney.Presentation;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views;
using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.presenters
{
    public class TitleBarPresenter :
        IModule,
        IEventSubscriber<UnsavedChangesEvent>,
        IEventSubscriber<SavedChangesEvent>,
        IEventSubscriber<NewProjectOpened>,
        IEventSubscriber<ClosingProjectEvent>
    {
        readonly ITitleBar view;
        readonly IProjectController project;

        public TitleBarPresenter(ITitleBar view, IProjectController project)
        {
            this.view = view;
            this.project = project;
        }

        public void run()
        {
            view.display(project.name());
        }

        public void notify(UnsavedChangesEvent dto)
        {
            view.append_asterik();
        }

        public void notify(SavedChangesEvent message)
        {
            view.display(project.name());
            view.remove_asterik();
        }

        public void notify(NewProjectOpened message)
        {
            view.display(project.name());
        }

        public void notify(ClosingProjectEvent message)
        {
            view.display(project.name());
        }
    }
}