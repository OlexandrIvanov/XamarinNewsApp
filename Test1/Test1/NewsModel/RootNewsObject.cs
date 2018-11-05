using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.NewsModel
{
    class RootNewsObject
    {
        public string Status { get; set; }
        public int TotalResults { get; set; }
        public List<Article> Articles { get; set; }
    }
}
