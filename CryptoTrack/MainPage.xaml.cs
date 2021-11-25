using CryptoTrack.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace CryptoTrack
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "E81479A0-4F67-4500-AF80-51EDB4AD5263";
        private string baseImageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_64/";
        public MainPage()
        {
            InitializeComponent();
            coinListView.ItemsSource = GetCoins();
        }
        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            coinListView.ItemsSource = GetCoins();
        }
        private List<Coin> GetCoins()
        {
            List<Coin> coins;

            var client = new RestClient("http://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;XMR;LTC;XLM");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);
            var response = client.Execute(request);
            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                c.icon_url = baseImageUrl + c.id_icon.Replace("-", "") + ".png";
                c.display_name = c.name + " (" + c.asset_id + ")";
            }

            return coins;
        }
    }
}
