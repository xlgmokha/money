using System;

namespace presentation.windows.server.domain.payroll
{
    static public class Calendar
    {
        static Func<Date> date = () => DateTime.Now.Date;
        static Func<Date> default_date = () => DateTime.Now.Date;

        static public void stop(Func<Date> new_date)
        {
            date = new_date;
        }

        static public void start()
        {
            date = default_date;
        }

        static public Date now()
        {
            return date();
        }
    }
}