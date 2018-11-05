using LoginApp.NewsModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsInDetailForm : ContentPage
	{

        Article Article { get; set; }

        public NewsInDetailForm()
        {
            InitializeComponent();

        }

        public NewsInDetailForm (Article article)
		{
            InitializeComponent();

            this.Article = article;

            this.BindingContext = Article;
		}


	}
}