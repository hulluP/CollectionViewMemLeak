using System;

using Xamarin.Forms;

namespace proto.iOS
{
    public class Setup : ContentPage
    {
        public Setup()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

