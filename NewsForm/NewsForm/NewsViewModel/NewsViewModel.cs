using LoginApp.NewsModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace LoginApp.NewsViewModel
{
    class NewsViewModel : INotifyPropertyChanged
    {
        private string _title;
        private string _description;
        private string _url;
        private string _urlToImage;
        private DateTime _publishedAt;


        public string Title
        {
            get { return _title; }
            private set
            {
                _title = value;
                OnPropertyChanged("title");
            }
        }
        public string Description
        {
            get { return _description; }
            private set
            {
                _description = value;
                OnPropertyChanged("description");
            }
        }

        public string Url
        {
            get { return _url; }
            private set
            {
                _url = value;
                OnPropertyChanged("url");
            }
        }

        public string UrlToImage
        {
            get { return _urlToImage; }
            private set
            {
                _urlToImage = value;
                OnPropertyChanged("urlToImage");
            }
        }

        public DateTime PublishedAt
        {
            get { return _publishedAt; }
            private set
            {
                _publishedAt = value;
                OnPropertyChanged("publishedAt");
            }
        }

        public ICommand LoadDataCommand { protected set; get; }

        public NewsViewModel()
        {
            this.LoadDataCommand = new Command(LoadData);
        }

        private async void LoadData()
        {
            string url = "https://query.yahooapis.com/v1/public/yql?q=select+*+from+yahoo.finance.xchange+where+pair+=+%22USDRUB%22&format=json&env=store%3A%2F%2Fdatatables.org%2Falltableswithkeys&callback=";

            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(url);
                var response = await client.GetAsync(client.BaseAddress);
                response.EnsureSuccessStatusCode(); // выброс исключения, если произошла ошибка

                // десериализация ответа в формате json
                var content = await response.Content.ReadAsStringAsync();
                JObject o = JObject.Parse(content);

                var str = o.SelectToken(@"$.query.results.rate");
                var newsInfo = JsonConvert.DeserializeObject<Article>(str.ToString());

                this._title = newsInfo.Title;
                this._description = newsInfo.Description;
                this._url = newsInfo.Url;
                this._urlToImage = newsInfo.UrlToImage;
                this._publishedAt = newsInfo.PublishedAt;
            }
            catch (Exception)
            { }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
