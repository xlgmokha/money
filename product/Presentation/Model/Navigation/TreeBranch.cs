using System;
using System.Drawing;
using System.Windows.Forms;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Windows.Forms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class TreeBranch : ITreeBranch
    {
        readonly TreeNode node;
        readonly ICommand the_command;

        public TreeBranch(TreeNode node, ICommand the_command)
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
            var new_node = new TreeNode(name)
                               {
                                   ImageKey = icon.name_of_the_icon,
                                   SelectedImageKey = icon.name_of_the_icon
                               };
            node.Nodes.Add(new_node);
            return new TreeBranch(new_node, command);
        }

        public ITreeBranch add_child(string name, ApplicationIcon icon, Action command)
        {
            return add_child(name, icon, new ActionCommand(command));
        }

        void Click()
        {
            if (node.Equals(node.TreeView.SelectedNode))
            {
                node.Expand();
                the_command.run();
                node.BackColor = Color.HotPink;
            }
            else
            {
                node.BackColor = Color.Empty;
            }
        }
    }
}