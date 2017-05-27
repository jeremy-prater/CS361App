using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapAppTest
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(37, -122), Distance.FromMiles(1)));

        }
    }
}
