using gorilla.commons.utility;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public interface ITextBoxCommand<T> : ParameterizedCommand<IBindableTextBox<T>> {}
}