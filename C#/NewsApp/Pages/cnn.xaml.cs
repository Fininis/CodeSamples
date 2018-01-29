using ModernUINavigationApp.NewsApp.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Navigation;

namespace ModernUINavigationApp.NewsApp {
    /// <summary>
    /// Interaction logic for BasicPage.xaml
    /// </summary>
    public partial class BasicPage : UserControl {
        public RootObject articlesParsed { get; set; }
        public int index { get; set; }
        public BasicPage() {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents() {
            LoadTheNews();
            btnTop.Click += exe1;
            btnLatest.Click += exe2;
            listBox1.MouseDoubleClick += SelectedItem;

        }

        private void exe1(object sender, RoutedEventArgs e) {
            listBox1.Items.Clear();
            LoadTheNews();
        }

        private void exe2(object sender, RoutedEventArgs e) {
            listBox1.Items.Clear();
            using (var webClient = new System.Net.WebClient()) {
                var json = webClient.DownloadString("https://newsapi.org/v1/articles?source=al-jazeera-english&sortBy=latest&apiKey=8b13b97732ec469a898057b3a5af460f");
                var articlesPar = JsonConvert.DeserializeObject<RootObject>(json);
                articlesParsed = articlesPar;
                articlesPar.articles.ForEach(item => listBox1.Items.Add(new DirectoryListing(item.author.ToString(), item.title.ToString(), "Today", item.urlToImage.ToString())));
            }
        }

        private void LoadTheNews() {
            using (var webClient = new System.Net.WebClient()) {
                var json = webClient.DownloadString("https://newsapi.org/v1/articles?source=al-jazeera-english&sortBy=top&apiKey=8b13b97732ec469a898057b3a5af460f");
                var articlesPar = JsonConvert.DeserializeObject<RootObject>(json);
                articlesParsed = articlesPar;
                articlesPar.articles.ForEach(item => listBox1.Items.Add(new DirectoryListing(item.author.ToString(), item.title.ToString(), "Today", item.urlToImage.ToString())));
            }
        }

        private void SelectedItem(object sender, MouseButtonEventArgs e) {
            var index = listBox1.SelectedIndex;

            var newStory = new NewArticle();

            newStory.brzr.Navigate(articlesParsed.articles[index].url.ToString());

            newStory.Show();
        }
    }
}