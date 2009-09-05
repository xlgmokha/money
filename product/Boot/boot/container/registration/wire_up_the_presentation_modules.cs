using System;
using System.Collections.Generic;
using System.Reflection;
using Gorilla.Commons.Infrastructure;
using Gorilla.Commons.Infrastructure.Reflection;
using Gorilla.Commons.Utility.Core;
using Gorilla.Commons.Utility.Extensions;
using MoMoney.boot.container.registration.proxy_configuration;
using MoMoney.DTO;
using MoMoney.Presentation;
using MoMoney.Presentation.Core;
using MoMoney.Presentation.Model.Menu.File;
using MoMoney.Presentation.Model.Menu.Help;
using MoMoney.Presentation.Model.Menu.window;
using MoMoney.Presentation.Presenters;
using MoMoney.Presentation.Presenters.Commands;
using MoMoney.Presentation.Views;
using MoMoney.Service.Contracts.Application;

namespace MoMoney.boot.container.registration
{
    class wire_up_the_presentation_modules : ICommand, IParameterizedCommand<IAssembly>
    {
        readonly IDependencyRegistration registry;

        public wire_up_the_presentation_modules(IDependencyRegistration registry)
        {
            this.registry = registry;
        }

        public void run()
        {
            run(new ApplicationAssembly(Assembly.GetExecutingAssembly()));
        }

        public void run(IAssembly item)
        {
            Func<IApplicationController> target =
                () => new ApplicationController(Lazy.load<IPresenterRegistry>(), Lazy.load<IShell>());
            registry.proxy<IApplicationController, SynchronizedConfiguration<IApplicationController>>(target.memorize());
            registry.transient(typeof (IRunThe<>), typeof (RunThe<>));
            registry.transient(typeof (IPresenter), typeof (ReportPresenter<IViewAllBillsReport,IEnumerable<BillInformationDTO>,IGetAllBillsQuery>));
            registry.transient<IFileMenu, FileMenu>();
            registry.transient<IWindowMenu, WindowMenu>();
            registry.transient<IHelpMenu, HelpMenu>();

            item
                .all_types()
                .where(x => typeof (IPresenter).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .where(x => !x.IsGenericType)
                .each(type => registry.transient(typeof (IPresenter), type));

            item
                .all_types()
                .where(x => typeof (IModule).IsAssignableFrom(x))
                .where(x => !x.IsInterface)
                .where(x => !x.IsAbstract)
                .where(x => !x.IsGenericType)
                .each(type => registry.transient(typeof (IModule), type));
        }
    }
}