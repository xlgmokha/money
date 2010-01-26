namespace MoMoney.Presentation.Views
{
    public interface ITitleBar
    {
        void display(string title);
        void append_asterik();
        void remove_asterik();
    }
}