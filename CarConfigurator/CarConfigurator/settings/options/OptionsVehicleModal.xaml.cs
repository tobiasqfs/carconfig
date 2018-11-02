using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.options
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsVehicleModal : ContentPage
	{
        private Boolean change;

		public OptionsVehicleModal (Boolean change)
		{
			InitializeComponent ();

            FinishButton.Text = Language.GetString("menu.edit.vehicles.add.finishButton");
            CancelButton.Text = Language.GetString("menu.edit.vehicles.add.cancelButton");

            VehicleNameLabel.Text = Language.GetString("menu.edit.vehicles.add.vehicleName");
            VehiclePriceLabel.Text = Language.GetString("menu.edit.vehicles.add.vehiclePrice");

            this.change = change;

            if (change)
            {
                Vehicles vehicles = CarConfig.GetInstance().GetVehicles()[0];
                Vehicle editModeSelectedVehicle = vehicles.GetEditModeSelectedVehicle();
                if (CarConfigContext.buggy && vehicles.GetIndexOfVehicle(editModeSelectedVehicle) == vehicles.GetVehicleList().Count - 1)
                {
                    VehicleName.Text = "";
                    VehiclePrice.Text = Language.FormatPrice(0);
                }
                else
                {
                    VehicleName.Text = vehicles.GetEditModeSelectedVehicle().GetName();
                    VehiclePrice.Text = vehicles.GetEditModeSelectedVehicle().GetPriceString();
                }
            }
		}

        private async void Finish_Clicked(object sender, EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            if (change)
            {
                string vehicleName = VehicleName.Text;
                string vehiclePrice = VehiclePrice.Text;
                try
                {
                    Vehicles vehicles = CarConfig.GetInstance().GetVehicles()[0];
                    vehicles.ChangeSelectedVehicle(vehicleName,
                        vehicles.GetEditModeSelectedVehicle().GetId(),
                        vehiclePrice);

                    CarConfigContext.optionsVehiclesPage.UpdateVehiclesListItemsSource();

                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (InvalidPriceException ipe)
                {
                    await DisplayAlert(Language.GetString("alerts.invalidPrice.title"),
                        Language.GetString("alerts.invalidPrice.text"),
                        Language.GetString("alerts.ok"));
                }
            }
            else
            {
                string vehicleName = VehicleName.Text;
                string vehiclePrice = VehiclePrice.Text;
                try
                {
                    Vehicle v = new Vehicle(vehicleName, "", vehiclePrice);
                    Vehicles vehicles = CarConfig.GetInstance().GetVehicles()[0];
                    vehicles.AddVehicle(v);

                    CarConfigContext.optionsVehiclesPage.UpdateVehiclesListItemsSource();

                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch (InvalidPriceException ipe)
                {
                    await DisplayAlert(Language.GetString("alerts.invalidPrice.title"),
                        Language.GetString("alerts.invalidPrice.text"),
                        Language.GetString("alerts.ok"));
                }
            }
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}