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
	public partial class OptionsSpecialModal : ContentPage
	{
        private Boolean change;

        private List<int> selected;

		public OptionsSpecialModal (Boolean change)
		{
			InitializeComponent ();

            SpecialNameLabel.Text = Language.GetString("menu.edit.specials.add.specialName");
            SpecialPriceLabel.Text = Language.GetString("menu.edit.specials.add.specialPrice");
            SeperatePricesLabel.Text = Language.GetString("menu.edit.specials.add.seperatePrices");
            DescriptionLabel.Text = Language.GetString("menu.edit.specials.add.specialDescription");
            ContainedAccessoriesLabel.Text = Language.GetString("menu.edit.specials.add.containedAccessories");
            FinishButton.Text = Language.GetString("menu.edit.specials.add.finishButton");
            CancelButton.Text = Language.GetString("menu.edit.specials.add.cancelButton");

            selected = new List<int>();

            // setting the items source for the listview
            CarConfig cc = CarConfig.GetInstance();
            Accessories acs = cc.GetAccessories()[0].Clone();
            List<Accessory> accessories = acs.GetAccessoryList();
            foreach(Accessory a in accessories)
            {
                a.SetSelected(false);
            }

            if (change)
            {
                Specials specials = CarConfig.GetInstance().GetSpecials()[0];
                Special editModeSelectedSpecial = specials.GetEditModeSelectedSpecial();

                if(CarConfigContext.buggy && specials.GetIndexOfSpecial(editModeSelectedSpecial) == specials.GetSpecialList().Count - 1)
                {
                    SpecialName.Text = "";
                    SpecialPrice.Text = Language.FormatPrice(0);
                }
                SpecialName.Text = specials.GetEditModeSelectedSpecial().GetName();
                SpecialPrice.Text = specials.GetEditModeSelectedSpecial().GetPriceString();
                DescriptionEditor.Text = specials.GetEditModeSelectedSpecial().GetDescription();
                
                List<Accessory> accss = specials.GetEditModeSelectedSpecial().GetAccessories();
                
                foreach(Accessory a in accss)
                {
                    int index = cc.GetAccessories()[0].GetIndexOfAccessory(a);
                    selected.Add(index);
                    accessories[index].SetSelected(true);
                }
            }

            accessoriesList.ItemsSource = accessories;

            this.change = change;

            SeperatePrices.Text = Language.FormatPrice(GetSeperatePrices());
		}

        private void listSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            Switch s = (Switch)sender;
            Grid parent = (Grid)s.Parent;
            Label id = (Label)parent.Children[2];
            int index = CarConfig.GetInstance().GetAccessories()[0].GetIndexOfAccessory(id.Text);

            if (e.Value && index > -1)
            {
                selected.Add(index);
            }
            else
            {
                selected.Remove(index);
            }

            SeperatePrices.Text = Language.FormatPrice(GetSeperatePrices());
        }

        private async void Finish_Clicked(object sender, EventArgs e)
        {
            CarConfig.GetInstance().SleepForLoadtesting();
            string specialName = SpecialName.Text;
            string specialPrice = SpecialPrice.Text;
            string specialDescription = DescriptionEditor.Text;

            if (change)
            {
                try
                {
                    Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];
                    Specials specials = CarConfig.GetInstance().GetSpecials()[0];
                    specials.ChangeSelectedSpecial(specialName, specialDescription, specialPrice, selected, accessories);

                    CarConfigContext.optionsSpecialsPage.UpdateSpecialsListItemsSource();

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
                try
                {
                    List<Accessory> selectedAccessories = new List<Accessory>();
                    Accessories accessories = CarConfig.GetInstance().GetAccessories()[0];
                    foreach(int i in selected)
                    {
                        selectedAccessories.Add(accessories.GetAccessory(i));
                    }
                    Special s = new Special(specialName, specialDescription, specialPrice, selectedAccessories);
                    Specials specials = CarConfig.GetInstance().GetSpecials()[0];
                    specials.AddSpecial(s);

                    CarConfigContext.optionsSpecialsPage.UpdateSpecialsListItemsSource();

                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                catch(InvalidPriceException ipe)
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

        private long GetSeperatePrices()
        {
            long returnValue = 0;

            Accessories acs = CarConfig.GetInstance().GetAccessories()[0];
            foreach(int i in selected)
            {
                try
                {
                    returnValue += acs.GetAccessory(i).GetPrice();
                }
                catch(IndexOutOfRangeException ioore)
                {
                }
            }
            return returnValue;
        }
    }
}