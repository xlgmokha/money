using Gorilla.Commons.Infrastructure.FileSystem;

namespace momoney.presentation.views
{
    public interface ISelectFileToSaveToDialog : View
    {
        File tell_me_the_path_to_the_file();
    }
}