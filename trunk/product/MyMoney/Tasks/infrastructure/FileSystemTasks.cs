using System;
using Castle.Core;
using MoMoney.Infrastructure.interceptors;
using MoMoney.Presentation.Model.file_system;

namespace MoMoney.Tasks.infrastructure
{
    public interface IFileSystemTasks
    {
        IFolder the_currently_selected_folder();
        void select(IFolder new_folder);
    }

    [Interceptor(typeof (IUnitOfWorkInterceptor))]
    [Singleton]
    public class FileSystemTasks : IFileSystemTasks
    {
        private IFolder current_folder;

        public FileSystemTasks()
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