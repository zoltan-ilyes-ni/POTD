using PlanYourDay.Common.Helpers;
using PlanYourDay.Common.Interfaces;
using PlanYourDay.Common.Models;
using PlanYourDay.UI.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace PlanYourDay.UI.ViewModels
{
    internal class DayViewModel : ViewModelBase
    {
        private ICommand _addTaskCommand;
        private IDataService _dataService;
        private Day _day;
        private ObservableCollection<TaskViewModel> _tasks;

        public DayViewModel(Day day, IDataService dataService)
        {
            _day = day;
            _dataService = dataService;

            Tasks = new ObservableCollection<TaskViewModel>();
            foreach (Task task in day.Tasks)
            {
                Tasks.Add(new TaskViewModel(task, this));
            }

            this.Tasks = new ObservableCollection<TaskViewModel>(Tasks.OrderBy(t => t.Rank));

            this.IsExpanded = _day.Date == DateHelper.Today;
        }

        public ICommand AddTaskCommand
        {
            get
            {
                return _addTaskCommand ?? (_addTaskCommand = new CommandHandler(() => AddTask(), true));
            }
        }

        public DateTime Date
        {
            get => _day.Date;
        }

        public string DisplayDate
        {
            get => DateToString(Date);
        }

        public bool IsExpanded { get; set; }

        public ObservableCollection<TaskViewModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }

        public string TasksSummary
        {
            get
            {
                int all = 0, done = 0;
                foreach (var t in Tasks)
                {
                    all += t.Time.Minutes;
                    done += t.Done ? t.Time.Minutes : 0;
                }

                return $"{TimeViewModel.ToString(done)} / {TimeViewModel.ToString(all)}";
            }
        }

        private static string DateToString(DateTime date)
        {
            if (date == null)
            {
                throw new ArgumentNullException(nameof(date));
            }

            if (date == DateHelper.Today)
            {
                return "Today";
            }

            if (date == DateHelper.Tomorrow)
            {
                return "Tomorrow";
            }

            if (date == DateHelper.Yesterday)
            {
                return "Yesterday";
            }

            return date.DayOfWeek + ", " + date.ToShortDateString();
        }

        private void AddTask()
        {
            Task newTask = new Task();
            _dataService.CreateTask(_day, newTask);
            Tasks.Add(new TaskViewModel(newTask, this));
            NotifyPropertyChanged(TasksSummary);
        }
    }
}