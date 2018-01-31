using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class Comments
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Comment> result { get; set; }

        public Comments()
        {
            result = new List<Comment>();
        }
    };

    class Comment
    {
        public string key { get; set; }
        public string userid { get; set; }
        public long time { get; set; }
        public string feedid { get; set; }
        public string text { get; set; }
        public string full_name { get; set; }
        public string thumbnail_url { get; set; }
        public string last_edit_time { get; set; }
        public bool edit { get; set; }

        public string date { get; set; }
    }
}
