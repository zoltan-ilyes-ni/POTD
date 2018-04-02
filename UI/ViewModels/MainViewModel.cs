using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private DataService.DataService _dataService;
        private ObservableCollection<DayViewModel> _days;

        public MainViewModel()
        {
            _dataService = new DataService.DataService();
            Initialize();
        }

        public ObservableCollection<DayViewModel> Days
        {
            get => _days;
            private set => SetProperty(ref _days, value);
        }

        private void Initialize()
        {
            if (_dataService == null)
            {
                throw new InvalidOperationException("DataService is null!");
            }

            // --------------- Days ------------------------
            List<DayViewModel> days = new List<DayViewModel>();

            foreach (DayModel day in _dataService.GetAllDays())
            {
                days.Add(InitializeDayViewModel(day));
            }

            Days = new ObservableCollection<DayViewModel>(days.OrderByDescending(d => d.Date));

            // -------------- Backlog ------------------------
        }

        private DayViewModel InitializeDayViewModel(DayModel dayModel)
        {
            DayViewModel dayViewModel = new DayViewModel(dayModel);
            dayViewModel.Tasks = new ObservableCollection<TaskViewModel>();

            List<TaskViewModel> tasks = new List<TaskViewModel>();
            foreach (TaskModel task in _dataService.GetTasksByDay(dayModel))
            {
                tasks.Add(new TaskViewModel(task, dayViewModel, null));
            }

            dayViewModel.Tasks = new ObservableCollection<TaskViewModel>(tasks.OrderBy(t => t.Rank));
            return dayViewModel;
        }
    }
}