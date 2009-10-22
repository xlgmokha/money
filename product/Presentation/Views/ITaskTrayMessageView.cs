namespace momoney.presentation.views
{
    public interface ITaskTrayMessageView
    {
        void display(string message, params object[] arguments);
    }
}