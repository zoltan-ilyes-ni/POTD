using Microsoft.Win32;
using PlanYourDay.Common.Interfaces;
using PlanYourDay.Common.Models;
using PlanYourDay.UI.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace PlanYourDay.UI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ObservableCollection<TaskViewModel> _backlog;
        private IDataService _dataService;
        private ObservableCollection<DayViewModel> _days;
        private ICommand _openCommand, _saveCommand;

        public MainViewModel()
        {
            _dataService = new FileDataService.FileDataService();
            _dataService.Open(@"c:\Temp\PlanYourDay.json");
            LoadContent();
        }

        public ObservableCollection<TaskViewModel> Backlog
        {
            get => _backlog;
            private set => SetProperty(ref _backlog, value);
        }

        public string ConnectionString { get => _dataService?.ConnectionString; }

        public ObservableCollection<DayViewModel> Days
        {
            get => _days;
            private set => SetProperty(ref _days, value);
        }

        public ICommand OpenCommand
        {
            get
            {
                return _openCommand ?? (_openCommand = new CommandHandler(() => Open(), true));
            }
        }

        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new CommandHandler(() => Save(), true));
            }
        }

        public TaskViewModel SelectedTask
        {
            get; set;
        }

        private void LoadContent()
        {
            if (_dataService == null)
            {
                throw new InvalidOperationException("DataService is null!");
            }

            // --------------- Days ------------------------
            List<DayViewModel> days = new List<DayViewModel>();

            foreach (Day day in _dataService.GetDays())
            {
                days.Add(new DayViewModel(day, _dataService));
            }

            Days = new ObservableCollection<DayViewModel>(days.OrderByDescending(d => d.Date));

            // -------------- Backlog ------------------------
            List<TaskViewModel> backlog = new List<TaskViewModel>();
            //foreach(TaskModel in )
        }

        private void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "JSON Documents|*.json",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _dataService.Open(openFileDialog.FileName);
                LoadContent();
            }
        }

        private void Save()
        {
            if (!string.IsNullOrEmpty(ConnectionString))
            {
                _dataService.Save();
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = ConnectionString,
                    Filter = "JSON Documents|*.json",
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    _dataService.SaveAs(saveFileDialog.FileName);
                    NotifyPropertyChanged(nameof(ConnectionString));
                }
            }
        }
    }
}