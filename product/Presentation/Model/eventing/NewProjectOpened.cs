using MoMoney.Service.Infrastructure.Eventing;

namespace momoney.presentation.model.events
{
    public class NewProjectOpened : IEvent
    {
        public NewProjectOpened(string path)
        {
            this.path = path;
        }

        public string path { private set; get; }
    }
}