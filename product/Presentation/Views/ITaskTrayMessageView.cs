namespace MoMoney.Presentation.Views.Shell
{
    public interface ITaskTrayMessageView
    {
        void display(string message, params object[] arguments);
    }
}