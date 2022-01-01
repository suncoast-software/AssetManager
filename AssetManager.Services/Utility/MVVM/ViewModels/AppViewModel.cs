using AssetManager.Data.Factories;
using AssetManager.Services.Utility.MVVM;
using AssetManager.Services.Utility.MVVM.Commands;
using AssetManager.Services.Utility.MVVM.Navigation;
using AssetManager.Services.Utility.MVVM.ViewModels;
using System.Windows.Input;

namespace AssetManager.Services.ViewModels
{
    public class AppViewModel: BaseViewModel
    {
        private readonly Navigator _navigator;
        private readonly AppDbContextFactory _dbfactory;

        public ICommand DashboardNavigateCommand { get; set; }

        public BaseViewModel? CurrentViewModel => _navigator.CurrentViewModel;

        public AppViewModel(Navigator navigator, AppDbContextFactory dbfactory)
        {
            _navigator = navigator;
            _dbfactory = dbfactory;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
            DashboardNavigateCommand = new NavigateCommand<DashboardViewModel>(_navigator, () => new DashboardViewModel(_navigator));
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
