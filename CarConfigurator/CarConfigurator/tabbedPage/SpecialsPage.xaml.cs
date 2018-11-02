using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.basic;
using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SpecialsPage : ContentPage
	{
        private Boolean updating;

		public SpecialsPage ()
		{
			InitializeComponent ();

            // setting the items source for the listview
            CarConfig cc = CarConfig.GetInstance();
            List<Special> specials = cc.GetSpecials()[0].GetSpecialList();
            specialsList.ItemsSource = specials;

            // setting the correct title for this page
            this.Title = Language.GetString("tabs.specials.label");

            ToolbarManager.Manage(ToolbarItems);

            specialsList.SelectedItem = CarConfig.GetInstance().GetSpecials()[0].GetSpecialList()[0];

            CarConfigContext.specialsPage = this;
        }

        private async void specialsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!updating)
            {
                if (e.SelectedItem is Special)
                {
                    var item = (Special)e.SelectedItem;
                    var specials = CarConfig.GetInstance().GetSpecials()[0];
                    var index = specials.GetIndexOfSpecial(item);
                    specials.SelectSpecialMainTableMode(index);
                    await DisplayAlert(Language.GetString("alerts.specials"),
                        item.GetDescription(),
                        Language.GetString("alerts.ok"));
                    //CarConfig.GetInstance().UpdateAccessories();

                    CarConfigContext.vehiclesPage.UpdateCalcPane();

                    CarConfigContext.accessoriesPage.UpdateAccessoriesListItemsSource();
                }
            }
        }

        public void UpdateSpecialsListItemsSource()
        {
            updating = true;

            CarConfig cc = CarConfig.GetInstance();
            List<Special> specials = cc.GetSpecials()[0].GetSpecialList();
            specialsList.ItemsSource = null;
            specialsList.ItemsSource = specials;
            CarConfig.GetInstance().GetSpecials()[0].SelectSpecialMainTableMode(0);
            specialsList.SelectedItem = CarConfig.GetInstance().GetSpecials()[0].GetSelectedSpecial();

            CarConfigContext.vehiclesPage.UpdateCalcPane();

            updating = false;
        }
    }
}