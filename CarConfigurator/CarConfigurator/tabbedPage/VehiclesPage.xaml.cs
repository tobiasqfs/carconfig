using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.exceptions;
using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VehiclesPage : ContentPage
    {
        Rectangle drawerExpandedPosition;
        Rectangle drawerCollapsedPosition;

        public VehiclesPage()
        {
            InitializeComponent();

            // setting the items source for the listview
            CarConfig cc = CarConfig.GetInstance();
            List<Vehicle> vehicles = cc.GetVehicles()[0].GetVehicleList();
            VehiclesList.ItemsSource = vehicles;

            // setting the correct title for this page
            this.Title = Language.GetString("tabs.vehicles.label");

            ToolbarManager.Manage(ToolbarItems);

            SelectVehicle();

            CarConfigContext.vehiclesPage = this;



            toggleButton.Text = Language.GetString("calcpane.toggleButton.hide");

            priceModelLabel.Text = Language.GetString("calcpane.priceModel");

            priceSpecialLabel.Text = Language.GetString("calcpane.priceSpecial");

            discountLabel.Text = Language.GetString("calcpane.discount");

            endPriceLabel.Text = Language.GetString("calcpane.endprice");

            discountButton.Text = Language.GetString("calcpane.discountButton");

            UpdateCalcPane();

            var actualHeight = expandingTitleLayout.Height;
            drawerExpandedPosition = overlay.Bounds;
            drawerCollapsedPosition = overlay.Bounds;

            drawerCollapsedPosition.Y = overlay.Height - actualHeight;
            drawerExpandedPosition.Y = 0;

            overlay.TranslateTo(drawerCollapsedPosition.X, drawerCollapsedPosition.Y, 250, Easing.CubicOut);

        }

        private void toggleButton_Clicked(object sender, System.EventArgs e)
        {
            var actualHeight = expandingTitleLayout.Height;

            drawerExpandedPosition = overlay.Bounds;
            drawerCollapsedPosition = overlay.Bounds;

            drawerCollapsedPosition.Y = overlay.Height - actualHeight;
            drawerExpandedPosition.Y = 0;

            Button button = (Button)sender;
            if (button.Text.Equals(Language.GetString("calcpane.toggleButton.expand")))
            {
                overlay.TranslateTo(drawerExpandedPosition.X, drawerExpandedPosition.Y, 250, Easing.CubicOut);
                button.Text = Language.GetString("calcpane.toggleButton.hide");
            }
            else
            {
                overlay.TranslateTo(drawerCollapsedPosition.X, drawerCollapsedPosition.Y, 250, Easing.CubicOut);
                button.Text = Language.GetString("calcpane.toggleButton.expand");
            }

        }

        private async void discountButton_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                float increase;

                if (CarConfigContext.buggy)
                {
                    increase = 0.03f;
                }
                else
                {
                    increase = 0.05f;
                }

                float rounded = (float)Math.Round((double)(CarConfig.GetInstance().GetDiscount() + increase), 2);
                if(rounded > 0.99f)
                {
                    rounded = 0.99f;
                }
                CarConfig cc = CarConfig.GetInstance();
                cc.SetDiscount(rounded);
            }
            catch (InvalidDiscountException ide)
            {
                await DisplayAlert(Language.GetString("alerts.invalidDiscount.title"),
                        Language.GetString("alerts.invalidDiscount.text"),
                        Language.GetString("alerts.ok"));
            }

            UpdateCalcPane();
        }

        private void VehiclesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem is Vehicle)
            {
                var item = (Vehicle)e.SelectedItem;
                var vehicles = CarConfig.GetInstance().GetVehicles()[0];
                var index = vehicles.GetIndexOfVehicle(item);
                vehicles.SelectVehicleMainTableMode(index);
                
                VehiclesList.SelectedItem = CarConfig.GetInstance().GetVehicles()[0].GetSelectedVehicle();

                UpdateCalcPane();
            }
        }

        public void UpdateVehiclesListItemsSource()
        {
            CarConfig cc = CarConfig.GetInstance();
            List<Vehicle> vehicles = cc.GetVehicles()[0].GetVehicleList();
            VehiclesList.ItemsSource = null;
            VehiclesList.ItemsSource = vehicles;

            VehiclesList.SelectedItem = cc.GetVehicles()[0].GetSelectedVehicle();

            UpdateCalcPane();
        }
        
        public void SelectVehicle()
        {
            CarConfig cc = CarConfig.GetInstance();
            VehiclesList.SelectedItem = cc.GetVehicles()[0].GetSelectedVehicle();
        }
        
        public void UpdateCalcPane()
        {
            CarConfig cc = CarConfig.GetInstance();
            string priceModelText;
            string priceSpecialText;
            string discountText;

            Vehicle v = cc.GetVehicles()[0].GetSelectedVehicle();
            if(v != null)
            {
                if (CarConfigContext.buggy && cc.GetVehicles()[0].GetIndexOfVehicle(v) == cc.GetVehicles()[0].GetVehicleList().Count-1)
                {
                    priceModelText = Language.FormatPrice(0);
                }
                else
                {
                    priceModelText = v.GetPriceString();
                }
            }
            else
            {
                priceModelText = Language.FormatPrice(0);
            }

            Special s = cc.GetSpecials()[0].GetSelectedSpecial();
            if(s != null)
            {
                priceSpecialText = s.GetPriceString();
            }
            else
            {
                priceSpecialText = Language.FormatPrice(0);
            }

            int disc = (int)(cc.GetDiscount() * 100.00f);
            discountText = (CarConfig.GetInstance().GetDiscount() * 100.00f).ToString() + "%";
            
            priceModel.Text = priceModelText;
            priceSpecial.Text = priceSpecialText;
            discount.Text = discountText;
            endPrice.Text = Language.FormatPrice((long)cc.GetEndPrice());

        }

        private async void discount_Completed(object sender, System.EventArgs e)
        {
            Entry entry = (Entry)sender;

            CarConfig cc = CarConfig.GetInstance();

            try
            {
                float amount = int.Parse(entry.Text.Replace("%", ""));

                cc.SetDiscount(amount / 100.00f);
            }
            catch(System.FormatException fe)
            {
                cc.SetDiscount(0);
            }
            catch(InvalidDiscountException ide)
            {
                await DisplayAlert(Language.GetString("alerts.invalidDiscount.title"),
                        Language.GetString("alerts.invalidDiscount.text"),
                        Language.GetString("alerts.ok"));
            }

            UpdateCalcPane();
        }
    }
}