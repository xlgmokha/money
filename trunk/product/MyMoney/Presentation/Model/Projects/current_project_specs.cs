using System;
using jpboodhoo.bdd.contexts;
using MyMoney.DataAccess.db40;
using MyMoney.Infrastructure.eventing;
using MyMoney.Presentation.Model.messages;
using MyMoney.Testing;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using MyMoney.Testing.spechelpers.core;

namespace MyMoney.Presentation.Model.Projects
{
    [Concern(typeof (current_project))]
    public abstract class behaves_like_a_project : concerns_for<IProject, current_project>
    {
        public override IProject create_sut()
        {
            return new current_project(configuration, broker);
        }

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
        it should_save_the_current_database_to_the_path_specified_by_the_user =
            () => current_file.was_told_to(x => x.copy_to(file_to_update));

        context c = () =>
                        {
                            file_to_update = an<IFile>();
                            current_file = an<IFile>();

                            when_the(configuration).is_told_to(x => x.path_to_the_database()).
                                it_will_return(current_file);
                            when_the(file_to_update).is_told_to(x => x.does_the_file_exist()).
                                it_will_return(true);
                        };

        because b = () =>
                        {
                            sut.open(file_to_update);
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
        it should_save_the_current_database_to_the_new_path =
            () => database_file.was_told_to(x => x.copy_to(new_file));

        context c = () =>
                        {
                            original_file = an<IFile>();
                            new_file = an<IFile>();
                            database_file = an<IFile>();

                            when_the(configuration).is_told_to(x => x.path_to_the_database()).
                                it_will_return(database_file);
                            when_the(new_file).is_told_to(x => x.path).it_will_return("blah");
                        };

        because b = () =>
                        {
                            sut.open(original_file);
                            sut.save_to(new_file);
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
                            sut.open(invalid_file);
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
                            sut.save_to(invalid_file);
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

        because b = () => sut.open(file);

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
                            sut.start_a_new_project();
                            sut.save_to(file);
                            sut.notify(message);
                            result = sut.has_unsaved_changes();
                        };

        static bool result;
        static IFile file;
        static unsaved_changes_event message;
    }
}