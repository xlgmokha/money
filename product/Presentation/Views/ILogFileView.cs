using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Views
{
    public interface ILogFileView : IDockedContentView, ICallback<string>
    {
        void display(string file_path);
    }
}