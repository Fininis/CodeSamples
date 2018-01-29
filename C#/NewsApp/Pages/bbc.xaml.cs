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

namespace ModernUINavigationApp.NewsApp.Pages {
    /// <summary>
    /// Interaction logic for bbc.xaml
    /// </summary>
    public partial class bbc : UserControl {
        public RootObject articlesParsed { get; set; }
        public int index { get; set; }
        public bbc() {
            InitializeComponent();
            RegisterEvents();
        }

        private void RegisterEvents() {
            LoadTheNews();
        }

        private void LoadTheNews() {
            using (var webClient = new System.Net.WebClient()) {
                var json = webClient.DownloadString("https://newsapi.org/v1/articles?source=bbc-news&sortBy=top&apiKey=8b13b97732ec469a898057b3a5af460f");
                var articlesPar = JsonConvert.DeserializeObject<RootObject>(json);
                articlesParsed = articlesPar;
                articlesPar.articles.ForEach(item => listBox1.Items.Add(item.title.ToString()));
                listBox1.MouseDoubleClick += SelectedItem;
            }
        }

        private void SelectedItem(object sender, MouseButtonEventArgs e) {
            for (int i = 0; i < articlesParsed.articles.Count(); i++) {
                if ((string)listBox1.SelectedItem == articlesParsed.articles[i].title.ToString()) {
                    var newStory = new NewArticle();

                    newStory.brzr.Navigate(articlesParsed.articles[i].url.ToString());

                    newStory.Show();
                    index = i;
                }
            }
        }
    }
}
