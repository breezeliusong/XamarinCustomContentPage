﻿using System;
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
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello Page",BackgroundColor=Color.Red }
                }
            };
        }
    }
}
