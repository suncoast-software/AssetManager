using AssetManager.Services.Utility.MVVM.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManager.Services.Utility.MVVM.ViewModels
{
    public class DashboardViewModel: BaseViewModel
    {
        private readonly Navigator _navigator;

        public BaseViewModel? CurrentViewModel => _navigator.CurrentViewModel;
        public DashboardViewModel(Navigator navigator)
        {
            _navigator = navigator;
            _navigator.CurrentViewModelChanged += OnCurrentViewModelChanged;

        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
