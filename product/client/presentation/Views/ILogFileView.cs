using gorilla.commons.utility;

namespace momoney.presentation.views
{
    public interface ILogFileView : IDockedContentView, Callback<string>
    {
        void display(string file_path);
    }
}