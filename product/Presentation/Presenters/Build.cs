namespace MoMoney.Presentation.Presenters.Navigation
{
    public class Build
    {
        public static IExpandoBuilder task_pane()
        {
            return new ExpandoBuilder();
        }

        public static IExpandoItemBuilder task_pane_item()
        {
            return new ExpandoItemBuilder();
        }
    }
}