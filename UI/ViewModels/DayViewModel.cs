using System;
using System.Collections.ObjectModel;
using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class DayViewModel : ViewModelBase
    {
        private string _dateString;

        private ObservableCollection<TaskViewModel> _tasks;

        public DayViewModel(DayModel dayModel)
        {
            DayModel = dayModel;
        }

        private DayModel DayModel { get; set; }

        public DateTime Date
        {
            get => DayModel.Date;
        }

        public string DateString
        {
            get
            {
                if (_dateString == null)
                {
                    if (DayModel.Date == DateTime.Today)
                    {
                        _dateString = "Today";
                    }
                    else if (DayModel.Date == DateTime.Today.AddDays(+1))
                    {
                        _dateString = "Tomorrow";
                    }
                    else if (DayModel.Date == DateTime.Today.AddDays(-1))
                    {
                        _dateString = "Yesterday";
                    }
                    else
                    {
                        _dateString = DayModel.Date.ToLongDateString();
                    }
                }

                return _dateString;
            }
        }

        public ObservableCollection<TaskViewModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public string TimeString
        {
            get
            {
                int all = 0, done = 0;
                foreach (var t in Tasks)
                {
                    all += t.Time.Value;
                    done += t.Done ? t.Time.Value : 0;
                }

                int allHours = all / 60;
                int allMinutes = all - allHours * 60;

                return $"{allHours.ToString()} Hour(s) {allMinutes} Minutes";
            }
        }
    }
}