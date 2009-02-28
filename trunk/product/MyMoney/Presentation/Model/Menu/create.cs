using MyMoney.Infrastructure.Container;

namespace MyMoney.Presentation.Model.Menu
{
    public class create
    {
        public static IMenuItemBuilder a_menu_item()
        {
            return new menu_item_builder(resolve.dependency_for<IDependencyRegistry>());
        }

        public static IMenuItem a_menu_item_separator()
        {
            return new menu_item_separator();
        }

        public static IToolbarItemBuilder a_tool_bar_item()
        {
            return new tool_bar_item_builder(resolve.dependency_for<IDependencyRegistry>());
        }
    }
}