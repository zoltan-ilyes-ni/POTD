using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.Win32;
using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ObservableCollection<TaskViewModel> _backlog;
        private DataService.DataService _dataService;
        private ObservableCollection<DayViewModel> _days;
        private ICommand _openCommand, _saveCommand;

        public MainViewModel()
        {
            _dataService = new DataService.DataService();
            LoadContent();
        }

        public ObservableCollection<TaskViewModel> Backlog
        {
            get => _backlog;
            private set => SetProperty(ref _backlog, value);
        }

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

        public string SourcePath { get => _dataService?.SourcePath; }

        private void LoadContent()
        {
            if (_dataService == null)
            {
                throw new InvalidOperationException("DataService is null!");
            }

            // --------------- Days ------------------------
            List<DayViewModel> days = new List<DayViewModel>();

            foreach (DayModel day in _dataService.GetAllDays())
            {
                days.Add(new DayViewModel(day, _dataService));
            }

            Days = new ObservableCollection<DayViewModel>(days.OrderByDescending(d => d.Date));

            // -------------- Backlog ------------------------
            List<TaskViewModel> backlog = new List<TaskViewModel>();
            //foreach(TaskModel in )

            NotifyPropertyChanged(nameof(SourcePath));
        }

        private void Open()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                FileName = SourcePath,
                Filter = "JSON Documents|*.json",
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _dataService.Load(openFileDialog.FileName);
                LoadContent();
            }
        }

        private void Save()
        {
            if (!string.IsNullOrEmpty(SourcePath))
            {
                _dataService.Save();
            }
            else
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    FileName = SourcePath,
                    Filter = "JSON Documents|*.json",
                };
                if (saveFileDialog.ShowDialog() == true)
                {
                    _dataService.SaveAs(saveFileDialog.FileName);
                    NotifyPropertyChanged(nameof(SourcePath));
                }
            }
        }
    }
}