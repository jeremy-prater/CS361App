using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace MapAppTest
{
    public partial class MapPage : ContentPage
    {
        static MapPage mapPage = null;

        public MapPage()
        {
            InitializeComponent();
            if (mapPage == null)
            {
                mapPage = this;
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
            return mapPage.MyMap;
        }
    }
}
