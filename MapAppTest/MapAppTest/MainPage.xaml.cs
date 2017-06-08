using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapAppTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : TabbedPage
    {
        static MainPage context = null;
        public MainPage ()
        {
            InitializeComponent();
            context = this;
        }

        public static MainPage GetCurrentContext()
        {
            return context;
        }
    }
}