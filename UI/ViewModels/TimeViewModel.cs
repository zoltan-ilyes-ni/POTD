namespace POTD.UI.ViewModels
{
    public class TimeViewModel
    {
        public string DisplayValue { get; set; }

        public int Value { get; set; }

        /// <summary>
        /// This is required to make Combobox binding work directly on the class
        /// without defining custom DataTemplate to extract DisplayValue
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return DisplayValue;
        }
    }
}