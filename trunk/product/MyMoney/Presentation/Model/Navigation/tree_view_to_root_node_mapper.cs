using System.Windows.Forms;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface ITreeViewToRootNodeMapper : IMapper<TreeView, ITreeBranch>
    {}

    public class tree_view_to_root_node_mapper : ITreeViewToRootNodeMapper
    {
        public ITreeBranch map_from(TreeView item)
        {
            var root_node = item.Nodes.Add("Where My Money At?");
            return new tree_branch(root_node, new empty_command());
        }
    }
}