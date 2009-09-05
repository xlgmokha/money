using System;
using Gorilla.Commons.Utility.Core;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Menu
{
    public interface IToolbarItemBuilder
    {
        IToolbarItemBuilder with_tool_tip_text_as(string text);
        IToolbarItemBuilder when_clicked_executes<T>() where T : ICommand;
        IToolbarItemBuilder displays_icon(HybridIcon project);
        IToolbarItemBuilder can_be_clicked_when(Func<bool> condition);
        IToolbarButton button();
    }
}