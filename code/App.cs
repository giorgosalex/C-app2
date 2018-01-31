using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;

using Xamarin.Forms;

namespace App1
{
    public class App : Application
    {
        public App()
        {

            MainPage = new NavigationPage(new HomePage());

            //GetRequest(null);
            /*// The root page of your application
            var content = new ContentPage
            {
                Title = "App1",
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        new Label {
                            HorizontalTextAlignment = TextAlignment.Center,
                            Text = "Welcome to Xamarin Forms!"
                        }
                    }
                }
            };

            MainPage = new NavigationPage(content);*/
        }

        async static void GetRequest(string url)
        {
            HttpClient client = new HttpClient(new NativeMessageHandler());
            client.DefaultRequestHeaders.Add("gcube-token", "994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");

            //client.BaseAddress = new Uri("https://socialnetworking-d-d4s.d4science.org/social-networking-library-ws/rest");
            HttpResponseMessage response = await client.GetAsync("https://socialnetworking1.d4science.org/social-networking-library-ws/rest/2/users/get-profile?gcube-token=994e41a4-01fb-4c6b-b953-24d02c8a5949-843339462");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                //var posts = JsonConvert.DeserializeObject<VrePosts>(content);
                //long unixDate = 1490149263303;
                //DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                //DateTime date = start.AddMilliseconds(unixDate).ToLocalTime();
                Debug.WriteLine(content.ToString());
            }
            else
            {
                Debug.WriteLine("Why the fuck");
            }
            //client.BaseAddress = new Uri("https://www.google.com");
            //HttpResponseMessage respone = await client.PostAsync("", null);
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
