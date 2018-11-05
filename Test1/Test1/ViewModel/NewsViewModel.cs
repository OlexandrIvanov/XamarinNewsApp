using LoginApp.NewsModel;
using System.Collections.ObjectModel;

namespace LoginApp.NewsViewModel
{
    public class NewsViewModel : ObservableCollection<Article>
    {
       
        public NewsViewModel()
        {
            GetDataNews();
        }

        private async void GetDataNews() {
            ObservableCollection<Article> articlesList = await GetNews.GetArticles();
            for (int a = 0; a < articlesList.Count; a++)
            {
                Add(articlesList[a]);
            }

        }
    }
}
