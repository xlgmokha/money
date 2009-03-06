using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface INavigationTreeVisitor : IVisitor<TreeView>
    {}

    public class navigation_tree_visitor : INavigationTreeVisitor
    {
        private readonly ITreeViewToRootNodeMapper mapper;
        private readonly IDependencyRegistry registry;

        public navigation_tree_visitor(ITreeViewToRootNodeMapper mapper, IDependencyRegistry registry)
        {
            this.mapper = mapper;
            this.registry = registry;
        }

        public void visit(TreeView item_to_visit)
        {
            var root_node = mapper.map_from(item_to_visit);
            registry.all_the<IBranchVisitor>().each(root_node.accept);
        }
    }
}