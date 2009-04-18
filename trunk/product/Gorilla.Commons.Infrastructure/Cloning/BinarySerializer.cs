using System.Runtime.Serialization.Formatters.Binary;

namespace MoMoney.Infrastructure.cloning
{
    public class BinarySerializer<T> : Serializer<T>
    {
        public BinarySerializer(string file_path) : base(file_path, new BinaryFormatter())
        {
        }
    }
}