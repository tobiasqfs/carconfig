using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.options
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OptionsAccessoryModal : ContentPage
	{
        private Boolean change;

		public OptionsAccessoryModal (Boolean change)
		{
            InitializeComponent();

            FinishButton.Text = Language.GetString("menu.edit.vehicles.add.finishButton");
            CancelButton.Text = Language.GetString("menu.edit.vehicles.add.cancelButton");

            AccessoryNameLabel.Text = Language.GetString("menu.edit.accessories.add.accessoryName");
            AccessoryIdLabel.Text = Language.GetString("menu.edit.accessories.add.accessoryId");
            AccessoryPriceLabel.Text = Language.GetString("menu.edit.accessories.add.accessoryPrice");

            this.change = change;

            if (change)
            {
                Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];
                Accessory editModeSelectedAccessory = accessories.GetEditModeSelectedAccessory();

                if(CarConfigContext.buggy && accessories.GetIndexOfAccessory(editModeSelectedAccessory) == accessories.GetAccessoryList().Count - 1)
                {
                    AccessoryName.Text = "";
                    AccessoryId.Text = "";
                    AccessoryPrice.Text = Language.FormatPrice(0);
                }
                else
                {
                    AccessoryName.Text = accessories.GetEditModeSelectedAccessory().GetName();
                    AccessoryId.Text = accessories.GetEditModeSelectedAccessory().GetId();
                    AccessoryPrice.Text = accessories.GetEditModeSelectedAccessory().GetPriceString();
                }
            }
		}

        private async void Finish_Clicked(object sender, EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            if (change)
            {
                String accessoryName = AccessoryName.Text;
                String accessoryId = AccessoryId.Text;
                String accessoryPrice = AccessoryPrice.Text;
                try
                {
                    Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];
                    accessories.ChangeSelectedAccessory(accessoryName, accessoryId, accessoryPrice);

                    CarConfigContext.optionsAccessoriesPage.UpdateAccessoriesListItemsSource();

                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch(InvalidPriceException ipe)
                {
                    await DisplayAlert(Language.GetString("alerts.invalidPrice.title"),
                        Language.GetString("alerts.invalidPrice.text"),
                        Language.GetString("alerts.ok"));
                }
            }
            else
            {
                String accessoryName = AccessoryName.Text;
                String accessoryId = AccessoryId.Text;
                String accessoryPrice = AccessoryPrice.Text;
                try
                {
                    Accessory a = new Accessory(accessoryName, accessoryId, accessoryPrice);
                    Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];
                    accessories.AddAccessory(a);

                    CarConfigContext.optionsAccessoriesPage.UpdateAccessoriesListItemsSource();

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