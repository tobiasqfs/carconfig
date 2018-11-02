using CarConfigurator.de.qfs.model;
using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator.settings.order
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderStatisticsPage : ContentPage
	{
		public OrderStatisticsPage ()
		{
			InitializeComponent ();

            this.Title = Language.GetString("menu.order.statistics");

            CarConfig cc = CarConfig.GetInstance();
            cc.SleepForLoadtesting();

            SelectedModelLbl.Text = Language.GetString("menu.order.view.selectedVehicle");
            if(cc.GetVehicles()[0].GetSelectedVehicle() != null)
            {
                SelectedModelTxtFld.Text = cc.GetVehicles()[0].GetNameOfSelectedVehicle();
            }
            else
            {
                SelectedModelTxtFld.Text = Language.GetString("menu.order.view.noSelectedVehicle");
            }


            headerWeek.Text = Language.GetString("menu.order.statistics.week") ;
            headerOrderedAmount.Text = Language.GetString("menu.order.statistics.orderedAmount");

            int[][] data;
            CultureInfo ci = new CultureInfo("de-DE");
            Calendar cal = ci.Calendar;

            int week = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
            if (cc.GetVehicles()[0].GetSelectedVehicle() != null)
            {
                string car = cc.GetVehicles()[0].GetNameOfSelectedVehicle();

                if (car.Equals("Rolo"))
                {
                    data = new int[][] { new int[]{ week, 3 },
                        new int[]{ week - 1, 8 } };
                }
                else if (car.Equals("Minigolf"))
                {
                    data = new int[][] { new int[]{ week, 10 },
                        new int[]{ week - 1, 32 },
                        new int[]{ week - 2, 12 },
                        new int[]{ week - 3, 2 },
                        new int[]{ week - 4, 21 },
                        new int[]{ week - 5, 12 } };
                }
                else if (car.Equals("Rassant"))
                {
                    data = new int[][] { new int[]{ week, 8 },
                        new int[]{ week - 1, 2 },
                        new int[]{ week - 2, 22 },
                        new int[]{ week - 3, 4 },
                        new int[]{ week - 4, 6 },
                        new int[]{ week - 5, 15 } };
                }
                else if (car.Equals("Rassant Family"))
                {
                    data = new int[][] { new int[]{ week, 1 },
                        new int[]{ week - 1, 13 },
                        new int[]{ week - 2, 5 },
                        new int[]{ week - 3, 27 },
                        new int[]{ week - 4, 11 } };
                }
                else if (car.Equals("I5"))
                {
                    data = new int[][] { new int[]{ week, 3 },
                        new int[]{ week - 1, 12 },
                        new int[]{ week - 2, 0 },
                        new int[]{ week - 3, 19 } };
                }
                else
                {
                    data = new int[][] { new int[]{ week, 0 } };
                }
            }
            else
            {
                data = new int[][] { new int[] { week, 0 } };
            }
            AddStatistics(data);

        }

        private void AddStatistics(int[][] data)
        {
            int j = 0;
            List<StatisticsWeek> sw = new List<StatisticsWeek>();
            foreach(int[] i in data)
            {
                sw.Add(new StatisticsWeek(i[0].ToString(), i[1].ToString()));
            }
            contentList.ItemsSource = sw;
        }

        private async void OkButton_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}