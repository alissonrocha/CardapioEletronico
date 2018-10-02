using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace CardapioEletronico
{

    public class Post
    {

        public string id { get; set; }
        public string nome { get; set; }
        public string preco { get; set; }
        public string descricao { get; set; }
    }

        public partial class MainPage : ContentPage
    {
        //private const string url = @"C:\Users\W10\Desktop\Xamarin\insert_product.php";
        private const string url = "http://192.168.0.6/apibd/get_all_products.php";

        private HttpClient _Client = new HttpClient();
        private ObservableCollection<Post> _post;

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Post>>(content);
            _post = new ObservableCollection<Post>(post);
            Post_List.ItemsSource = _post;
            base.OnAppearing();
        }

    }
}
