
using System;
using MasterDetailsCRUDi.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailsCRUDi.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();

            SettingDataSource.IsToggled = true;
        }

        private async void CleanDatabase_Comand(object sender, EventArgs e) {
            var answer = await DisplayAlert("Delete", "Sure you want to Delete all data?", "yes", "no");
            if (answer) {
                SQLDataStore.Instance.InitalizeDataBaseNewTables();
            }
        }

        private void Switch_OnToggled(object sender, ToggledEventArgs e)
        {
            // This will change out the DataStore to be the Mock Store if toggled on, or the SQL if off.

            if (e.Value == true)
            {

            }
        }

        //private async void ClearDatabase_Command(object sender, EventArgs e)
        //{
        //    var answer = await DisplayAlert("Delete", "Sure you want to Delete All Data, and start over?", "Yes", "No");
        //    if (answer)
        //    {
        //        // Call to the SQL DataStore and have it clear the tables.
        //        SQLDataStore.Instance.InitializeDatabaseNewTables();
        //    }
        //}
    }
}