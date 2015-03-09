using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PuppiesKittiesOMy
{
    public class App : Application
    {
        public App()
        {
            var tabbed = new TabbedPage();
            tabbed.Children.Add(new KittyPage());
            tabbed.Children.Add(new PuppyPage());
            tabbed.Title = "Puppies & Kitties Oh My!";
            // The root page of your application
            MainPage = new NavigationPage(tabbed);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
