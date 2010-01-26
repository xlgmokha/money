using System;
using gorilla.commons.utility;

namespace momoney.service.infrastructure.updating
{
    public interface IWhatIsTheAvailableVersion : Query<ApplicationVersion> {}

    public class ApplicationVersion
    {
        public Uri activation_url { get; set; }
        public Version current { get; set; }
        public string data_directory { get; set; }
        public bool updates_available { get; set; }
        public DateTime last_checked_for_updates { get; set; }
        public string application_name { get; set; }
        public Uri deployment_url { get; set; }
        public Version available_version { get; set; }
        public long size_of_update_in_bytes { get; set; }
    }
}