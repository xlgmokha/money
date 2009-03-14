using System.IO;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Tasks.infrastructure
{
    public interface ILogFileTasks
    {
        string get_the_contents_of_the_log_file();
    }

    public class LogFileTasks : ILogFileTasks
    {
        public string get_the_contents_of_the_log_file()
        {
            var log_file_path = Path.Combine(this.startup_directory(), "logs/log.txt");
            using (var file_stream = new FileStream(log_file_path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(file_stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}