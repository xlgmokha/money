using System.Windows.Forms;

namespace momoney.presentation.views
{
    public interface IApplicationWindow : IView
    {
        IApplicationWindow titled(string title);
        IApplicationWindow create_tool_tip_for(string title, string caption, Control control);
        IApplicationWindow try_to_reduce_flickering();
        IApplicationWindow top_most();
    }
}