using System;
using System.Collections.Generic;
using System.Text;

namespace LoginApp.NewsModel
{
    class RootNewsObject
    {
        public string status { get; set; }
        public int totalResults { get; set; }
        public List<Article> articles { get; set; }
    }
}
