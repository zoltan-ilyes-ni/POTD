using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using PlanYourDay.DataService.Models;
using PlanYourDay.UI.Helpers;
using PlanYourDay.DateTimeHelper;

namespace PlanYourDay.UI.ViewModels
{
    internal class DayViewModel : ViewModelBase
    {
        private ICommand _addTaskCommand;
        private DataService.DataService _dataService;
        private string _dateString;
        private DayModel _dayModel;
        private ObservableCollection<TaskViewModel> _tasks;

        public DayViewModel(DayModel dayModel, DataService.DataService dataService)
        {
            _dayModel = dayModel;
            _dataService = dataService;

            List<TaskViewModel> tasks = new List<TaskViewModel>();
            foreach (TaskModel task in _dataService.GetTasksByDay(dayModel))
            {
                tasks.Add(new TaskViewModel(task, this, null));
            }

            this.Tasks = new ObservableCollection<TaskViewModel>(tasks.OrderBy(t => t.Rank));

            this.IsExpanded = dayModel.Date == DateTime.Today;
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
            get => _dayModel.Date;
        }

        public string DateString
        {
            get
            {
                if (_dateString == null)
                {
                    _dateString = DateHelper.DateToString(Date);
                }

                return _dateString;
            }
        }

        public bool IsExpanded { get; set; }

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

                return $"{TimeHelper.TimeToString(done)} / {TimeHelper.TimeToString(all)}";
            }
        }

        private void AddTask()
        {
            Tasks.Add(
                new TaskViewModel(
                    taskModel: _dataService.AddTaskToDay(
                                                day: _dayModel,
                                                name: "",
                                                notes: "",
                                                priority: 1,
                                                project: null,
                                                rank: 0,
                                                done: false,
                                                time: 0),
                    dayViewModel: this,
                    projectViewModel: null));

            NotifyPropertyChanged(nameof(TimeString));
        }
    }
}