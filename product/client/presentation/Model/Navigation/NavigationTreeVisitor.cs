using System.Windows.Forms;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Navigation
{
    public class NavigationTreeVisitor : INavigationTreeVisitor
    {
        readonly ITreeViewToRootNodeMapper mapper;
        readonly Registry<IBranchVisitor> visitors;

        public NavigationTreeVisitor(ITreeViewToRootNodeMapper mapper, Registry<IBranchVisitor> visitors)
        {
            this.mapper = mapper;
            this.visitors = visitors;
        }

        public void visit(TreeView item_to_visit)
        {
            var root_node = mapper.map_from(item_to_visit);
            visitors.all().each(root_node.accept);
        }
    }
}