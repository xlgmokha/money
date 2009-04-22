using MoMoney.Presentation.Model.Menu.File.Commands;
using MoMoney.Presentation.Views.Core;

namespace MoMoney.Presentation.Views.dialogs
{
    public interface ISaveChangesView : IView<ISaveChangesPresenter>
    {
        void prompt_user_to_save();
    }
}