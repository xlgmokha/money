using System;
using Castle.Core;
using MyMoney.Infrastructure.interceptors;
using MyMoney.Presentation.Model.file_system;

namespace MyMoney.Tasks.application
{
    public interface IFileSystemTasks
    {
        IFolder the_currently_selected_folder();
        void select(IFolder new_folder);
    }

    [Interceptor(typeof (IUnitOfWorkInterceptor))]
    [Singleton]
    public class file_system_tasks : IFileSystemTasks
    {
        private IFolder current_folder;

        public file_system_tasks()
        {
            current_folder = new folder(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer));
        }

        public IFolder the_currently_selected_folder()
        {
            return current_folder;
        }

        public void select(IFolder new_folder)
        {
            current_folder = new_folder;
        }
    }
}