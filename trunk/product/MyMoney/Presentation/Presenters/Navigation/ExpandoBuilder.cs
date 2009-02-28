using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using MyMoney.Utility.Core;
using MyMoney.Utility.Extensions;
using XPExplorerBar;
using Padding=System.Windows.Forms.Padding;

namespace MyMoney.Presentation.Presenters.Navigation
{
    public interface IExpandoBuilder : IBuilder<Expando>
    {
        IExpandoBuilder named(string name);
        IExpandoBuilder with_item(IExpandoItemBuilder builder);
    }

    public class ExpandoBuilder : IExpandoBuilder
    {
        readonly IList<IExpandoItemBuilder> builders = new List<IExpandoItemBuilder>();
        string the_name = "";

        public IExpandoBuilder named(string name)
        {
            the_name = name;
            return this;
        }

        public IExpandoBuilder with_item(IExpandoItemBuilder builder)
        {
            builders.Add(builder);
            return this;
        }

        public Expando build()
        {
            var pane = new Expando {};
            ((ISupportInitialize) (pane)).BeginInit();
            pane.SuspendLayout();

            pane.Anchor = (AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right;
            pane.Animate = true;
            pane.AutoLayout = true;
            pane.ExpandedHeight = 63;
            pane.Font = new Font("Tahoma", 8.25F);
            pane.Items.AddRange(create_items());
            pane.Location = new Point(12, 12);
            pane.Margin = new Padding(4);
            pane.Name = "ux_" + the_name;
            pane.Size = new Size(292, 63);
            pane.SpecialGroup = true;
            pane.TabIndex = 5;
            pane.Text = the_name;

            ((ISupportInitialize) (pane)).EndInit();
            pane.ResumeLayout(false);

            return pane;
        }

        TaskItem[] create_items()
        {
            var items = new List<TaskItem>();
            builders.each(x => items.Add(x.build()));
            return items.ToArray();
        }
    }
}