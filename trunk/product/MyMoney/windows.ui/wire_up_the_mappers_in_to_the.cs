using MyMoney.Infrastructure.Container.Windsor;
using MyMoney.Utility.Core;

namespace MyMoney.windows.ui
{
    internal class wire_up_the_mappers_in_to_the : ICommand
    {
        private readonly windsor_dependency_registry registry;

        public wire_up_the_mappers_in_to_the(windsor_dependency_registry registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            //registry.register<IMapper<ISubMenu, ToolStripMenuItem>, sub_menu_to_tool_strip_menu_item_mapper>();
            //registry.register<IMapper<TreeView, ITreeBranch>, tree_view_to_root_node_mapper>();
        }
    }
}