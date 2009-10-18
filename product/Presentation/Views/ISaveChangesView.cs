using MoMoney.Presentation.Model.Menu.File;

namespace MoMoney.Presentation.Views
{
    public interface ISaveChangesView : IView<ISaveChangesPresenter>
    {
        void prompt_user_to_save();
    }
}