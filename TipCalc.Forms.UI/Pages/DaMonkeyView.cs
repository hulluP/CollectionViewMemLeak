using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using TipCalc.Core.ViewModels;
using Xamarin.Forms;

namespace TipCalc.Forms.UI.Pages
{
    public class DaMonkeyView : MvxContentPage<DaMonkeyDetailsModel>
    {
        private Label name;
        private Label location;
        private Label details;
        private Image daMonkeyImage;

        public DaMonkeyView()
        {
            StackLayout stackLayout = new StackLayout();
            name = new Label
            {
                Text = "..."
            };
            stackLayout.Children.Add(name);


            location = new Label
            {
                Text = "Generosity"
            };
            stackLayout.Children.Add(location);

            details = new Label
            {
                Text = "xx"
            };
            stackLayout.Children.Add(details);

            daMonkeyImage = new Image()
            {
                BackgroundColor = Color.Gray,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                IsAnimationPlaying = true

            };

            stackLayout.Children.Add(daMonkeyImage);
            Content = stackLayout;
        }
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            var set = this.CreateBindingSet<DaMonkeyView, DaMonkeyDetailsModel>();
            set.Bind(name).For(v => v.Text).To(vm => vm.DaMonkey.Name).OneWay();
            set.Bind(location).For(v => v.Text).To(vm => vm.DaMonkey.Location).OneWay();
            set.Bind(details).For(v => v.Text).To(vm => vm.DaMonkey.Details).OneWay();
            set.Bind(daMonkeyImage).For(v => v.Source).To(vm => vm.DaMonkey.ImageSrc).OneWay();




            set.Apply();
        }
    }
}
