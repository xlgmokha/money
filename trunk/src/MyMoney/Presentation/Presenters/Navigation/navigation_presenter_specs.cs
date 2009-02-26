using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Model.Navigation;
using MyMoney.Presentation.Views.Navigation;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Navigation
{
    [Concern(typeof (navigation_presenter))]
    public class when_building_the_navigation_tree : concerns_for<INavigationPresenter, navigation_presenter>
    {
        it should_visit_the_root_node_of_the_tree = () => view.was_told_to(x => x.accept(tree_view_visitor));

        context c = () =>
                        {
                            view = an<INavigationView>();
                            tree_view_visitor = an<INavigationTreeVisitor>();
                        };

        because b = () => sut.run();

        public override INavigationPresenter create_sut()
        {
            return new navigation_presenter(view, tree_view_visitor);
        }

        static INavigationView view;
        static INavigationTreeVisitor tree_view_visitor;
    }
}