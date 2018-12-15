using PlanYourDay.Common.Helpers;
using PlanYourDay.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlanYourDay.UI.ViewModels
{
    internal class TaskViewModel : ViewModelBase
    {
        private DayViewModel _dayViewModel;
        private Task _task;
        private TimeViewModel _timeViewModel;

        static TaskViewModel()
        {
            TimeBlocks = new List<TimeViewModel>();
            foreach (int m in TimeHelper.AllowedTimeBlocks)
            {
                TimeBlocks.Add(new TimeViewModel(m));
            };
        }

        public TaskViewModel(Task task, DayViewModel dayViewModel)
        {
            _task = task;
            _dayViewModel = dayViewModel;
            // Todo: this will throw an exception if there is no match
            Time = TimeBlocks.First(t => t.Minutes == _task.Time);
        }

        public static List<TimeViewModel> TimeBlocks { get; private set; }

        public bool Done
        {
            get => _task.Status == TaskStatus.Done;
            set
            {
                bool oldValue = _task.Status == TaskStatus.Done;
                if (value != oldValue)
                {
                    _task.Status = value ? TaskStatus.Done : TaskStatus.Pending;
                    NotifyPropertyChanged(nameof(Done));
                    NotifyPropertyChanged(nameof(NotDone));
                }
            }
        }

        public string Name
        {
            get => _task.Name;
            set
            {
                if (_task.Name != value)
                {
                    _task.Name = value;
                    NotifyPropertyChanged(nameof(Name));
                }
            }
        }

        public bool NotDone
        {
            get => !Done;
        }

        public int Rank
        {
            get => _task.Rank;
            set => throw new NotImplementedException();
        }

        public TimeViewModel Time
        {
            get => _timeViewModel;
            set
            {
                if (_timeViewModel != value)
                {
                    _timeViewModel = value;
                    _task.Time = _timeViewModel.Minutes;
                    NotifyPropertyChanged(nameof(Time));
                    _dayViewModel.NotifyPropertyChanged(nameof(DayViewModel.TasksSummary));
                }
            }
        }
    }
}