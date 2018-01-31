using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App15.Models;
using System.Diagnostics;
using System.Net.Http;
using ModernHttpClient;
using Newtonsoft.Json;

namespace App15.ViewModels
{
    public class ViewPosts
    {
        public VrePosts posts { get; set; }
        public int total { get; set; }

        public ViewPosts(string url)
        {
            if (url != null)
            {
                posts = GetPosts_Request(url).Result;

                foreach (var post in posts.result)
                {
                    DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                    DateTime date = start.AddMilliseconds(post.time).ToLocalTime();

                    switch (date.Month)
                    {
                        case 1:
                            post.date = "January ";
                            break;
                        case 2:
                            post.date = "February ";
                            break;
                        case 3:
                            post.date = "March ";
                            break;
                        case 4:
                            post.date = "April ";
                            break;
                        case 5:
                            post.date = "May ";
                            break;
                        case 6:
                            post.date = "June ";
                            break;
                        case 7:
                            post.date = "July ";
                            break;
                        case 8:
                            post.date = "August ";
                            break;
                        case 9:
                            post.date = "September ";
                            break;
                        case 10:
                            post.date = "October ";
                            break;
                        case 11:
                            post.date = "November ";
                            break;
                        case 12:
                            post.date = "December ";
                            break;
                    }
                    post.date += date.Day + " " + date.Year + ", " + date.Hour + ":" + date.Minute;

                    //post.thumbnail_url = "https://infra-gateway.d4science.org:443" + post.thumbnail_url;
                    post.comments.Add("aaaaaaaaaaaaaaaaaaaaaaa");
                    post.comments.Add("bbbbbbbbbbbbbbbbbbbbbbb");
                    post.comments.Add("ccccccccccccccccccccccc");
                }

                total = posts.result.Count();
            }else
            {
                posts = new VrePosts();
            }
        }

        private async Task<VrePosts> GetPosts_Request(string url)
        {
            HttpClient client = new HttpClient(new NativeMessageHandler());

            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<VrePosts>(content);
                //Debug.WriteLine(myprofile.result.fullname);
                return posts;
            }
            else
            {
                Debug.WriteLine("Why the fuck");
            }
            return null;
        }
    }
}
