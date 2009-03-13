using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Model.Navigation;
using MoMoney.Presentation.Views.Navigation;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Navigation
{
    [Concern(typeof (NavigationPresenter))]
    public class when_building_the_navigation_tree : concerns_for<INavigationPresenter, NavigationPresenter>
    {
        it should_visit_the_root_node_of_the_tree = () => view.was_told_to(x => x.accept(tree_view_visitor));

        context c = () =>
                        {
                            view = the_dependency<INavigationView>();
                            tree_view_visitor = the_dependency<INavigationTreeVisitor>();
                        };

        because b = () => sut.run();

        static INavigationView view;
        static INavigationTreeVisitor tree_view_visitor;
    }
}