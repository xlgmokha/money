using System.Collections.Generic;
using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu;
using momoney.presentation.model.menu.file;
using MoMoney.Presentation.Model.Projects;
using momoney.presentation.views;
using MoMoney.Presentation.Winforms.Resources;

namespace momoney.presentation.presenters
{
    public interface IToolbarPresenter : IPresenter
    {
    }

    public class ToolBarPresenter : IToolbarPresenter
    {
        readonly IRegionManager shell;
        readonly IProjectController project;

        public ToolBarPresenter(IRegionManager shell, IProjectController project)
        {
            this.shell = shell;
            this.project = project;
        }

        public void run()
        {
            shell.region<ToolStrip>(x => buttons().each(y => y.add_to(x)));
        }

        IEnumerable<IToolbarButton> buttons()
        {
            yield return Create
                .a_tool_bar_item()
                .with_tool_tip_text_as("New")
                .when_clicked_executes<INewCommand>()
                .displays_icon(ApplicationIcons.NewProject)
                .button();
            yield return Create
                .a_tool_bar_item()
                .with_tool_tip_text_as("Open")
                .when_clicked_executes<IOpenCommand>()
                .displays_icon(ApplicationIcons.OpenProject)
                .button();
            yield return Create
                .a_tool_bar_item()
                .with_tool_tip_text_as("Save")
                .when_clicked_executes<ISaveCommand>()
                .can_be_clicked_when(() => project.has_unsaved_changes())
                .displays_icon(ApplicationIcons.SaveProject)
                .button();
        }
    }
}