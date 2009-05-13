using Gorilla.Commons.Infrastructure.Container;

namespace MoMoney.Presentation.Model.Menu
{
    public static class Create
    {
        public static IMenuItemBuilder a_menu_item()
        {
            return Resolve.the<IMenuItemBuilder>();
        }

        public static IMenuItem a_menu_item_separator()
        {
            return new MenuItemSeparator();
        }

        public static IToolbarItemBuilder a_tool_bar_item()
        {
            return Resolve.the<IToolbarItemBuilder>();
        }
    }
}