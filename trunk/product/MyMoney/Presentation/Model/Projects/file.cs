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

    internal class ApplicationFile : IFile
    {
        public ApplicationFile(string path)
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

        public static implicit operator ApplicationFile(string file_path)
        {
            return new ApplicationFile(file_path);
        }

        public static implicit operator string(ApplicationFile file)
        {
            return file.path;
        }

        public bool Equals(ApplicationFile obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj.path, path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (ApplicationFile)) return false;
            return Equals((ApplicationFile) obj);
        }

        public override int GetHashCode()
        {
            return (path != null ? path.GetHashCode() : 0);
        }
    }
}