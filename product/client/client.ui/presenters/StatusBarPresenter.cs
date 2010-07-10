using System.Threading;
using presentation.windows.eventing;
using presentation.windows.events;

namespace presentation.windows.presenters
{
    public class StatusBarPresenter : Observable<StatusBarPresenter>, Presenter, EventSubscriber<UpdateOnLongRunningProcess>
    {
        public string progress_message { get; set; }
        public bool is_progress_bar_on { get; set; }
        public string username { get; set; }
        public string title { get; set; }

        public void present()
        {
            username = Thread.CurrentPrincipal.Identity.Name;
            title = "Software Developer";
        }

        public void notify(UpdateOnLongRunningProcess message)
        {
            progress_message = message.message;
            is_progress_bar_on = message.percent_complete < 100;
            update(x => x.progress_message, x => x.is_progress_bar_on);
        }
    }
}