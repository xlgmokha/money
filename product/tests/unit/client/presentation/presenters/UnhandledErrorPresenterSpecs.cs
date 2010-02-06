using System;
using momoney.presentation.model.eventing;
using momoney.presentation.presenters;
using momoney.presentation.views;
using MoMoney.Service.Infrastructure.Eventing;

namespace tests.unit.client.presentation.presenters
{
    public class behaves_like_unhandled_error_presenter : tests_for<UnhandledErrorPresenter>
    {
        context c = () =>
        {
            view = dependency<IUnhandledErrorView>();
            broker = dependency<EventAggregator>();
        };

        static protected IUnhandledErrorView view;
        static protected EventAggregator broker;
    }

    public class when_an_error_occurs_in_the_application : behaves_like_unhandled_error_presenter
    {
        it should_display_the_error = () => view.was_told_to(x => x.display(error));

        because b = () => sut.notify(new UnhandledErrorOccurred(error));

        static readonly Exception error = new Exception();
    }
}