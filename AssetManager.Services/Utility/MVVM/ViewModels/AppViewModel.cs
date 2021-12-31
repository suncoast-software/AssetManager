using AssetManager.Data.Factories;
using AssetManager.Services.Utility.MVVM;
using AssetManager.Services.Utility.MVVM.Navigation;
using AssetManager.Services.Utility.MVVM.ViewModels;

namespace AssetManager.Services.ViewModels
{
    public class AppViewModel: BaseViewModel
    {
        private readonly Navigator? _navigator;
        private readonly AppDbContextFactory? _dbfactory;

        BaseViewModel? CurrentViewModel => _navigator?.CurrentViewModel;

        public AppViewModel(Navigator? navigator, AppDbContextFactory? dbfactory)
        {
            _navigator = navigator;
            _dbfactory = dbfactory;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
