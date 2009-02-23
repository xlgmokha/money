using Castle.Core;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Model.messages;
using MyMoney.Presentation.Model.Projects;
using MyMoney.Presentation.Views.Shell;

namespace MyMoney.Presentation.Presenters.Shell
{
    public interface ITitleBarPresenter : IPresentationModule,
                                          IEventSubscriber<unsaved_changes_event>,
                                          IEventSubscriber<saved_changes_event>,
                                          IEventSubscriber<new_project_opened>
    {
    }

    [Singleton]
    public class title_bar_presenter : ITitleBarPresenter
    {
        readonly ITitleBar view;
        readonly IProject project;
        readonly IEventAggregator broker;

        public title_bar_presenter(ITitleBar view, IProject project, IEventAggregator broker)
        {
            this.view = view;
            this.project = project;
            this.broker = broker;
        }

        public void run()
        {
            broker.subscribe_to<unsaved_changes_event>(this);
            broker.subscribe_to<saved_changes_event>(this);
            broker.subscribe_to<new_project_opened>(this);
            view.display(project.name());
        }

        public void notify(unsaved_changes_event dto)
        {
            view.append_asterik();
        }

        public void notify(saved_changes_event message)
        {
            view.display(project.name());
            view.remove_asterik();
        }

        public void notify(new_project_opened message)
        {
            view.display(project.name());
        }
    }
}