using momoney.presentation.presenters;
using momoney.presentation.views;
using momoney.service.infrastructure.logging;

namespace tests.unit.client.presentation.presenters
{
    public class behaves_like_log_file_presenter : tests_for<LogFilePresenter>
    {
        context c = () =>
        {
            view = dependency<ILogFileView>();
            tasks = dependency<ILogFileTasks>();
        };

        static protected ILogFileView view;
        static protected ILogFileTasks tasks;
    }

    public class when_displaying_the_log_file : behaves_like_log_file_presenter
    {
        it should_display_the_contents_of_the_log_file = () => view.was_told_to(x => x.display(log_file_path));

        context c = () =>
        {
            shell = an<Shell>();
            log_file_path = "log.txt";
            log_file_contents = "hello_jello";
            tasks.is_told_to(x => x.get_the_path_to_the_log_file()).it_will_return(log_file_path);
            tasks.is_told_to(x => x.get_the_contents_of_the_log_file()).it_will_return(log_file_contents);
        };

        because b = () => sut.present(shell);

        static string log_file_contents;
        static string log_file_path;
        static Shell shell;
    }
}