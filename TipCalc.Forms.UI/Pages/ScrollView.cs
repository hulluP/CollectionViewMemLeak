
using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Forms.Views;
using TipCalc.Core.ViewModels;
using Xamarin.Forms;

namespace TipCalc.Forms.UI.Pages
{
    public class ScrollViewX : MvxContentPage<MonkeysViewModel>
    {

        private StackLayout stackLayout;
        private MvxListView DaList;
        private CollectionView DaCollectionView;

        public ScrollViewX()

        {
            stackLayout = new StackLayout();
            DaCollectionView = new CollectionView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                HeightRequest = 150,
                SelectionMode = SelectionMode.None,
                BackgroundColor = Color.Gray,
                ItemsLayout = new LinearItemsLayout(ItemsLayoutOrientation.Horizontal)
                {
                    ItemSpacing = 10
                },
                ItemTemplate = MonkeyTemplate(),
                Margin = new Thickness(10)
            };
            stackLayout.Children.Add(DaCollectionView);
            DaList = new MvxListView()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Start,
                SelectionMode = ListViewSelectionMode.None,
                SeparatorVisibility = SeparatorVisibility.None,
                ItemTemplate = new DataTemplate(typeof(CustomCell))

            };
            stackLayout.Children.Add(DaList);

            Content = stackLayout;

        }

        private DataTemplate MonkeyTemplate()
        {
            return new DataTemplate(() =>
            {

                var grid = new Grid();
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.5, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.3, GridUnitType.Star) });

                var nameLabel = new Label { FontAttributes = FontAttributes.Bold };
                var image = new Image();

                nameLabel.SetBinding(Label.TextProperty, "Name");
                image.SetBinding(Image.SourceProperty, "ImageSrc");

                grid.Children.Add(image);
                grid.Children.Add(nameLabel, 1, 0);

                return grid;
            });
        }

        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            var set = this.CreateBindingSet<ScrollViewX, MonkeysViewModel>();
            set.Bind(DaList).For(v => v.ItemsSource).To(vm => vm.Monkeys).OneWay();
            set.Bind(DaList).For("ItemClick").To(vm => vm.MonkeySelectedCommand);

            set.Bind(DaCollectionView).For(v => v.ItemsSource).To(vm => vm.ColMonkeys).OneWay();
            set.Bind(DaCollectionView).For("ItemClick").To(vm => vm.MonkeySelectedCommand);


            set.Apply();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();

        }

        public class CustomCell : ViewCell
        {
            public CustomCell()
            {


                var listImage = new Image
                {
                    BackgroundColor = Color.Gray,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    IsAnimationPlaying = true
                };
                Label monkeyName = new Label()
                {
                    //Text = ,
                    VerticalOptions = LayoutOptions.Center,
                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                    LineBreakMode = LineBreakMode.TailTruncation,
                };
                View = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Padding = new Thickness(15, 5, 5, 15),
                    Children = {
                          listImage, monkeyName
                }
                };
                monkeyName.SetBinding(Label.TextProperty, "Name");
                listImage.SetBinding(Image.SourceProperty, "ImageSrc");

            }
        }
    }
}