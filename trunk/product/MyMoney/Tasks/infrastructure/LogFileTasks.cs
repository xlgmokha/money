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
            return File.ReadAllText(Path.Combine(this.startup_directory(), "logs/log.txt"));
        }
    }
}