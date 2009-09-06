using MoMoney.Service.Infrastructure.Eventing;

namespace MoMoney.Presentation.Model.messages
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