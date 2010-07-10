using System;
using System.IO;
using gorilla.commons.utility;

namespace presentation.windows.server
{
    public class ConfigureApplicationDirectory : Command
    {
        public void run()
        {
            var company_directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), @"mokhan.ca");
            ensure_exisits(company_directory);
            ensure_exisits(Path.Combine(company_directory, "momoney"));
        }

        void ensure_exisits(string directory)
        {
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
        }
    }
}