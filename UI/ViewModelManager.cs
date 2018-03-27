namespace POTD.UI
{
    internal class ViewModelManager
    {
        private ViewModelManager(DataService.DataService dataService)
        {
            Load(dataService);
        }

        private void Load(DataService.DataService dataService)
        {
        }
    }
}