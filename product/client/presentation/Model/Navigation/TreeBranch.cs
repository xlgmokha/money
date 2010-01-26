using System;
using System.Drawing;
using System.Windows.Forms;
using gorilla.commons.utility;
using MoMoney.Presentation.Winforms.Resources;

namespace MoMoney.Presentation.Model.Navigation
{
    public class TreeBranch : ITreeBranch
    {
        readonly TreeNode node;
        readonly Command the_command;

        public TreeBranch(TreeNode node, Command the_command)
        {
            this.node = node;
            this.the_command = the_command;
            this.node.TreeView.DoubleClick += (sender, e) => Click();
        }

        public void accept(Visitor<ITreeBranch> visitor)
        {
            visitor.visit(this);
        }

        public ITreeBranch add_child(string name, ApplicationIcon icon, Command command)
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
            return add_child(name, icon, new AnonymousCommand(command));
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