using System.Collections.Generic;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Resources
{
    public static class ApplicationIcons
    {
        static readonly IList<ApplicationIcon> all_icons = new List<ApplicationIcon>();

        public static readonly ApplicationIcon Application = new ApplicationIcon("mokhan.ico");
        public static readonly ApplicationIcon FileExplorer = new ApplicationIcon("search4files.ico");
        public static readonly HybridIcon ApplicationReady = new HybridIcon("application_ready.ico");
        public static readonly ApplicationIcon AddIncome = new ApplicationIcon("text_document.ico");
        public static readonly HybridIcon NewProject = new HybridIcon("new_project.ico");
        public static readonly HybridIcon OpenProject = new HybridIcon("open.ico");
        public static readonly HybridIcon SaveProject = new HybridIcon("save.ico");
        public static readonly HybridIcon SaveProjectAs = new HybridIcon("save_as.ico");
        public static readonly HybridIcon ExitApplication = new HybridIcon("");
        public static readonly HybridIcon About = new HybridIcon("about.ico");
        public static readonly HybridIcon Empty = new HybridIcon("");

        public static IEnumerable<ApplicationIcon> all()
        {
            return all_icons.all();
        }

        public static void add(ApplicationIcon icon)
        {
            all_icons.Add(icon);
        }
    }
}