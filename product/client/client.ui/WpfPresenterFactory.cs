using Gorilla.Commons.Infrastructure.Container;

namespace presentation.windows
{
    public class WpfPresenterFactory : PresenterFactory
    {
        public T create<T>() where T : Presenter
        {
            return Resolve.the<T>();
        }
    }
}