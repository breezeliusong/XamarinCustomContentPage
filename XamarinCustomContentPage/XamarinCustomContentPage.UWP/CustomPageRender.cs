using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using XamarinCustomContentPage;
using XamarinCustomContentPage.UWP;

//registers the renderer with Xamarin.Forms.
[assembly: ExportRenderer(typeof(CustomPage), typeof(CustomPageRender))]
namespace XamarinCustomContentPage.UWP
{

    public class CustomPageRender : PageRenderer
    {
        Windows.UI.Xaml.Controls.Page page;
        Windows.UI.Xaml.Controls.StackPanel sta;
        /*
         * This method takes an ElementChangedEventArgs parameter that contains OldElement and NewElement properties.
         * These properties represent the Xamarin.Forms element that the renderer was attached to, 
         * and the Xamarin.Forms element that the renderer is attached to, respectively. 
         * In the sample application the OldElement property will be null 
         * and the NewElement property will contain a reference to the CameraPage instance.
         */
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null) return;
            Windows.UI.Xaml.Controls.Image image = new Windows.UI.Xaml.Controls.Image()
            {
                Width = 100,
                Height = 100,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left
            };
            BitmapImage bitmapImage = new BitmapImage(new Uri("ms-appx://XamarinCustomContentPage.UWP/Assets/picture.png"));
            image.Source = bitmapImage;
            
            sta = new Windows.UI.Xaml.Controls.StackPanel();
            Windows.UI.Xaml.Controls.Button bt = new Windows.UI.Xaml.Controls.Button();
            bt.Content = "hello , my custom page";
            bt.Background = new Windows.UI.Xaml.Media.SolidColorBrush(Windows.UI.Color.FromArgb(25,0,0,255));
            bt.Click +=OnClicked;
            sta.Children.Add(image);
            sta.Children.Add(bt);

            //instantiate a page
            page = new Windows.UI.Xaml.Controls.Page();
            //add content to a page
            page.Content = sta;

            //put this page to this custom render as a children
            //must add content to the renderer,the content can be a stackpanel or the page or the image

            //a control only can be add into a contain control such as,if the image control add to the stackpanel ,
            //it can not be added to page.content or this render.content
            this.Children.Add(page);
        }

        private void OnClicked(object sender, RoutedEventArgs e)
        {
        }


        /*
         * When implementing a custom renderer that derives from PageRenderer on UWP, 
         * the ArrangeOverride method should also be implemented to arrange the page controls,
         *  because the base renderer doesn't know what to do with them.
         *   Otherwise, a blank page results
         */
        protected override Windows.Foundation.Size ArrangeOverride(Windows.Foundation.Size finalSize)
        {
            page.Arrange(new Windows.Foundation.Rect(0, 0, finalSize.Width, finalSize.Height));
            return finalSize;
        }
    }
}
