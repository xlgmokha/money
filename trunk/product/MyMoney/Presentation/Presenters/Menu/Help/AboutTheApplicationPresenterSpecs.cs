using developwithpassion.bdd.contexts;
using MoMoney.Presentation.Views.Menu.Help;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Presenters.Menu.Help
{
    [Concern(typeof (AboutTheApplicationPresenter))]
    public abstract class behaves_like_the_application_information_presenter :
        concerns_for<IAboutApplicationPresenter, AboutTheApplicationPresenter>
    {
        context c = () => { view = the_dependency<IAboutApplicationView>(); };

        protected static IAboutApplicationView view;
    }

    public class when_initializing_the_application_information_presenter :
        behaves_like_the_application_information_presenter
    {
        because b = () => sut.run();

        it should_display_the_view = () => view.was_told_to(x => x.display());
    }
}