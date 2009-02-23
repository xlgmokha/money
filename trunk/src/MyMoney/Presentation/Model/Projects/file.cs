using System.IO;
using MyMoney.Infrastructure.Extensions;

namespace MyMoney.Presentation.Model.Projects
{
    public interface IFile
    {
        void copy_to(IFile file_to_overwrite);
        string path { get; }
        bool does_the_file_exist();
    }

    internal class file : IFile
    {
        public file(string path)
        {
            this.path = path;
        }

        public string path { get; private set; }

        public bool does_the_file_exist()
        {
            return !string.IsNullOrEmpty(path) && File.Exists(path);
        }

        public void copy_to(IFile file_to_overwrite)
        {
            this.log().debug("copying file {0} to {1}", path, file_to_overwrite.path);
            File.Copy(path, file_to_overwrite.path, true);
        }

        public static implicit operator file(string file_path)
        {
            return new file(file_path);
        }

        public static implicit operator string(file file)
        {
            return file.path;
        }

        public bool Equals(file obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.path, path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (file)) return false;
            return Equals((file) obj);
        }

        public override int GetHashCode()
        {
            return (path != null ? path.GetHashCode() : 0);
        }
    }
}