using Gorilla.Commons.Utility.Core;
using MoMoney.Infrastructure.Container;

namespace MoMoney.boot.container.registration
{
    internal class wire_up_the_mappers_in_to_the : ICommand
    {
        private readonly IDependencyRegistration registry;

        public wire_up_the_mappers_in_to_the(IDependencyRegistration registry)
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