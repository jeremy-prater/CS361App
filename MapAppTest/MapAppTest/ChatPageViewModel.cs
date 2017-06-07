using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MapAppTest
{
	public class ChatPageViewModel : ContentView
	{
        public ObservableCollection<string> Greetings { get; set; }

        public ChatPageViewModel()
        {
            Greetings = new ObservableCollection<string>();

            MessagingCenter.Subscribe<ChatPage>(this, "Hi", (sender) =>
            {
                Greetings.Add("Hi");
            });

            MessagingCenter.Subscribe<ChatPage, string>(this, "Hi", (sender, arg) =>
            {
                Greetings.Add("Hi " + arg);
            });
        }
    }
}