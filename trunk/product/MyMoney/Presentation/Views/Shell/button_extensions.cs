using System;
using System.Drawing;
using System.Windows.Forms;
using MoMoney.Infrastructure.Container;
using MoMoney.Utility.Core;

namespace MoMoney.Presentation.Views.Shell
{
    public static class ButtonExtensions
    {
        public static Button will_be_shown_as(this Button button, Bitmap image)
        {
            BitmapRegion.CreateControlRegion(button, image);
            button.MouseLeave += (sender, e) => BitmapRegion.CreateControlRegion(button, image);
            button.FlatAppearance.BorderSize = 0; //needs to be here so edges don't get affected by borders
            return button;
        }

        public static Button when_hovered_over_will_show(this Button button, Bitmap image)
        {
            button.MouseEnter += (sender, e) => BitmapRegion.CreateControlRegion(button, image);
            return button;
        }

        public static Button will_execute<Command>(this Button button, Func<bool> when) where Command : ICommand
        {
            button.Click += (sender, e) => { if (when()) resolve.dependency_for<Command>().run(); };
            button.Enabled = when();
            return button;
        }

        public static Control with_tool_tip(this Control control, string title, string caption)
        {
            new ToolTip
                {
                    IsBalloon = true,
                    ToolTipTitle = title,
                    ToolTipIcon = ToolTipIcon.Info,
                    UseAnimation = true,
                    UseFading = true,
                    AutoPopDelay = 10000,
                }.SetToolTip(control, caption);
            return control;
        }
    }
}