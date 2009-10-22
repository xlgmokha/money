using Gorilla.Commons.Infrastructure.FileSystem;

namespace momoney.presentation.views
{
    public interface ISelectFileToSaveToDialog
    {
        File tell_me_the_path_to_the_file();
    }
}