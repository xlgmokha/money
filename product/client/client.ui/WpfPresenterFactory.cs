using Gorilla.Commons.Infrastructure.Container;

namespace presentation.windows
{
    public class WpfPresenterFactory : PresenterFactory
    {
        DependencyRegistry container;

        public WpfPresenterFactory(DependencyRegistry container)
        {
            this.container = container;
        }

        public T create<T>() where T : Presenter
        {
            return container.get_a<T>();
        }
    }
}