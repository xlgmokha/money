using System.Windows.Forms;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;

namespace MoMoney.Presentation.Model.Navigation
{
    public class NavigationTreeVisitor : INavigationTreeVisitor
    {
        readonly ITreeViewToRootNodeMapper mapper;
        readonly IRegistry<IBranchVisitor> visitors;

        public NavigationTreeVisitor(ITreeViewToRootNodeMapper mapper, IRegistry<IBranchVisitor> visitors)
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