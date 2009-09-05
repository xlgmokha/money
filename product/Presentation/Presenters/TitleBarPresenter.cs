using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Infrastructure.Logging;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Model.Projects;
using MoMoney.Presentation.Views;

namespace MoMoney.Presentation.Presenters.Shell
{
    public interface ITitleBarPresenter : IModule,
                                          IEventSubscriber<UnsavedChangesEvent>,
                                          IEventSubscriber<SavedChangesEvent>,
                                          IEventSubscriber<NewProjectOpened>,
                                          IEventSubscriber<ClosingProjectEvent>
    {
    }

    public class TitleBarPresenter : ITitleBarPresenter
    {
        readonly ITitleBar view;
        readonly IProjectController project;
        readonly IEventAggregator broker;

        public TitleBarPresenter(ITitleBar view, IProjectController project, IEventAggregator broker)
        {
            this.view = view;
            this.project = project;
            this.broker = broker;
        }

        public void run()
        {
            view.display(project.name());
            broker.subscribe_to<UnsavedChangesEvent>(this);
            broker.subscribe_to<SavedChangesEvent>(this);
            broker.subscribe_to<NewProjectOpened>(this);
            broker.subscribe_to<ClosingProjectEvent>(this);
        }

        public void notify(UnsavedChangesEvent dto)
        {
            this.log().debug("adding asterik");
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