using System.Collections.Generic;
using System.Linq;
using PlanYourDay.DataService.Models;
using PlanYourDay.DateTimeHelper;

namespace PlanYourDay.UI.ViewModels
{
    internal class TaskViewModel : ViewModelBase
    {
        private DayViewModel _day;
        private ProjectViewModel _project;
        public TimeViewModel _time;

        static TaskViewModel()
        {
            TimeValues = new List<TimeViewModel>();
            foreach( int m in TimeHelper.AllowedTimeBlocks)
            {
                TimeValues.Add(

                    new TimeViewModel()
                    {
                        Value = m,
                        DisplayValue = TimeHelper.TimeToString(m),
                    }
                );
            };
        }

        public TaskViewModel(TaskModel taskModel, DayViewModel dayViewModel, ProjectViewModel projectViewModel)
        {
            Day = dayViewModel;
            Project = projectViewModel;
            TaskModel = taskModel;
            // Todo: this will throw an exception if there is no match
            Time = TimeValues.First(t => t.Value == TaskModel.Time);
        }

        private TaskModel TaskModel { get; set; }

        public static List<TimeViewModel> TimeValues { get; private set; }

        public DayViewModel Day
        {
            get => _day;
            set => SetProperty(ref _day, value);
        }

        public bool Done
        {
            get => TaskModel.Done;
            set
            {
                if (TaskModel.Done != value)
                {
                    TaskModel.Done = value;
                    NotifyPropertyChanged(nameof(Done));
                }
            }
        }

        public string Name
        {
            get => TaskModel.Name;
            set
            {
                if (TaskModel.Name != value)
                {
                    TaskModel.Name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public ProjectViewModel Project
        {
            get => _project;
            set => SetProperty(ref _project, value);
        }

        public int Rank
        {
            get => TaskModel.Rank;
            set => TaskModel.Rank = value;
        }

        public TimeViewModel Time
        {
            get => _time;
            set
            {
                if (_time != value)
                {
                    _time = value;
                    TaskModel.Time = _time.Value;
                    NotifyPropertyChanged(nameof(Time));
                    Day.NotifyPropertyChanged(nameof(Day.TimeString));
                }
            }
        }
    }
}