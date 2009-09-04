namespace MoMoney.Presentation.Model.Projects
{
    public class EmptyProject : IProject
    {
        public string name()
        {
            return "untitled.mo";
        }

        public bool is_file_specified()
        {
            return false;
        }

        public bool is_open()
        {
            return false;
        }
    }
}