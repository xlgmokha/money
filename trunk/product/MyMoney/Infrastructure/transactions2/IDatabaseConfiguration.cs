using MoMoney.Presentation.Model.Projects;

namespace MoMoney.Infrastructure.transactions2
{
    public interface IDatabaseConfiguration
    {
        void open(IFile file);
        void copy_to(string path);
    }
}