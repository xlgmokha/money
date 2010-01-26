namespace MoMoney.Presentation.Model.Menu.File
{
    public interface ISaveChangesCallback
    {
        void saved();
        void not_saved();
        void cancelled();
    }
}