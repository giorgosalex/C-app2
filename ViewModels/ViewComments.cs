using App1.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    class ViewComments
    {
        public Comments comments { get; set; }
        public int total { get; set; }

        public ViewComments(string url)
        {

            comments = GetComments_Request(url).Result;

            if(comments == null)
            {
                return;
            }
            foreach (var comment in comments.result)
            {
                DateTime start = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                DateTime date = start.AddMilliseconds(comment.time).ToLocalTime();

                switch (date.Month)
                {
                    case 1:
                        comment.date = "January ";
                        break;
                    case 2:
                        comment.date = "February ";
                        break;
                    case 3:
                        comment.date = "March ";
                        break;
                    case 4:
                        comment.date = "April ";
                        break;
                    case 5:
                        comment.date = "May ";
                        break;
                    case 6:
                        comment.date = "June ";
                        break;
                    case 7:
                        comment.date = "July ";
                        break;
                    case 8:
                        comment.date = "August ";
                        break;
                    case 9:
                        comment.date = "September ";
                        break;
                    case 10:
                        comment.date = "October ";
                        break;
                    case 11:
                        comment.date = "November ";
                        break;
                    case 12:
                        comment.date = "December ";
                        break;
                }
                comment.date += date.Day + " " + date.Year + ", " + date.Hour + ":" + date.Minute;
            }

            total = comments.result.Count();
        }

        private async Task<Comments> GetComments_Request(string url)
        {
            HttpClient client = new HttpClient(new NativeMessageHandler());

            HttpResponseMessage response = await client.GetAsync(url).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<Comments>(content);
                //Debug.WriteLine(myprofile.result.fullname);
                return comments;
            }
            else
            {
                Debug.WriteLine("Why the fuck");
            }
            return null;
        }
    }
}
