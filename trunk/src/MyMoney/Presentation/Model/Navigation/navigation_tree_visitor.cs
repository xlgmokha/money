using System.Windows.Forms;
using MyMoney.Infrastructure.Container;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;

namespace MyMoney.Presentation.Model.Navigation
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
            registry.all_implementations_of<IBranchVisitor>().each(root_node.accept);
        }
    }
}