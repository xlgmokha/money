using System.Collections.Generic;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Winforms.Resources
{
    static public class ApplicationIcons
    {
        static readonly IList<ApplicationIcon> all_icons = new List<ApplicationIcon>();

        static public readonly ApplicationIcon Application = new ApplicationIcon("mokhan.ico", x => add(x));
        static public readonly ApplicationIcon FileExplorer = new ApplicationIcon("binoculars.ico", x => add(x));
        static public readonly HybridIcon ApplicationReady = new HybridIcon("circle_green.ico", x => add(x));
        static public readonly ApplicationIcon AddIncome = new ApplicationIcon("generic_document.ico", x => add(x));
        static public readonly HybridIcon NewProject = new HybridIcon("generic_document.ico", x => add(x));
        static public readonly HybridIcon OpenProject = new HybridIcon("foldergreen.ico", x => add(x));
        static public readonly HybridIcon SaveProject = new HybridIcon("emptydrive.ico", x => add(x));
        static public readonly HybridIcon SaveProjectAs = new HybridIcon("unknowndrive.ico", x => add(x));
        static public readonly HybridIcon CloseProject = new HybridIcon("close_box_red.ico", x => add(x));
        static public readonly HybridIcon ExitApplication = new HybridIcon("shutdown_box_red.ico", x => add(x));
        static public readonly HybridIcon About = new HybridIcon("info_box_blue.ico", x => add(x));
        static public readonly HybridIcon Update = new HybridIcon("connect_tonetwork.ico", x => add(x));
        static public readonly HybridIcon ViewLog = new HybridIcon("Book3.ico", x => add(x));
        static public readonly HybridIcon CloseWindow = new HybridIcon("minimize_box_blue.ico", x => add(x));
        static public readonly HybridIcon Empty = new HybridIcon("", x => add(x));

        static public readonly HybridIcon AddCompany = new HybridIcon("plus__orange.ico", x => add(x));
        static public readonly HybridIcon AddNewIncome = new HybridIcon("plus__orange.ico", x => add(x));
        static public readonly HybridIcon ViewAllIncome = new HybridIcon("search.ico", x => add(x));
        static public readonly HybridIcon AddBillPayment = new HybridIcon("plus__orange.ico", x => add(x));
        static public readonly HybridIcon ViewAllBillPayments = new HybridIcon("search.ico", x => add(x));

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