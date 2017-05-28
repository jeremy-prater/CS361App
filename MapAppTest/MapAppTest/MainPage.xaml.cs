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
        static MainPage mainPage = null;

        public MainPage()
        {
            InitializeComponent();
            if (mainPage == null)
            {
                mainPage = this;
            }
            else
            {
                // How can this happen, and how does it get logged?
                // syslog?
                // local file/memory?
            }
        }

        static public Map GetMap()
        {
            return mainPage.MyMap;
        }
    }
}
