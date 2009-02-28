using MyMoney.Presentation.Model.Menu.File.Commands;
using MyMoney.Presentation.Views.core;

namespace MyMoney.Presentation.Views.dialogs
{
    public interface ISaveChangesView : IView<ISaveChangesPresenter>
    {
        void prompt_user_to_save();
    }
}