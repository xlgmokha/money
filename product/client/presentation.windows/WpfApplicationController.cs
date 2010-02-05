using System.Windows;
using System.Windows.Controls;

namespace presentation.windows
{
    public class WpfApplicationController : ApplicationController
    {
        RegionManager region_manager;
        PresenterFactory factory;

        public WpfApplicationController(RegionManager region_manager, PresenterFactory factory)
        {
            this.region_manager = region_manager;
            this.factory = factory;
        }

        public void add_tab<Presenter, View>() where Presenter : TabPresenter where View : FrameworkElement, Tab<Presenter>, new()
        {
            var presenter = factory.create<Presenter>();
            presenter.present();
            region_manager.region<TabControl>(x => x.Items.Add(new TabItem
                                                               {
                                                                   Header = presenter.Header,
                                                                   Content = new View {DataContext = presenter}
                                                               }));
        }
    }
}