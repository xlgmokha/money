using Gorilla.Commons.Utility.Core;

namespace MoMoney.Presentation.Winforms.Helpers
{
    public interface ITextBoxCommand<T> : IParameterizedCommand<IBindableTextBox<T>>
    {
    }
}