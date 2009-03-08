using MoMoney.Infrastructure.Container;
using MoMoney.Infrastructure.eventing;

namespace MoMoney.Presentation.Model.Menu
{
    public static class create
    {
        public static IMenuItemBuilder a_menu_item()
        {
            return new MenuItemBuilder(resolve.dependency_for<IDependencyRegistry>(),resolve.dependency_for<IEventAggregator>());
        }

        public static IMenuItem a_menu_item_separator()
        {
            return new MenuItemSeparator();
        }

        public static IToolbarItemBuilder a_tool_bar_item()
        {
            return new tool_bar_item_builder(resolve.dependency_for<IDependencyRegistry>());
        }
    }
}