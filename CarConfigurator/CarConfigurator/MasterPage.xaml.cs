using CarConfigurator.de.qfs.model.lang;
using CarConfigurator.de.qfs.model.ui;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CarConfigurator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterPage : ContentPage
	{
        Rectangle drawerExpandedPosition;
        Rectangle drawerCollapsedPosition;

        public List<ListItem> MyDataSource { get; set; } // Must have default value or be set before the BindingContext is set.

        private int _position;
        public int Position { get { return _position; } set { _position = value; OnPropertyChanged(); } }


        public DataTemplate SimpleTemplate { get; set; }
        public DataTemplate ComplexTemplate { get; set; }

        public MasterPage ()
		{
			InitializeComponent ();

            // setting the correct titles for the MasterPage items
            List<MasterPageItem> masterPageItems = new List<MasterPageItem>();

            // An Example DataSource
            MyDataSource = new List<ListItem>() { new ListItem("Title1", 0),
                                                      new ListItem("Title2", 1),
                                                      new ListItem("Title3", 2),
                                                      new ListItem("Title4", 3)};

            BindingContext = this;

            toggleButton.Text = Language.GetString("calcpane.toggleButton.hide");

            priceModelLabel.Text = Language.GetString("calcpane.priceModel");
            priceModel.Text = "12345";
            priceModel.TextColor = Color.White;

            priceSpecialLabel.Text = Language.GetString("calcpane.priceSpecial");
            priceSpecial.Text = "67890";

            discountLabel.Text = Language.GetString("calcpane.discount");
            discount.Text = "0 %";

            endPriceLabel.Text = Language.GetString("calcpane.endprice");

            discountButton.Text = Language.GetString("calcpane.discountButton");
        }

        protected override void OnAppearing()
        {
            var actualHeight = expandingTitleLayout.Height;
            drawerExpandedPosition = overlay.Bounds;
            drawerCollapsedPosition = overlay.Bounds;

            drawerCollapsedPosition.Y = overlay.Height - actualHeight;
            drawerExpandedPosition.Y = 0;

            overlay.TranslateTo(drawerExpandedPosition.X, drawerExpandedPosition.Y, 250, Easing.CubicOut);

            base.OnAppearing();
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

        private void discountButton_Clicked(object sender, System.EventArgs e)
        {

        }
    }
}