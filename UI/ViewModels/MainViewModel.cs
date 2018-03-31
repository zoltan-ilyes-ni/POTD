using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using POTD.DataService.Models;

namespace POTD.UI.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        private ObservableCollection<DayViewModel> _days;

        public ObservableCollection<DayViewModel> Days
        {
            get => _days;
            private set => SetProperty(ref _days, value);
        }

        public MainViewModel()
        {
            LoadData(new DataService.DataService());
        }

        private void LoadData(DataService.DataService dataService)
        {
            if (dataService == null)
            {
                throw new ArgumentNullException(nameof(dataService));
            }

            List<DayViewModel> days = new List<DayViewModel>();

            foreach (DayModel dm in dataService.GetAllDays())
            {
                days.Add(new DayViewModel(dm));
            }

            Days = new ObservableCollection<DayViewModel>(days.OrderByDescending(d => d.DayModel.Date));
        }
    }
}