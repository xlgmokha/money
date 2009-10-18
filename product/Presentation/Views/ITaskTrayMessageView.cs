namespace MoMoney.Presentation.Views
{
    public interface ITaskTrayMessageView
    {
        void display(string message, params object[] arguments);
    }
}