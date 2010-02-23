namespace presentation.windows.domain.payroll
{
    public class History
    {
        Date dateOfChange;
        UnitPrice adjustedPrice;

        History() {}

        static public History New(UnitPrice newPrice)
        {
            return new History
                   {
                       dateOfChange = Calendar.now(),
                       adjustedPrice = newPrice,
                   };
        }

        public UnitPrice Adjustment()
        {
            return adjustedPrice;
        }
    }
}