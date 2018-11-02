using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
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
	public partial class OrderViewPage : ContentPage
	{
		public OrderViewPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.order.view");

            CarConfig cc = CarConfig.GetInstance();
            cc.SleepForLoadtesting();

            List<Accessory> accessories = cc.GetAccessories()[0].GetAccessories();
            List<Accessory> selAcs = new List<Accessory>();
            foreach(Accessory a in accessories)
            {
                if (a.selected)
                {
                    selAcs.Add(a);
                    mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto});

                }
            }

            SelectedModelLbl.Text = Language.GetString("menu.order.view.selectedVehicle");
            if(cc.GetVehicles()[0].GetSelectedVehicle() != null)
            {
                SelectedModelTxtFld.Text = cc.GetVehicles()[0].GetNameOfSelectedVehicle();
            }
            else
            {
                SelectedModelTxtFld.Text = Language.GetString("menu.order.view.noSelectedVehicle");
            }

            SelectedSpecialLbl.Text = Language.GetString("menu.order.view.selectedSpecial");
            SelectedSpecialTxtFld.Text = cc.GetSpecials()[0].GetNameOfSelectedSpecial();

            if (selAcs.Count == 0)
            {
                label_accessory_1.Text = Language.GetString("menu.order.view.noSelectedAccessory");
                label_accessory_1.HorizontalOptions = LayoutOptions.CenterAndExpand;
                mainGrid.Children.Add(label_accessory_1, 0, 2, 2, 3);

                mainGrid.Children.Add(CalculatedPriceLbl, 0, 3);
                mainGrid.Children.Add(CalculatedPriceTxtFld, 1, 3);
                mainGrid.Children.Add(OkButton, 0, 2, 4, 5);
            }
            else
            {
                int i = 0;
                foreach (Accessory a in selAcs)
                {
                    Label label_accessory = new Label();
                    label_accessory.HorizontalOptions = LayoutOptions.Start;
                    label_accessory.VerticalOptions = LayoutOptions.CenterAndExpand;
                    label_accessory.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
                    label_accessory.Text = Language.GetString("menu.order.view.selectedAccessory") + " " + ++i;

                    Entry name_accessory = new Entry();
                    name_accessory.IsEnabled = false;
                    name_accessory.VerticalOptions = LayoutOptions.CenterAndExpand;
                    name_accessory.Text = a.GetName();

                    mainGrid.Children.Add(label_accessory, 0, 1 + i);
                    mainGrid.Children.Add(name_accessory, 1, 1 + i);
                }
                mainGrid.Children.Add(CalculatedPriceLbl, 0, 2 + i);
                mainGrid.Children.Add(CalculatedPriceTxtFld, 1, 2 + i);
                mainGrid.Children.Add(OkButton, 0, 2, 3 + i, 4 + i);
            }

            CalculatedPriceLbl.Text = Language.GetString("menu.order.view.endPrice");
            CalculatedPriceTxtFld.Text = Language.FormatPrice((long)(cc.GetEndPrice()));
            OkButton.Text = Language.GetString("menu.order.view.ok");
		}

        private async void OkButton_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void ContentPage_Disappearing(object sender, EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
        }
    }
}