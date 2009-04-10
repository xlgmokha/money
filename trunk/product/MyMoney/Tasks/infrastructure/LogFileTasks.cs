using System.IO;
using MoMoney.Infrastructure.Extensions;

namespace MoMoney.Tasks.infrastructure
{
    public interface ILogFileTasks
    {
        string get_the_contents_of_the_log_file();
        string get_the_path_to_the_log_file();
        //void notify(ICallback<string> view);
    }

    public class LogFileTasks : ILogFileTasks
    {
        public string get_the_contents_of_the_log_file()
        {
            using (
                var file_stream = new FileStream(get_the_path_to_the_log_file(), FileMode.Open, FileAccess.Read,
                                                 FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(file_stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public string get_the_path_to_the_log_file()
        {
            return Path.Combine(this.startup_directory(), @"logs\log.txt");
        }

        //public void notify(ICallback<string> view)
        //{
        //    var watcher = new FileSystemWatcher(Path.Combine(this.startup_directory(), "logs"), "log.txt");
        //    watcher.Changed += (sender, args) => view.run(get_the_contents_of_the_log_file());
        //    watcher.EnableRaisingEvents = true;
        //    watcher.Error += (sender, args) => this.log().error(args.GetException());
        //}
    }
}