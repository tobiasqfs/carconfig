using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.options
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsVehiclesPage : ContentPage
	{
        public OptionsVehiclesPage()
        {
            InitializeComponent();

            // setting the items source for the listview
            CarConfig cc = CarConfig.GetInstance();
            List<Vehicle> vehicles = cc.GetVehicles()[0].GetVehicleList();
            vehiclesList.ItemsSource = vehicles;

            // setting the correct text for the menu items
            this.Resources.Add("ChangeButtonText", Language.GetString("menu.edit.contextActions.change"));
            this.Resources.Add("DeleteButtonText", Language.GetString("menu.edit.contextActions.delete"));

            // setting the correct text for the toolbar item
            ToolbarItems[0].Text = Language.GetString("menu.edit.newButton");

            // setting the correct title for this page
            this.Title = Language.GetString("menu.edit.vehicles.title");

            CarConfigContext.optionsVehiclesPage = this;
        }

        private async void MenuItem_Change(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            if(mi is Vehicle)
            {
                var item = (Vehicle)mi;
                Vehicles vehicles = CarConfig.GetInstance().GetVehicles()[0];

                var index = vehicles.GetIndexOfVehicle(item);
                vehicles.SelectVehicleEditMode(index);
                await App.Current.MainPage.Navigation.PushModalAsync(new OptionsVehicleModal(true));
            }
            
        }

        private void MenuItem_Delete(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            var mi = ((MenuItem)sender).CommandParameter;

            vehiclesList.ItemsSource = null;

            if (mi is Vehicle)
            {
                var item = (Vehicle)mi;
                Vehicles vehicles = CarConfig.GetInstance().GetVehicles()[0];

                var index = vehicles.GetIndexOfVehicle(item);
                vehicles.SelectVehicleEditMode(index);
                vehicles.DeleteSelectedVehicle();

                UpdateVehiclesListItemsSource();
            }
        }

        private async void NewButton_Clicked(object sender, System.EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            await App.Current.MainPage.Navigation.PushModalAsync(new OptionsVehicleModal(false));
        }

        public void UpdateVehiclesListItemsSource()
        {
            CarConfig cc = CarConfig.GetInstance();
            List<Vehicle> vehicles = cc.GetVehicles()[0].GetVehicleList();
            vehiclesList.ItemsSource = null;
            vehiclesList.ItemsSource = vehicles;

            CarConfigContext.vehiclesPage.UpdateVehiclesListItemsSource();
        }

    }
}