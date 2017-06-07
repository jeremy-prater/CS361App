using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MapAppTest
{
	public class ChatPage : ContentPage
	{
		public ChatPage ()
		{
            // A lot of this content comes from the provided Xamarin messaging example

            BindingContext = new ChatPageViewModel();

            Label header = new Label
            {
                Text = "Inter-Program Testing",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(EntryCell)),
                HorizontalOptions = LayoutOptions.Center
            };

            // Need to define our special text box before we render it in a table
            var textBox = new EntryCell
            {
                Label = "Name:",
                Placeholder = "John Doe",
                Text = "Instructor Rooker",
                Keyboard = Keyboard.Default
            };

            TableView tableView = new TableView
            {
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        textBox
                    }
                }
            };

            // Send messages when buttons are pressed
            var button1 = new Button { Text = "Say Hi" };
            button1.Clicked += (sender, e) => {
                MessagingCenter.Send<ChatPage>(this, "Hi");
            };
            var button2 = new Button { Text = "Say Hi to me!"};
            button2.Clicked += (sender, e) => {
                MessagingCenter.Send<ChatPage, string>(this, "Hi", textBox.Text);
            };

            var button3 = new Button { Text = "Unsubscribe from alert" };
            button3.Clicked += (sender, e) => {
                MessagingCenter.Unsubscribe<ChatPage, string>(this, "Hi");
                DisplayAlert("Unsubscribed",
                    "This page has stopped listening, so no more alerts; however the ViewModel is still receiving messages.",
                    "OK");
            };

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<ChatPage, string>(this, "Hi", (sender, arg) => {
                DisplayAlert("Message Received", "arg=" + arg, "OK");
            });

            var listView = new ListView();
            listView.SetBinding(ListView.ItemsSourceProperty, "Greetings");

            Content = new StackLayout
            {
                //Padding = new Thickness(0, 20, 0, 0),
                Children = { header, tableView, button1, button2, button3, listView }
            };
        }
	}
}