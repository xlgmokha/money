using MyMoney.Infrastructure.eventing;

namespace MyMoney.Presentation.Model.messages
{
    public class new_project_opened : IEvent
    {
        public new_project_opened(string path)
        {
            this.path = path;
        }

        public string path { private set; get; }
    }
}