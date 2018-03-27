using System.Collections.ObjectModel;

namespace POTD.UI.ViewModels
{
    internal class DayViewModel : ViewModelBase
    {
        private string _date;
        private System.Collections.ObjectModel.ObservableCollection<TaskViewModel> _tasks;

        public string Date
        {
            get => _date;
            set => SetProperty(ref _date, value);
        }

        public ObservableCollection<TaskViewModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }
    }
}