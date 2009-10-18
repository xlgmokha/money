using Gorilla.Commons.Infrastructure.FileSystem;

namespace MoMoney.Presentation.Views
{
    public interface ISelectFileToOpenDialog
    {
        IFile tell_me_the_path_to_the_file();
    }
}