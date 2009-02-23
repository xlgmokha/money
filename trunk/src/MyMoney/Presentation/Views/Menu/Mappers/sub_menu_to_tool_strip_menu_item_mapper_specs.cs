using System.Collections.Generic;
using System.Windows.Forms;
using MbUnit.Framework;
using MyMoney.Presentation.Model.Menu;
using MyMoney.Testing.Extensions;
using MyMoney.Testing.MetaData;
using MyMoney.Utility.Core;
using Rhino.Mocks;

namespace MyMoney.Presentation.Views.Menu.Mappers
{
    public class sub_menu_to_tool_strip_menu_item_mapper_specs
    {}

    [Observations]
    public class when_mapping_a_sub_menu_to_a_tool_strip_menu_item_
    {
        private MockRepository mockery;
        private ISubMenu subMenu;
        private IList<IMenuItem> menuItems;

        [SetUp]
        public void SetUp()
        {
            mockery = new MockRepository();
            subMenu = mockery.DynamicMock<ISubMenu>();
            menuItems = new List<IMenuItem>();

            SetupResult.For(subMenu.name).Return("&File");
            SetupResult.For(subMenu.all_menu_items()).Return(menuItems);
        }

        [Observation]
        public void should_return_a_non_null_value()
        {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().map_from(subMenu).should_not_be_null();
            }
        }

        [Observation]
        public void should_return_a_menu_item_with_the_sub_menus_name_applied_as_its_text()
        {
            using (mockery.Record()) {}

            using (mockery.Playback()) {
                CreateSUT().map_from(subMenu).Text.should_be_equal_to("&File");
            }
        }


        [Observation]
        public void should_add_all_the_mapped_menu_items_to_the_menu_item_representing_the_sub_menu()
        {
            var firstMenuItem = mockery.DynamicMock<IMenuItem>();
            var mappedMenuItem = new ToolStripMenuItem();

            menuItems.Add(firstMenuItem);
            using (mockery.Record()) {
                SetupResult
                    .For(firstMenuItem.build())
                    .Return(mappedMenuItem)
                    .Repeat
                    .AtLeastOnce();
            }

            using (mockery.Playback()) {
                CreateSUT().map_from(subMenu).DropDownItems.Contains(mappedMenuItem)
                    .should_be_equal_to(true);
            }
        }

        private IMapper<ISubMenu, ToolStripMenuItem> CreateSUT()
        {
            return new sub_menu_to_tool_strip_menu_item_mapper();
        }
    }
}