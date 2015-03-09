using System;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using System.IO;

namespace PuppiesKittiesOMy
{
	public abstract class PicturePage : ContentPage
	{
		private Image theImage = null;
		private Button refreshButton = null;

		private ActivityIndicator loading = null;

		public string ButtonTitle { get; set; }

		public string RefreshUrl { get; set; }

		public PicturePage (string buttonTitle, string url)
		{
            this.ButtonTitle = buttonTitle;
            this.RefreshUrl = url;

			this.BindingContext = this;

			var stack = new StackLayout () {
				Orientation = StackOrientation.Vertical,
				Padding = 10,
				Spacing = 10
			};

			refreshButton = new Button () {
				Text = ButtonTitle
			};
			refreshButton.Clicked += HandleClicked;

			loading = new ActivityIndicator ();

			theImage = new Image 
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions  = LayoutOptions.CenterAndExpand
			};

			stack.Children.Add (refreshButton);
			stack.Children.Add (loading);
			stack.Children.Add (theImage);

			this.Content = stack;
		}

		async void HandleClicked (object sender, EventArgs e)
		{
			using (var web = new HttpClient()) 
			{
				ShowLoading ();

                try {
    				var result = await web.GetStreamAsync (RefreshUrl);

    				theImage.Source = ImageSource.FromStream (() => {
    					return (Stream)result;
    				});
                }
                catch(Exception oops)
                {
                    DisplayAlert("Uh Ohh..", "Something bad happened. Try that again.", "Ok");
                }

				HideLoading ();
			}
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			HandleClicked (null, null);
		}

		private void ShowLoading()
		{
			this.loading.IsVisible = true;
			this.loading.IsRunning = true;

			this.theImage.IsVisible = false;
		}

		private void HideLoading()
		{
			this.loading.IsVisible = false;
			this.loading.IsRunning = false;
			this.theImage.IsVisible = true;
		}
	}
}