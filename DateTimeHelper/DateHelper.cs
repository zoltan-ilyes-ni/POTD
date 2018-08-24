using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanYourDay.DateTimeHelper
{
    public static class DateHelper
    {
        static DateHelper()
        {
            Tomorrow = Today.AddDays(1);
            Yesterday = Today.AddDays(-1);
            NextBusinessDay = Tomorrow;

            while (NextBusinessDay.DayOfWeek == DayOfWeek.Saturday || NextBusinessDay.DayOfWeek == DayOfWeek.Sunday)
            {
                NextBusinessDay = NextBusinessDay.AddDays(1);
            }
        }

        public static DateTime BacklogDate { get => DateTime.MaxValue; }

        public static DateTime Tomorrow { get; private set; }

        public static DateTime Yesterday { get; private set; }

        public static DateTime Today { get => DateTime.Today; }

        public static DateTime NextBusinessDay { get; private set; }

        public static string DateToString(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            if (date == Today)
            {
                return "Today";
            }

            if (date == Tomorrow)
            {
                return "Tomorrow";
            }

            if (date == Yesterday)
            {
                return "Yesterday";
            }

            return date.DayOfWeek +", " + date.ToShortDateString();
        }
    }
}
