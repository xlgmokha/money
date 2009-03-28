using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MoMoney.Utility.Core;
using MoMoney.Utility.Extensions;
using XPExplorerBar;

namespace MoMoney.Presentation.Presenters.Navigation
{
    public interface IExpandoBuilder : IBuilder<Expando>
    {
        IExpandoBuilder named(string name);
        IExpandoBuilder with_item(IExpandoItemBuilder builder);
    }

    public class ExpandoBuilder : IExpandoBuilder
    {
        readonly List<IExpandoItemBuilder> builders = new List<IExpandoItemBuilder>();
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
            pane.Items.AddRange(create_items());
            pane.Name = "ux_" + the_name;
            pane.SpecialGroup = true;
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