using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StatisticsApp.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VDescriptive : ContentPage
    {
        public VDescriptive()
        {
            InitializeComponent();
            ListView lb = new ListView();
        }

        private void NavigateToLoadUserData(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VLoadUserData() { BindingContext = this.BindingContext});
        }
    }
}