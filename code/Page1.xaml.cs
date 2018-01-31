using App15.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void PostsDoneRecognizer_OnTapped(Object sender, EventArgs e)
        {
            BackgroundColor = Color.Aqua;
        }
    }
}
