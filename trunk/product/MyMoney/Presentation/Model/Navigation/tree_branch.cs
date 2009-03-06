using System.Drawing;
using System.Windows.Forms;
using MoMoney.Presentation.Resources;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Model.Navigation
{
    public interface ITreeBranch
    {
        void accept(IVisitor<ITreeBranch> visitor);
        ITreeBranch add_child(string name, ApplicationIcon icon, ICommand command);
    }

    public class tree_branch : ITreeBranch
    {
        private readonly TreeNode node;
        private readonly ICommand the_command;

        public tree_branch(TreeNode node, ICommand the_command)
        {
            this.node = node;
            this.the_command = the_command;
            this.node.TreeView.DoubleClick += (sender, e) => Click();
        }

        public void accept(IVisitor<ITreeBranch> visitor)
        {
            visitor.visit(this);
        }

        public ITreeBranch add_child(string name, ApplicationIcon icon, ICommand command)
        {
            var new_node = new TreeNode(name) {
                                                  ImageKey = icon.name_of_the_icon,
                                                  SelectedImageKey = icon.name_of_the_icon
                                              };
            node.Nodes.Add(new_node);
            return new tree_branch(new_node, command);
        }

        private void Click()
        {
            if (node.Equals(node.TreeView.SelectedNode)) {
                node.Expand();
                the_command.run();
                node.BackColor = Color.HotPink;
            }
            else {
                node.BackColor = Color.Empty;
            }
        }
    }
}