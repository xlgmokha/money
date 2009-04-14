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

        public ApplicationController(IPresenterRegistry registered_presenters, IShell shell)
        {
            this.registered_presenters = registered_presenters;
            this.shell = shell;
            //open_presenters = new Dictionary<Type, IPresenter>();
        }

        public void run<Presenter>() where Presenter : IPresenter
        {
            //if (open_presenters.ContainsKey(typeof(Presenter)))
            //{
            //    this.log().debug("from cached presenter: {0}", typeof(Presenter));
            //    run(open_presenters[typeof(Presenter)]);
            //}
            //else
            //{
                //this.log().debug("adding presenter to cache: {0}", typeof (Presenter));
                var presenter = registered_presenters.find_an_implementation_of<IPresenter, Presenter>();
                //open_presenters.Add(typeof (Presenter), presenter);
                run(presenter);
            //}
        }

        public void run(IPresenter presenter)
        {
            presenter.run();
            if (presenter.is_an_implementation_of<IContentPresenter>())
                shell.add(presenter.downcast_to<IContentPresenter>().View);
        }
    }
}