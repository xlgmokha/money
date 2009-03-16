using System;
using developwithpassion.bdd.contexts;
using MoMoney.DataAccess.db40;
using MoMoney.Infrastructure.eventing;
using MoMoney.Presentation.Model.messages;
using MoMoney.Testing;
using MoMoney.Testing.MetaData;
using MoMoney.Testing.spechelpers.contexts;
using MoMoney.Testing.spechelpers.core;

namespace MoMoney.Presentation.Model.Projects
{
    [Concern(typeof (CurrentProject))]
    public abstract class behaves_like_a_project : concerns_for<IProject, CurrentProject>
    {
        context c = () =>
                        {
                            configuration = the_dependency<IDatabaseConfiguration>();
                            broker = the_dependency<IEventAggregator>();
                        };

        protected static IDatabaseConfiguration configuration;
        protected static IEventAggregator broker;
    }

    public class when_saving_the_current_project : behaves_like_a_project
    {
        it should_notify_the_rest_of_the_application = () => broker.was_told_to(x => x.publish<saved_changes_event>());

        context c = () =>
                        {
                            file_to_update = an<IFile>();
                            current_file = an<IFile>();

                            when_the(configuration).is_told_to(x => x.path_to_the_database()). it_will_return(current_file);
                            when_the(file_to_update).is_told_to(x => x.does_the_file_exist()). it_will_return(true);
                        };

        because b = () =>
                        {
                            sut.open_project_from(file_to_update);
                            sut.save_changes();
                        };

        static IFile file_to_update;
        static IFile current_file;
    }

    public class when_attempting_to_save_the_changes_to_a_project_and_a_file_to_save_to_has_not_been_specified :
        behaves_like_a_project
    {
        it should_inform_the_user_of_an_error = () => the_call.should_have_thrown<file_not_specified_exception>();

        because b = () => { the_call = call.to(() => sut.save_changes()); };

        static Action the_call;
    }

    public class when_specifying_a_new_path_to_save_an_opened_project_to : behaves_like_a_project
    {
        it should_save_the_current_database_to_the_new_path = () => configuration.was_told_to(x => x.change_path_to(new_file));

        context c = () =>
                        {
                            original_file = an<IFile>();
                            new_file = an<IFile>();
                            database_file = an<IFile>();
                            when_the(new_file).is_told_to(x => x.path).it_will_return("blah");
                        };

        because b = () =>
                        {
                            sut.open_project_from(original_file);
                            sut.save_project_to(new_file);
                        };

        static IFile original_file;
        static IFile database_file;
        static IFile new_file;
    }

    public class when_attempting_to_open_an_invalid_project_file_path : behaves_like_a_project
    {
        it should_not_change_the_current_working_file = () => result.should_be_equal_to(false);

        context c = () =>
                        {
                            invalid_file = an<IFile>();
                            when_the(invalid_file).is_told_to(x => x.does_the_file_exist()).it_will_return(false);
                        };

        because b = () =>
                        {
                            sut.open_project_from(invalid_file);
                            result = sut.has_been_saved_at_least_once();
                        };

        static IFile invalid_file;
        static bool result;
    }

    public class when_attempting_to_save_all_changes_to_a_new_file_with_an_invalid_path : behaves_like_a_project
    {
        it should_not_change_the_current_file_to_the_invalid_one = () => result.should_be_equal_to(false);

        context c = () =>
                        {
                            invalid_file = an<IFile>();

                            when_the(invalid_file).is_told_to(x => x.path).it_will_return(string.Empty);
                        };

        because b = () =>
                        {
                            sut.save_project_to(invalid_file);
                            result = sut.has_been_saved_at_least_once();
                        };

        static IFile invalid_file;
        static bool result;
    }

    public class when_opening_a_new_file : behaves_like_a_project
    {
        context c = () =>
                        {
                            file = an<IFile>();
                            when_the(file).is_told_to(x => x.does_the_file_exist()).it_will_return(true);
                        };

        because b = () => sut.open_project_from(file);

        static IFile file;
    }

    public class when_checking_if_there_are_any_unsaved_changes_and_a_project_is_not_open : behaves_like_a_project
    {
        it should_return_false = () => result.should_be_equal_to(false);

        because b = () => { result = sut.has_unsaved_changes(); };

        static bool result;
    }

    public class when_checking_if_there_are_any_unsaved_changes_and_there_are : behaves_like_a_project
    {
        it should_return_true = () => result.should_be_true();

        context c = () =>
                        {
                            file = an<IFile>();
                            message = new unsaved_changes_event();
                        };

        because b = () =>
                        {
                            sut.start_new_project();
                            sut.save_project_to(file);
                            //sut.notify(message);
                            result = sut.has_unsaved_changes();
                        };

        static bool result;
        static IFile file;
        static unsaved_changes_event message;
    }

    public class when_starting_a_new_project_and_a_project_was_already_open : behaves_like_a_project
    {
        it should_close_the_previous_project = () => broker.was_told_to(x => x.publish<closing_project_event>());

        because b = () =>
                        {
                            sut.start_new_project();
                            sut.start_new_project();
                        };
    }

    public class when_opening_an_existing_project_and_a_project_was_already_open : behaves_like_a_project
    {
        it should_close_the_previous_project = () => broker.was_told_to(x => x.publish<closing_project_event>());

        context c = () =>
                        {
                            file = an<IFile>();
                            when_the(file).is_told_to(x => x.does_the_file_exist()).it_will_return(true);
                        };

        because b = () =>
                        {
                            sut.open_project_from(file);
                            sut.start_new_project();
                        };

        static IFile file;
    }
}