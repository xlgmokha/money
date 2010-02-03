using System;
using developwithpassion.bdd.contexts;
using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace tests.unit.client.presentation.presenters
{
    public class behaves_like_unhandled_error_presenter : concerns_for<UnhandledErrorPresenter>
    {
        context c = () =>
        {
            view = the_dependency<IUnhandledErrorView>();
            broker = the_dependency<EventAggregator>();
        };

        protected static IUnhandledErrorView view;
        protected static EventAggregator broker;
    }

    public class when_an_error_occurs_in_the_application : behaves_like_unhandled_error_presenter
    {
        it should_display_the_error = () => view.was_told_to(x => x.display(error));

        because b = () => sut.notify(new UnhandledErrorOccurred(error));

        static readonly Exception error = new Exception();
    }
}