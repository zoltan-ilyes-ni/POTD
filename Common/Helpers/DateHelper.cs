using System;

namespace PlanYourDay.Common.Helpers
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

        public static DateTime NextBusinessDay { get; private set; }

        public static DateTime Today { get => DateTime.Today; }

        public static DateTime Tomorrow { get; private set; }

        public static DateTime Yesterday { get; private set; }
    }
}