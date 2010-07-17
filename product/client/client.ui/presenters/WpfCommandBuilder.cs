using Gorilla.Commons.Infrastructure.Container;

namespace presentation.windows.presenters
{
    public class WPFCommandBuilder : UICommandBuilder
    {
        DependencyRegistry container;

        public WPFCommandBuilder(DependencyRegistry container)
        {
            this.container = container;
        }

        public IObservableCommand build<T>(Presenter presenter) where T : UICommand
        {
            var command = container.get_a<T>();
            return new SimpleCommand(() =>
            {
                command.run(presenter);
            });
        }
    }
}