using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

using Xamarin.Forms;

using MasterDetailsCRUDi.Services;

namespace MasterDetailsCRUDi.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IDataStore DataStore => DependencyService.Get<IDataStore>() ?? SQLDataStore.Instance;
       //private IDataStore DataStoreMock => DependencyService.Get<IDataStore>() ?? MockDataStore.Instance;
       // private IDataStore DataStoreSQL => DependencyService.Get<IDataStore>() ?? SQLDataStore.Instance;


        private bool _isBusy = false;
        public bool IsBusy
        {
            get { return _isBusy; }
            set { SetProperty(ref _isBusy, value); }
        }

        private string _title = string.Empty;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
