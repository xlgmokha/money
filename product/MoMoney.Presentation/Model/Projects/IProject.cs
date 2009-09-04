using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Model.Projects
{
    public interface IProject : IState
    {
        string name();
        bool is_file_specified();
        bool is_open();
    }
}