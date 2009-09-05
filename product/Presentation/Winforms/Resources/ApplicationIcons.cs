using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Winforms.Resources
{
    static public class ApplicationIcons
    {
        static readonly IList<ApplicationIcon> all_icons = new List<ApplicationIcon>();

        static public readonly ApplicationIcon Application = new ApplicationIcon("mokhan.ico", x => add(x));
        static public readonly ApplicationIcon FileExplorer = new ApplicationIcon("search4files.ico", x => add(x));
        static public readonly HybridIcon ApplicationReady = new HybridIcon("application_ready.ico", x => add(x));
        static public readonly ApplicationIcon AddIncome = new ApplicationIcon("text_document.ico", x => add(x));
        static public readonly HybridIcon NewProject = new HybridIcon("new_project.ico", x => add(x));
        static public readonly HybridIcon OpenProject = new HybridIcon("open.ico", x => add(x));
        static public readonly HybridIcon SaveProject = new HybridIcon("save.ico", x => add(x));
        static public readonly HybridIcon SaveProjectAs = new HybridIcon("save_as.ico", x => add(x));
        static public readonly HybridIcon ExitApplication = new HybridIcon("", x => add(x));
        static public readonly HybridIcon About = new HybridIcon("about.ico", x => add(x));
        static public readonly HybridIcon Empty = new HybridIcon("", x => add(x));

        static public IEnumerable<ApplicationIcon> all()
        {
            return all_icons.all();
        }

        static public void add(ApplicationIcon icon)
        {
            all_icons.Add(icon);
        }
    }
}