

using Xamarin.Forms;

namespace TipCalc.Core.ViewModels
{
    public class Monkey
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFavorite { get; set; }
        public ImageSource ImageSrc
        {
            get
            {
                return ImageSource.FromUri(new System.Uri(ImageUrl));
            }
            set { }
        }
    }
}
