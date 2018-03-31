using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class TaskViewModel : ViewModelBase
    {
        private BacklogItemViewModel _backlogItem;
        private DayViewModel _day;
        private string _status;
        private int _minutesSpent;

        private TaskModel TaskDataModel { get; set; }

        public BacklogItemViewModel BacklogItem
        {
            get => _backlogItem;
            set => SetProperty(ref _backlogItem, value);
        }

        public DayViewModel Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }

        public string Status
        {
            get => _status;
            set => SetProperty(ref _status, value);
        }

        public int MinutesSpent
        {
            get => _minutesSpent;
            set => SetProperty(ref _minutesSpent, value);
        }
    }
}