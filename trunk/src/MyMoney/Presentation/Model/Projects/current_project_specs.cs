using System;
using jpboodhoo.bdd.contexts;
using MyMoney.DataAccess.db40;
using MyMoney.Infrastructure.eventing;
using MyMoney.Testing;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Testing.spechelpers.contexts;
using mocking_extensions=MyMoney.Testing.spechelpers.core.mocking_extensions;

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
            () => mocking_extensions.was_told_to(current_file, x => x.copy_to(file_to_update));

        context c = () =>
                        {
                            file_to_update = an<IFile>();
                            current_file = an<IFile>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(configuration), x => x.path_to_the_database()), current_file);
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(file_to_update), x => x.does_the_file_exist()), true);
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
        it should_save_the_current_database_to_the_new_path = () => mocking_extensions.was_told_to(database_file, x => x.copy_to(new_file));

        context c = () =>
                        {
                            original_file = an<IFile>();
                            new_file = an<IFile>();
                            database_file = an<IFile>();

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(configuration), x => x.path_to_the_database()), database_file);
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(new_file), x => x.path), "blah");
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
                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(invalid_file), x => x.does_the_file_exist()), false);
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

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(invalid_file), x => x.path), string.Empty);
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

                            mocking_extensions.it_will_return(mocking_extensions.is_told_to(when_the(file), x => x.does_the_file_exist()), true);
                        };

        because b = () => sut.open(file);

        static IFile file;
    }
}