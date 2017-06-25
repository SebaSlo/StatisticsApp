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
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            //this.BarBackgroundColor = Color.FromRgb(162, 121, 192);
            //this.BarTextColor = Color.WhiteSmoke;
        }
    }
}