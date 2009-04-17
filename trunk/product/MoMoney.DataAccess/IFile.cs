namespace MoMoney.Presentation.Model.Projects
{
    public interface IFile
    {
        string path { get; }
        bool does_the_file_exist();
        void copy_to(string path);
        void delete();
    }
}