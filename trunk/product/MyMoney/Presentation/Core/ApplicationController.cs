using System;
using System.Collections.Generic;
using MoMoney.Infrastructure.Extensions;
using MoMoney.Presentation.Views.Shell;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;

namespace MoMoney.Presentation.Core
{
    public interface IApplicationController
    {
        void run<Presenter>() where Presenter : IPresenter;
    }

    public class ApplicationController : IApplicationController, IParameterizedCommand<IPresenter>
    {
        readonly IPresenterRegistry registered_presenters;
        readonly IShell shell;
        //readonly IDictionary<Type, IPresenter> open_presenters;
        //readonly object mutex = new object();

        public ApplicationController(IPresenterRegistry registered_presenters, IShell shell)
        {
            this.registered_presenters = registered_presenters;
            this.shell = shell;
            //open_presenters = new Dictionary<Type, IPresenter>();
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            //if (open_presenters.ContainsKey(typeof (Presenter)))
            //{
            //    this.log().debug("from cached presenter: {0}", typeof (Presenter));
            //    run(open_presenters[typeof (Presenter)]);
            //}
            //else
            //{
            //    if (typeof (IContentPresenter).IsAssignableFrom(typeof (Presenter)))
            //    {
            //        this.log().debug("adding presenter to cache: {0}", typeof (Presenter));
            //        var presenter = registered_presenters.find_an_implementation_of<IPresenter, Presenter>();
            //        within_lock(() => open_presenters.Add(typeof (Presenter), presenter));
            //        run(presenter);
            //    }
            //    else
            //    {
            //        this.log().debug("running uncached presenter: {0}", typeof (Presenter));
            run(registered_presenters.find_an_implementation_of<IPresenter, Presenter>());
            //}
            //}
        }

        //void within_lock(Action action)
        //{
        //    lock (mutex) action();
        //}

        public void run(IPresenter presenter)
        {
            presenter.run();
            if (presenter.is_an_implementation_of<IContentPresenter>())
            {
                var content_presenter = presenter.downcast_to<IContentPresenter>();
                var view = content_presenter.View;

                view.on_activated = x => content_presenter.activate();
                view.on_deactivate = x => content_presenter.deactivate();
                view.on_closing = x => x.Cancel = !content_presenter.can_close();
                //view.on_closed = x => remove(presenter);

                shell.add(view);
            }
        }

        //void remove<Presenter>(Presenter presenter) where Presenter : IPresenter
        //{
        //    this.log().debug("removing {0}", presenter);
        //    within_lock(() => open_presenters.Remove(typeof (Presenter)));
        //}
    }
}