namespace PlanYourDay.UI.ViewModels
{
    public class TimeViewModel
    {
        public TimeViewModel(int value)
        {
            Minutes = value;
        }

        public string DisplayValue { get => this.ToString(); }

        public int Minutes { get; set; }

        public static string ToString(int minutes)
        {
            if (minutes == 0) return "None";

            int hrs = minutes / 60;
            string hrsStr = hrs > 0 ? $"{hrs.ToString()} hrs " : string.Empty;

            int min = minutes - hrs * 60;
            string minStr = min > 0 ? $"{min.ToString()} min " : string.Empty;

            return hrsStr + minStr;
        }

        /// <summary>
        /// This is required to make Combobox binding work directly on the class
        /// without defining custom DataTemplate to extract DisplayValue
        /// </summary>
        /// <returns></returns>
        public override string ToString() => TimeViewModel.ToString(this.Minutes);
    }
}