namespace momoney.service.infrastructure.logging
{
    public interface ILogFileTasks
    {
        string get_the_contents_of_the_log_file();
        string get_the_path_to_the_log_file();
    }
}