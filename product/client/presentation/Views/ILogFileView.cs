using gorilla.commons.utility;
using momoney.presentation.presenters;

namespace momoney.presentation.views
{
    public interface ILogFileView : IDockedContentView, Callback<string>, View<LogFilePresenter>
    {
        void display(string file_path);
    }
}