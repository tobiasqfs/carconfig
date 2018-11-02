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

namespace CarConfigurator.settings.order
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderDetailsPage : ContentPage
	{
		public OrderDetailsPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.order.order");

            CarConfig cc = CarConfig.GetInstance();
            cc.SleepForLoadtesting();

            vehicleDetails.Title = Language.GetString("menu.order.order.vehicleDetails");
            specialDetails.Title = Language.GetString("menu.order.order.specialDetails");
            accessoryDetails.Title = Language.GetString("menu.order.order.accessoryDetails");
            priceDetails.Title = Language.GetString("menu.order.order.priceDetails");
            contactDetails.Title = Language.GetString("menu.order.order.contactDetails");

            selectedVehicle.Label = Language.GetString("menu.order.view.selectedVehicle");
            if(cc.GetVehicles()[0].GetSelectedVehicle() != null)
            {
                selectedVehicle.Text = cc.GetVehicles()[0].GetNameOfSelectedVehicle();
            }
            else
            {
                selectedVehicle.Text = Language.GetString("menu.order.view.noSelectedVehicle");
            }

            selectedSpecial.Label = Language.GetString("menu.order.view.selectedSpecial");
            selectedSpecial.Text = cc.GetSpecials()[0].GetNameOfSelectedSpecial();

            List<Accessory> selAcs = new List<Accessory>();
            foreach (Accessory a in cc.GetAccessories()[0].GetAccessories())
            {
                if (a.selected)
                {
                    selAcs.Add(a);

                }
            }

            if(selAcs.Count == 0)
            {
                var layout = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand
                };
                layout.Children.Add(new Label()
                {
                    Text = Language.GetString("menu.order.view.noSelectedAccessory")
                });
                accessoryDetails.Add(new ViewCell() { View = layout });
            }
            else
            {
                int i = 0;
                foreach(Accessory a in selAcs)
                {
                    accessoryDetails.Add(new EntryCell()
                    {
                        Label = Language.GetString("menu.order.view.selectedAccessory") + " " + ++i,
                        Text = a.GetName(),
                        IsEnabled = false
                    });
                }
            }

            finalPrice.Label = Language.GetString("menu.order.view.endPrice");
            finalPrice.Text = Language.FormatPrice((long)(cc.GetEndPrice()));

            surname.Label = Language.GetString("menu.order.order.surname");
            firstname.Label = Language.GetString("menu.order.order.firstName");
            address.Label = Language.GetString("menu.order.order.streetAddress");
            zipcode.Label = Language.GetString("menu.order.order.zipCode");
            city.Label = Language.GetString("menu.order.order.city");
            country.Label = Language.GetString("menu.order.order.country");
            number.Label = Language.GetString("menu.order.order.phoneNumber");
            number2.Label = Language.GetString("menu.order.order.emailAddress");

            SendOrderButton.Text = Language.GetString("menu.order.order.sendPurchaseOrder");
            CancelButton2.Text = Language.GetString("menu.order.order.cancel");
        }

        private async void CancelButton2_Clicked(object sender, EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void SendOrderButton_Clicked(object sender, EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            try
            {
                if (surname.Text == null || surname.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(firstname.Text == null || firstname.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(address.Text == null || address.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(zipcode.Text == null || zipcode.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(city.Text == null || city.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(country.Text == null || country.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(number.Text == null || number.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }
                if(number2.Text == null || number2.Text.Length == 0)
                {
                    throw new ContactDetailsException();
                }

                await DisplayAlert(Language.GetString("alerts.orderPlaced.title"),
                    Language.GetString("alerts.orderPlaced.text"),
                    Language.GetString("alerts.ok"));

                await App.Current.MainPage.Navigation.PopToRootAsync();

            }
            catch (ContactDetailsException cde)
            {
                await DisplayAlert(Language.GetString("alerts.contactDetails.title"),
                        Language.GetString("alerts.contactDetails.text"),
                        Language.GetString("alerts.ok"));
            }
            CarConfig.GetInstance().SleepForLoadtesting();
        }
    }
}