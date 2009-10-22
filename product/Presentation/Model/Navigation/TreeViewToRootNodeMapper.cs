using System.Windows.Forms;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Navigation
{
    public class TreeViewToRootNodeMapper : ITreeViewToRootNodeMapper
    {
        public ITreeBranch map_from(TreeView item)
        {
            return new TreeBranch(item.Nodes.Add("Where My Money At?"), new EmptyCommand());
        }
    }
}