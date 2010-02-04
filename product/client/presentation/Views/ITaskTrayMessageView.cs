using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface ITaskTrayMessageView : View<TaskTrayPresenter>
    {
        void display(string message, params object[] arguments);
    }
}