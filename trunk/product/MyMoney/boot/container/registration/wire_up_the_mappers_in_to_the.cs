using MoMoney.Infrastructure.Container.Windsor;
using MoMoney.Utility.Core;

namespace MoMoney.boot.container
{
    internal class wire_up_the_mappers_in_to_the : ICommand
    {
        private readonly IContainerBuilder registry;

        public wire_up_the_mappers_in_to_the(IContainerBuilder registry)
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