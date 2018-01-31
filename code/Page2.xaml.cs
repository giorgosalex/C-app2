using App15.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class Page2 : ContentPage
    {
        public Page2(ViewPosts userPosts)
        {
            InitializeComponent();

            HomeListView.ItemsSource = userPosts.posts.result;
        }
    }
}
