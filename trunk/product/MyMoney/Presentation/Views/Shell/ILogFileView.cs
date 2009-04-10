using MoMoney.Presentation.Views.core;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Views.Shell
{
    public interface ILogFileView : IDockedContentView, ICallback<string>
    {
        void display(string file_path);
    }
}