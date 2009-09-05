using ComponentFactory.Krypton.Toolkit;
using MoMoney.Presentation.Winforms.Helpers;

namespace MoMoney.Presentation.Winforms.Krypton
{
    static public class TextBoxExtensions
    {
        static public ITextControl<T> text_control<T>(this KryptonTextBox textbox)
        {
            return new KryptonTextControl<T>(textbox);
        }
    }
}