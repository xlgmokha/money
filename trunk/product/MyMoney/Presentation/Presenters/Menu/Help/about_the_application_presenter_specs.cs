using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Views.Menu.Help;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Menu.Help
{
    [Concern(typeof (about_the_application_presenter))]
    public abstract class behaves_like_the_application_information_presenter :
        concerns_for<IAboutApplicationPresenter, about_the_application_presenter>
    {
        //public override IAboutApplicationPresenter create_sut()
        //{
        //    return new about_the_application_presenter(view);
        //}

        context c = () => { view = the_dependency<IAboutApplicationView>(); };

        static protected IAboutApplicationView view;
    }

    public class when_initializing_the_application_information_presenter :
        behaves_like_the_application_information_presenter
    {
        because b = () => sut.run();

        it should_display_the_view = () => view.was_told_to(x => x.display());
    }
}