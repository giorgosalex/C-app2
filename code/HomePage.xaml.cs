using App1.Models;
using App1.ViewModels;
using App15.Models;
using App15.ViewModels;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class HomePage : ContentPage
    {
        HomeViewModel homev;

        public HomePage()
        {
            homev = new HomeViewModel();

            ViewPosts viewp = new ViewPosts("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/posts/get-posts-vre?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");
            BindingContext = homev;

            InitializeComponent();

            HomeListView.ItemsSource = homev.feedPosts.posts.result;
        }

        private async void ProfileMenuItem_OnClicked(Object sender, EventArgs e)
        {
            var newPage = new UserPosts();
            await Navigation.PushAsync(newPage);
        }

        private async void PostsDoneRecognizer_OnTapped(Object sender, EventArgs e)
        {
            var stackSender = (StackLayout)sender;
            stackSender.BackgroundColor = Color.FromHex("#D7D7D7");

            await Navigation.PushAsync(new Page2(homev.userPosts));

            stackSender.BackgroundColor = Color.White;
        }

        private async void LikesDoneRecognizer_OnTapped(Object sender, EventArgs e)
        {
            var stackSender = (StackLayout)sender;
            stackSender.BackgroundColor = Color.FromHex("#D7D7D7");

            await Navigation.PushAsync(new Page2(homev.userLikedPosts));

            stackSender.BackgroundColor = Color.White;
        }

        private async void RepliesDoneRecognizer_OnTapped(Object sender, EventArgs e)
        {
            var stackSender = (StackLayout)sender;
            stackSender.BackgroundColor = Color.FromHex("#D7D7D7");

            await Navigation.PushAsync(new Page2(homev.userCommentedPosts));

            stackSender.BackgroundColor = Color.White;
        }

        private async void LikesGotRecognizer_OnTapped(Object sender, EventArgs e)
        {
            var stackSender = (StackLayout)sender;
            stackSender.BackgroundColor = Color.FromHex("#D7D7D7");

            await Navigation.PushAsync(new Page2(homev.userPostsLiked));

            stackSender.BackgroundColor = Color.White;
        }

        /*private async void RepliesGotRecognizer_OnTapped(Object sender, EventArgs e)
        {
            var stackSender = (StackLayout)sender;
            stackSender.BackgroundColor = Color.FromHex("#D7D7D7");

            await Navigation.PushAsync(new Page2(homev.userPostsCommented));

            stackSender.BackgroundColor = Color.White;
        }*/

        private async void RepliesGotRecognizer_OnTapped(Object sender, EventArgs e)
        {
            var stackSender = (StackLayout)sender;
            stackSender.BackgroundColor = Color.FromHex("#D7D7D7");

            PostObject myObj = new PostObject();
            myObj.text = "Test post from portable mobile application!";
            myObj.enable_notification = false;
            myObj.image_url = "";
            myObj.parameters = "";
            myObj.preview_description = "";
            myObj.preview_host = "";
            myObj.preview_title = "";
            myObj.preview_url = "";

            var jsonObject = JsonConvert.SerializeObject(myObj);
            var parameters = new StringContent(jsonObject.ToString(), Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient(new NativeMessageHandler());

            HttpResponseMessage response = await client.PostAsync("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/posts/write-post-user?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462", parameters);
            if (response.IsSuccessStatusCode)
            {
                //var content = await response.Content.ReadAsStringAsync();
                //var posts = JsonConvert.DeserializeObject<VrePosts>(content);
                //Debug.WriteLine(myprofile.result.fullname);
                Debug.WriteLine("Done");
            }
            else
            {
                Debug.WriteLine("Why the fuck");
            }

            stackSender.BackgroundColor = Color.White;
        }
    }
}
