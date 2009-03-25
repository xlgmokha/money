using MoMoney.Infrastructure.Container;

namespace MoMoney.Presentation.Model.Menu
{
    public static class Create
    {
        public static IMenuItemBuilder a_menu_item()
        {
            return new MenuItemBuilder(resolve.dependency_for<IDependencyRegistry>());
        }

        public static IMenuItem a_menu_item_separator()
        {
            return new MenuItemSeparator();
        }

        public static IToolbarItemBuilder a_tool_bar_item()
        {
            return new ToolBarItemBuilder(resolve.dependency_for<IDependencyRegistry>());
        }
    }
}