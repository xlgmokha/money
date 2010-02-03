using System;
using developwithpassion.bdd.contexts;
using Gorilla.Commons.Infrastructure.FileSystem;
using gorilla.commons.utility;
using momoney.presentation.model.eventing;
using MoMoney.Presentation.Model.Projects;
using momoney.service.infrastructure;
using MoMoney.Service.Infrastructure.Eventing;
using momoney.service.infrastructure.transactions;

namespace tests.unit.client.presentation.model
{
    public class ProjectControllerSpecs
    {
        [Concern(typeof (ProjectController))]
        public abstract class behaves_like_a_project : concerns_for<IProjectController, ProjectController>
        {
            context c = () =>
            {
                broker = the_dependency<EventAggregator>();
                tasks = the_dependency<IProjectTasks>();
            };

            static protected EventAggregator broker;
            static protected IProjectTasks tasks;
        }

        public class when_saving_the_current_project : behaves_like_a_project
        {
            it should_notify_the_rest_of_the_application = () => broker.was_told_to(x => x.publish<SavedChangesEvent>());

            context c = () =>
            {
                file_to_update = an<File>();
                when_the(file_to_update).is_told_to(x => x.does_the_file_exist()).it_will_return(true);
            };

            because b = () =>
            {
                sut.open_project_from(file_to_update);
                sut.save_changes();
            };

            static File file_to_update;
        }

        public class when_attempting_to_save_the_changes_to_a_project_and_a_file_to_save_to_has_not_been_specified :
            behaves_like_a_project
        {
            it should_inform_the_user_of_an_error = () => the_call.should_have_thrown<FileNotSpecifiedException>();

            because b = () =>
            {
                the_call = call.to(() => sut.save_changes());
            };

            static Action the_call;
        }

        public class when_specifying_a_new_path_to_save_an_opened_project_to : behaves_like_a_project
        {
            it should_save_the_current_database_to_the_new_path = () => tasks.was_told_to(x => x.copy_to("blah"));

            context c = () =>
            {
                original_file = an<File>();
                new_file = an<File>();
                when_the(new_file).is_told_to(x => x.path).it_will_return("blah");
            };

            because b = () =>
            {
                sut.open_project_from(original_file);
                sut.save_project_to(new_file);
            };

            static File original_file;
            static File new_file;
        }

        public class when_attempting_to_open_an_invalid_project_file_path : behaves_like_a_project
        {
            it should_not_change_the_current_working_file = () => result.should_be_equal_to(false);

            context c = () =>
            {
                invalid_file = an<File>();
                when_the(invalid_file).is_told_to(x => x.does_the_file_exist()).it_will_return(false);
            };

            because b = () =>
            {
                sut.open_project_from(invalid_file);
                result = sut.has_been_saved_at_least_once();
            };

            static File invalid_file;
            static bool result;
        }

        public class when_attempting_to_save_all_changes_to_a_new_file_with_an_invalid_path : behaves_like_a_project
        {
            it should_not_change_the_current_file_to_the_invalid_one = () => result.should_be_equal_to(false);

            context c = () =>
            {
                invalid_file = an<File>();

                when_the(invalid_file).is_told_to(x => x.path).it_will_return(string.Empty);
            };

            because b = () =>
            {
                sut.save_project_to(invalid_file);
                result = sut.has_been_saved_at_least_once();
            };

            static File invalid_file;
            static bool result;
        }

        public class when_opening_a_new_file : behaves_like_a_project
        {
            context c = () =>
            {
                file = an<File>();
                when_the(file).is_told_to(x => x.does_the_file_exist()).it_will_return(true);
            };

            because b = () => sut.open_project_from(file);

            static File file;
        }

        public class when_checking_if_there_are_any_unsaved_changes_and_a_project_is_not_open : behaves_like_a_project
        {
            it should_return_false = () => result.should_be_equal_to(false);

            because b = () =>
            {
                result = sut.has_unsaved_changes();
            };

            static bool result;
        }

        public class when_checking_if_there_are_any_unsaved_changes_and_there_are : behaves_like_a_project
        {
            it should_return_true = () => result.should_be_true();

            context c = () =>
            {
                unit_of_work = an<IUnitOfWork>();
                when_the(unit_of_work).is_told_to(x => x.is_dirty()).it_will_return(true);
            };

            because b = () =>
            {
                sut.downcast_to<ProjectController>().run(unit_of_work);
                result = sut.has_unsaved_changes();
            };

            static bool result;
            static IUnitOfWork unit_of_work;
        }

        public class when_starting_a_new_project_and_a_project_was_already_open : behaves_like_a_project
        {
            it should_close_the_previous_project = () => broker.was_told_to(x => x.publish<ClosingProjectEvent>());

            because b = () =>
            {
                sut.start_new_project();
                sut.start_new_project();
            };
        }

        public class when_opening_an_existing_project_and_a_project_was_already_open : behaves_like_a_project
        {
            it should_close_the_previous_project = () => broker.was_told_to(x => x.publish<ClosingProjectEvent>());

            context c = () =>
            {
                file = an<File>();
                when_the(file).is_told_to(x => x.does_the_file_exist()).it_will_return(true);
            };

            because b = () =>
            {
                sut.open_project_from(file);
                sut.start_new_project();
            };

            static File file;
        }
    }
}