using System.Collections.ObjectModel;

namespace POTD.UI.ViewModels
{
    internal class ProjectViewModel : ViewModelBase
    {
        private string _name;
        private ObservableCollection<TaskViewModel> _tasks;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<TaskViewModel> Tasks
        {
            get => _tasks;
            set => SetProperty(ref _tasks, value);
        }
    }
}