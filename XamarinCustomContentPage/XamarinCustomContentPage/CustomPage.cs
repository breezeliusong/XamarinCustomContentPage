using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinCustomContentPage
{
    public class CustomPage:ContentPage
    {
        public CustomPage()
        {
            this.ButtonClicked = (ob, arg) => { Navigation.PushAsync(new CustomPage()); };
        }
        public event EventHandler ButtonClicked;

        public void NotifyButtonClicked()
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(this, new EventArgs());
            }
        }
    }
}
