using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Projects
{
    public interface IProject : State
    {
        string name();
        bool is_file_specified();
        bool is_open();
    }
}