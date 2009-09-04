using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.Eventing;
using Gorilla.Commons.Testing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Presentation.Views.Shell;

namespace MoMoney.Presentation.Presenters.Shell
{
    public class behaves_like_unhandled_error_presenter :
        concerns_for<IUnhandledErrorPresenter, UnhandledErrorPresenter>
    {
        //public override IUnhandledErrorPresenter create_sut()
        //{
        //    return new UnhandledErrorPresenter(view, broker);
        //}

        context c = () =>
                        {
                            view = the_dependency<IUnhandledErrorView>();
                            broker = the_dependency<IEventAggregator>();
                        };

        protected static IUnhandledErrorView view;
        protected static IEventAggregator broker;
    }

    public class when_the_presenter_is_run : behaves_like_unhandled_error_presenter
    {
        it should_listen_for_any_errors_in_the_application = () => broker.was_told_to(x => x.subscribe_to(sut));

        because b = () => sut.run();
    }

    public class when_an_error_occurs_in_the_application : behaves_like_unhandled_error_presenter
    {
        it should_display_the_error = () => view.was_told_to(x => x.display(error));

        because b = () => sut.notify(new UnhandledErrorOccurred(error));

        static readonly Exception error = new Exception();
    }
}