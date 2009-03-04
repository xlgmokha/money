using jpboodhoo.bdd.contexts;
using MyMoney.Presentation.Core;
using MyMoney.Presentation.Presenters.Commands;
using MyMoney.Presentation.Views.Shell;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Presenters.Shell
{
    [Concern(typeof (LoadApplicationShell))]
    public class when_loading_the_application_shell : concerns_for<ILoadApplicationShellCommand, LoadApplicationShell>
    {
        it should_initialize_all_the_application_shell_presenters =
            () => controller.was_told_to(x => x.run(correct_presenter));

        it should_not_initialize_any_presenters_that_are_not_part_of_the_main_application_shell =
            () => controller.should_not_have_been_asked_to(x => x.run(incorrect_presenter));

        context c = () =>
                        {
                            registry = the_dependency<IPresenterRegistry>();
                            controller = the_dependency<IApplicationController>();
                            shell = the_dependency<IShell>();

                            correct_presenter = an<IPresentationModule>();
                            incorrect_presenter = an<IPresenter>();

                            when_the(registry)
                                .is_told_to(r => r.all())
                                .it_will_return(correct_presenter, incorrect_presenter);
                        };

        because b = () => sut.run();

        //public override ILoadApplicationShellCommand create_sut()
        //{
        //    return new LoadApplicationShell(registry, controller, shell);
        //}

        static IPresenterRegistry registry;
        static IPresentationModule correct_presenter;
        static IPresenter incorrect_presenter;
        static IApplicationController controller;
        static IShell shell;
    }
}