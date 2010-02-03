using System.Windows.Forms;

namespace momoney.presentation.views
{
    public interface IApplicationWindow : View
    {
        IApplicationWindow create_tool_tip_for(string title, string caption, Control control);
    }
}