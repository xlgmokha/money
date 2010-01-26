namespace momoney.presentation.views
{
    public interface IDialogLauncher
    {
        void launch<Command>(Command command) where Command : gorilla.commons.utility.Command;
    }
}