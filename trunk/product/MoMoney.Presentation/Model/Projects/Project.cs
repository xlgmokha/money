namespace MoMoney.Presentation.Model.Projects
{
    public class Project : IProject
    {
        readonly IFile file;

        public Project(IFile file)
        {
            this.file = file;
        }

        public string name()
        {
            return is_file_specified() ? file.path : "untitled.mo";
        }

        public bool is_file_specified()
        {
            return file != null;
        }

        public bool is_open()
        {
            return true;
        }
    }
}