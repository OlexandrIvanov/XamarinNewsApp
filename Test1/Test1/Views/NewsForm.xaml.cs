using LoginApp.NewsModel;
using LoginApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoginApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewsForm : ContentPage
	{

        public ObservableCollection<Article> ArticlesList { get; set; }

        public NewsForm ()
		{
			InitializeComponent ();

            NewsViewModel.NewsViewModel newsViewModel = new NewsViewModel.NewsViewModel();
            BindingContext = newsViewModel;

        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
             if(e.SelectedItem != null)
             {
                 Article article = e.SelectedItem as Article;
                 ((ListView)sender).SelectedItem = null;
                 ToNewsInDetailForm(article);
             }

        }

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            Image imageSender = (Image)sender;

            ToNewsImageDetailForm(imageSender.Source);

        }

        private async void ToNewsInDetailForm(Article article)
        {
            await Navigation.PushModalAsync(new NewsInDetailForm(article));
        }

        private async void ToNewsImageDetailForm(ImageSource newsImageSource)
        {
            await Navigation.PushModalAsync(new NewsImageDetailForm(newsImageSource));
        }


    }
}