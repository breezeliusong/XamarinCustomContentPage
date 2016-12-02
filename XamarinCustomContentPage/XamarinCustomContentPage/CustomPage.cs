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

        //Expose a event to add behaviors
        public event EventHandler ButtonClicked;

        //call this method in corresponding renders and using the register event
        public void NotifyButtonClicked()
        {
            if (ButtonClicked != null)
            {
                ButtonClicked(this, new EventArgs());
            }
        }
    }
}
