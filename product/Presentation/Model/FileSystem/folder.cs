namespace MoMoney.Presentation.Model.FileSystem
{
    public interface IFolder
    {
        string path { get; }
    }

    internal class folder : IFolder
    {
        public folder(string path)
        {
            this.path = path;
        }

        public string path { get; private set; }

        public override string ToString()
        {
            return path;
        }

        public bool Equals(folder obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return ReferenceEquals(this, obj) || Equals(obj.path, path);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof (folder) && Equals((folder) obj);
        }

        public override int GetHashCode()
        {
            return (path != null ? path.GetHashCode() : 0);
        }
    }
}