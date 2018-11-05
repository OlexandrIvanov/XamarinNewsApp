using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;


namespace LoginApp.NewsModel
{
    public class GetNews
    { 
        public static async Task<ObservableCollection<Article>>  GetArticles() {

            string url = "https://newsapi.org/v2/top-headlines?country=us&apiKey=c6edbe527835404a9e39a957ae63d281";

            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };

            HttpResponseMessage response = null;
            try
            {
                response = await client.GetAsync(client.BaseAddress);
            }
            catch(ArgumentNullException) {}

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();

            JObject o = null;
            try
            {
                o = JObject.Parse(content);

            }
            catch (JsonReaderException) { }

            var str = o.SelectToken(@"$.articles");
            var newsInfo = JsonConvert.DeserializeObject<ObservableCollection<Article>>(str.ToString());

            return newsInfo;

        }
    }
}
