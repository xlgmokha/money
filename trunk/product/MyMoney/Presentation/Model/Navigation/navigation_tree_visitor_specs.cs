using System.Windows.Forms;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Model.Navigation
{
    [Concern(typeof (NavigationTreeVisitor))]
    public abstract class behaves_like_a_navigation_tree_visitor :
        concerns_for<INavigationTreeVisitor, NavigationTreeVisitor>
    {
        //public override INavigationTreeVisitor create_sut()
        //{
        //    return new NavigationTreeVisitor(factory, registry);
        //}

        context c = () =>
                        {
                            factory = the_dependency<ITreeViewToRootNodeMapper>();
                            registry = the_dependency<IRegistry<IBranchVisitor>>();
                        };

        static protected ITreeViewToRootNodeMapper factory;
        static protected IRegistry<IBranchVisitor> registry;
    }

    public class when_visiting_the_navigation_tree : behaves_like_a_navigation_tree_visitor
    {
        it should_visit_each_of_the_tree_node_visitors = () =>
                                                             {
                                                                 root_node.was_told_to(x => x.accept(first_visitor));
                                                                 root_node.was_told_to(x => x.accept(second_visitor));
                                                             };

        context c = () =>
                        {
                            tree_view = dependency<TreeView>();
                            root_node = an<ITreeBranch>();
                            first_visitor = an<IBranchVisitor>();
                            second_visitor = an<IBranchVisitor>();

                            when_the(factory)
                                .is_told_to(x => x.map_from(tree_view))
                                .it_will_return(root_node);

                            when_the(registry)
                                .is_told_to(x => x.all())
                                .it_will_return(first_visitor, second_visitor);
                        };

        because b = () => sut.visit(tree_view);

        static TreeView tree_view;
        static ITreeBranch root_node;
        static IBranchVisitor first_visitor;
        static IBranchVisitor second_visitor;
    }
}