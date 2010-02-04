using System;
using System.Drawing;
using System.Windows.Forms;
using gorilla.commons.utility;
using momoney.presentation.resources;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters
{
    public interface IExpandoItemBuilder : Builder<TaskItem>
    {
        IExpandoItemBuilder named(string name);
        IExpandoItemBuilder represented_by_image(ApplicationImage image);
        IExpandoItemBuilder represented_by_icon(HybridIcon image);
        IExpandoItemBuilder when_clicked_execute(Action action);
    }

    public class ExpandoItemBuilder : IExpandoItemBuilder
    {
        string the_name = "";
        Image the_image;
        Action the_action = () => {};

        public IExpandoItemBuilder named(string name)
        {
            the_name = name;
            return this;
        }

        public IExpandoItemBuilder represented_by_image(ApplicationImage image)
        {
            the_image = image;
            return this;
        }

        public IExpandoItemBuilder represented_by_icon(HybridIcon icon)
        {
            the_image = icon;
            return this;
        }

        public IExpandoItemBuilder when_clicked_execute(Action action)
        {
            the_action = action;
            return this;
        }

        public TaskItem build()
        {
            var item = new TaskItem
                       {
                           Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                           BackColor = Color.Transparent,
                           Image = the_image,
                           Name = "ux" + the_name,
                           Text = the_name,
                           UseVisualStyleBackColor = false,
                           ShowFocusCues = true,
                       };
            item.Click += (sender, e) => the_action();
            return item;
        }
    }
}