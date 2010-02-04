using System;
using gorilla.commons.utility;
using momoney.presentation.resources;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IToolbarItemBuilder
    {
        IToolbarItemBuilder with_tool_tip_text_as(string text);
        IToolbarItemBuilder when_clicked_executes<T>() where T : Command;
        IToolbarItemBuilder displays_icon(HybridIcon project);
        IToolbarItemBuilder can_be_clicked_when(Func<bool> condition);
        IToolbarButton button();
    }
}