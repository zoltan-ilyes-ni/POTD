using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanYourDay.DateTimeHelper
{
    public static class TimeHelper
    {
        static TimeHelper()
        {
            AllowedTimeBlocks = new int[] { 0, 15, 30, 45, 60, 75, 90, 120, 150, 180, 210, 240};
        }

        public static int[] AllowedTimeBlocks { get; private set; }

        public static string TimeToString(int minutes)
        {
            if (minutes == 0) return "None";

            int hrs = minutes / 60;
            string hrsStr = hrs > 0 ? $"{hrs.ToString()} hrs " : string.Empty;

            int min = minutes - hrs * 60;
            string minStr = min > 0 ? $"{min.ToString()} min " : string.Empty;

            return hrsStr + minStr;
        }

    }
}
