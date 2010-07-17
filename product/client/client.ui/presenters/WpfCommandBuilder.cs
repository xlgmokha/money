using Autofac;

namespace presentation.windows.presenters
{
    public class WPFCommandBuilder : UICommandBuilder
    {
        IContainer container;

        public WPFCommandBuilder(IContainer container)
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