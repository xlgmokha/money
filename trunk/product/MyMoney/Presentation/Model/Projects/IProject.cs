namespace MoMoney.Presentation.Model.Projects
{
    public interface IProject
    {
        string name();
        bool is_file_specified();
        bool is_open();
    }
}