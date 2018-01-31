using App15.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class UserPosts : ContentPage
    {
        public UserPosts()
        {
            ViewPosts viewp = new ViewPosts("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/posts/get-posts-user?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");
            BindingContext = viewp;

            InitializeComponent();

            HomeListView.ItemsSource = viewp.posts.result;
        }
    }
}
