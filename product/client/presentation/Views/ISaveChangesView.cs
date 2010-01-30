using MoMoney.Presentation.Model.Menu.File;

namespace momoney.presentation.views
{
    public interface ISaveChangesView : Dialog<SaveChangesPresenter>
    {
        void prompt_user_to_save();
    }
}