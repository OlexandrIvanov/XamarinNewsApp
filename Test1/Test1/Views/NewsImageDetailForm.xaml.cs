using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsImageDetailForm : ContentPage
	{

        ImageSource newsImageSource;


        public NewsImageDetailForm()
        {
            InitializeComponent();
        }


        public NewsImageDetailForm (ImageSource newsImageSource)
		{
			InitializeComponent ();
            _imageNews.Source = newsImageSource;


        }
	}
}