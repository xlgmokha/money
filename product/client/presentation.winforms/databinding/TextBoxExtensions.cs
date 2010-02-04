using System.Windows.Forms;
using MoMoney.Presentation.Winforms.Helpers;

namespace MoMoney.Presentation.Winforms.Databinding
{
    static public class TextBoxExtensions
    {
        static public ITextControl<T> text_control<T>(this TextBox textbox)
        {
            return new TextControl<T>(textbox);
        }
    }
}