using System.Windows.Forms;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface ITreeViewToRootNodeMapper : IMapper<TreeView, ITreeBranch>
    {
    }
}