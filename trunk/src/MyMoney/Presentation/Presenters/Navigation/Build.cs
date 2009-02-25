namespace MyMoney.Presentation.Presenters.Navigation
{
    public class Build
    {
        public static IExpandoBuilder Expando()
        {
            return new ExpandoBuilder();
        }

        public static IExpandoItemBuilder ExpandoItem()
        {
            return new ExpandoItemBuilder();
        }
    }
}