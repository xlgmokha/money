using MoMoney.Presentation.Views.core;

namespace MoMoney.Presentation.Views.Shell
{
    public interface ILogFileView : IDockedContentView
    {
        void display(string contents);
    }
}