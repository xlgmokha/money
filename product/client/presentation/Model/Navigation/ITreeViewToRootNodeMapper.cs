using System.Windows.Forms;
using gorilla.commons.utility;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface ITreeViewToRootNodeMapper : Mapper<TreeView, ITreeBranch> {}
}