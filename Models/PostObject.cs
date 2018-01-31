using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    class PostObject
    {
        public string text { get; set; }
        public string preview_title { get; set; }
        public string preview_description { get; set; }
        public string preview_host { get; set; }
        public string preview_url { get; set; }
        public string image_url { get; set; }
        public bool enable_notification { get; set; }
        public string parameters { get; set; }
    }
}
