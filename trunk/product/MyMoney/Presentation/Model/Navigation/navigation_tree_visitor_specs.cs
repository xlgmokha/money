using System.Windows.Forms;
using jpboodhoo.bdd.contexts;
using MoMoney.Infrastructure.Container;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Model.Navigation
{
    [Concern(typeof (navigation_tree_visitor))]
    public abstract class behaves_like_a_navigation_tree_visitor :
        concerns_for<INavigationTreeVisitor, navigation_tree_visitor>
    {
        public override INavigationTreeVisitor create_sut()
        {
            return new navigation_tree_visitor(factory, registry);
        }

        context c = () =>
                        {
                            factory = the_dependency<ITreeViewToRootNodeMapper>();
                            registry = the_dependency<IDependencyRegistry>();
                        };

        protected static ITreeViewToRootNodeMapper factory;
        protected static IDependencyRegistry registry;
    }

    public class when_visiting_the_navigation_tree : behaves_like_a_navigation_tree_visitor
    {
        it should_visit_each_of_the_tree_node_visitors = () =>
                                                             {
                                                                 root_node.was_told_to(x => x.accept(first_node_visitor));
                                                                 root_node.was_told_to( x => x.accept(second_node_visitor));
                                                             };

        context c = () =>
                        {
                            tree_view = dependency<TreeView>();
                            root_node = an<ITreeBranch>();
                            first_node_visitor = an<IBranchVisitor>();
                            second_node_visitor = an<IBranchVisitor>();

                            when_the(factory)
                                .is_told_to(x => x.map_from(tree_view))
                                .it_will_return(root_node);

                            when_the(registry)
                                .is_told_to(x => x.all_the<IBranchVisitor>())
                                .it_will_return(first_node_visitor, second_node_visitor);
                        };

        because b = () => sut.visit(tree_view);

        static TreeView tree_view;
        static ITreeBranch root_node;
        static IBranchVisitor first_node_visitor;
        static IBranchVisitor second_node_visitor;
    }
}