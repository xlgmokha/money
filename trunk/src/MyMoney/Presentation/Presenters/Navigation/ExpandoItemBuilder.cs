using System;
using System.Drawing;
using System.Windows.Forms;
using MyMoney.Presentation.Resources;
using XPExplorerBar;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public interface IExpandoItemBuilder
    {
        IExpandoItemBuilder Named(string name);
        IExpandoItemBuilder RepresentedByImage(ApplicationImage image);
        IExpandoItemBuilder WhenClickedExecute(Action action);
        TaskItem Build();
    }

    public class ExpandoItemBuilder : IExpandoItemBuilder
    {
        string the_name = "";
        ApplicationImage the_image;
        Action the_action = () => { };

        public IExpandoItemBuilder Named(string name)
        {
            the_name = name;
            return this;
        }

        public IExpandoItemBuilder RepresentedByImage(ApplicationImage image)
        {
            the_image = image;
            return this;
        }

        public IExpandoItemBuilder WhenClickedExecute(Action action)
        {
            the_action = action;
            return this;
        }

        public TaskItem Build()
        {
            var item = new TaskItem
                           {
                               Anchor = ((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right),
                               BackColor = Color.Transparent,
                               Image = the_image,
                               Location = new Point(12, 33),
                               Name = "ux" + the_name,
                               Size = new Size(266, 19),
                               TabIndex = 0,
                               Text = the_name,
                               TextAlign = ContentAlignment.TopLeft,
                               UseVisualStyleBackColor = false,
                           };
            item.Click += (sender, e) => the_action();
            return item;
        }
    }
}