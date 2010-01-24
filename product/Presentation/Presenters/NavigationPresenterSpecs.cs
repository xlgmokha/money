using developwithpassion.bdd.contexts;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Model.Navigation;
using momoney.presentation.views;

namespace momoney.presentation.presenters
{
    [Concern(typeof (NavigationPresenter))]
    public class when_building_the_navigation_tree : concerns_for< NavigationPresenter>
    {
        it should_visit_the_root_node_of_the_tree = () => view.was_told_to(x => x.accept(tree_view_visitor));

        context c = () =>
        {
            view = the_dependency<INavigationView>();
            tree_view_visitor = the_dependency<INavigationTreeVisitor>();
        };

        because b = () => sut.present();

        static INavigationView view;
        static INavigationTreeVisitor tree_view_visitor;
    }
}