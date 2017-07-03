using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace StatisticsApp
{
    public partial class App : Application
    {
        public static ResourceDictionary AppResources;

        public App()
        {
            InitializeComponent();
            TabbedPage MP = new StatisticsApp.View.MainPage();
            MP.BarBackgroundColor = (Color)Resources["DetailColor"];
            MP.BarTextColor = (Color)Resources["TextSecondaryColor"];

            MP.Children.Add(new StatisticsApp.View.VDescriptive() { BindingContext=new ViewModel.VMDescriptive()});
            MP.Children.Add(new StatisticsApp.View.VGraphic());
            MP.Children.Add(new StatisticsApp.View.VTheory());

            MainPage = new NavigationPage(MP);
            AppResources = this.Resources;            
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
