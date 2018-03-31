using System;
using System.Collections.ObjectModel;
using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class DayViewModel : ViewModelBase
    {
        private string _dateString;

        private ObservableCollection<TaskViewModel> _tasks;
        private DateTime _date;

        public string DateString
        {
            get => _dateString;
            private set => SetProperty(ref _dateString, value);
        }

        public DateTime Date
        {
            get => DayModel.Date;
        }

        public ObservableCollection<TaskViewModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public DayModel DayModel { get; private set; }

        public DayViewModel(DayModel dayModel)
        {
            DateString = DateToString(dayModel.Date);

            DayModel = dayModel;
        }

        private string DateToString(DateTime date)
        {
            string dateString;
            if (date == DateTime.Today)
            {
                dateString = "Today";
            }
            else if (date == DateTime.Today.AddDays(+1))
            {
                dateString = "Tomorrow";
            }
            else if (date == DateTime.Today.AddDays(-1))
            {
                dateString = "Yesterday";
            }
            else
            {
                dateString = date.ToLongDateString();
            }

            return dateString;
        }
    }
}