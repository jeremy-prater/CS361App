using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapAppTest.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MapAppTest
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrailViewer : ContentPage
	{
		public TrailViewer ()
		{
			InitializeComponent ();
		}



        public void SetTrailData(TrailData matchedTrail)
        {
            trailName.Text = matchedTrail.name;
            location.Text = matchedTrail.city + " ," + matchedTrail.state;
            description.Text = matchedTrail.description;

            // Implement which activities are available at current trail
            //
            // foreach (TrailActivity activity in matchedTrail.activities)
            // activities.Text = "Things to do..."
        }

        private void back_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}