namespace PlanYourDay.Common.Helpers
{
    public static class TimeHelper
    {
        static TimeHelper()
        {
            AllowedTimeBlocks = new int[] { 0, 15, 30, 45, 60, 75, 90, 120, 150, 180, 210, 240 };
        }

        public static int[] AllowedTimeBlocks { get; private set; }
    }
}