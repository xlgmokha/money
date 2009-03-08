using System;
using System.Drawing;
using System.Windows.Forms;
using MoMoney.Presentation.Resources;
using MoMoney.Utility.Core;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface IExpandoItemBuilder : IBuilder<TaskItem>
    {
        IExpandoItemBuilder named(string name);
        IExpandoItemBuilder represented_by_image(ApplicationImage image);
        IExpandoItemBuilder when_clicked_execute(Action action);
    }

    public class ExpandoItemBuilder : IExpandoItemBuilder
    {
        string the_name = "";
        ApplicationImage the_image;
        Action the_action = () => { };

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
                               //Location = new Point(12, 33),
                               Name = "ux" + the_name,
                               //Size = new Size(266, 19),
                               //TabIndex = 0,
                               Text = the_name,
                               //TextAlign = ContentAlignment.TopLeft,
                               UseVisualStyleBackColor = false,
                           };
            item.Click += (sender, e) => the_action();
            return item;
        }
    }
}