using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using gorilla.commons.utility;
using Rhino.Mocks;

namespace MoMoney.Presentation.Model.Navigation
{
    public class TreeBranchSpecs {}

    [Concern(typeof (TreeBranch))]
    public abstract class behaves_like_a_tree_branch : concerns_for<ITreeBranch, TreeBranch>
    {
        context c = () =>
        {
            command = the_dependency<Command>();
            tree_node = dependency<TreeNode>();
        };

        public override ITreeBranch create_sut()
        {
            return new TreeBranch(tree_node, command);
        }

        static protected TreeNode tree_node;
        static protected Command command;
    }

    public class when_accepting_a_visitor_that_visits_tree_nodes : behaves_like_a_tree_branch
    {
        it should_allow_the_visitor_to_visit_it = () => visitor.was_told_to(x => x.visit(sut));

        context c = () =>
        {
            visitor = an<Visitor<ITreeBranch>>();
            var tree_view = dependency<TreeView>();
            when_the(tree_node).is_told_to(x => x.TreeView).it_will_return(tree_view);
        };

        because b = () => sut.accept(visitor);

        static Visitor<ITreeBranch> visitor;
    }

    public class when_a_tree_node_is_clicked : behaves_like_a_tree_branch
    {
        it should_execute_the_command_that_is_bound_to_the_node = () => command.was_told_to(x => x.run());

        context c = () =>
        {
            tree = dependency<TreeView>();
            when_the(tree_node).is_told_to(x => x.TreeView).it_will_return(tree);
            when_the(tree).is_told_to(x => x.SelectedNode).it_will_return(tree_node);
        };

        because b = () => tree.Raise(x => x.DoubleClick += null, tree, null);

        static TreeView tree;
    }
}