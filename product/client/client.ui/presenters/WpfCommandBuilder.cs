using Autofac;

namespace presentation.windows.presenters
{
    public class WpfCommandBuilder : UICommandBuilder
    {
        IContainer container;

        public WpfCommandBuilder(IContainer container)
        {
            this.container = container;
        }

        public IObservableCommand build<T>(Presenter presenter) where T : UICommand
        {
            var command = container.Resolve<T>();
            return new SimpleCommand(() =>
            {
                command.run(presenter);
            });
        }
    }
}