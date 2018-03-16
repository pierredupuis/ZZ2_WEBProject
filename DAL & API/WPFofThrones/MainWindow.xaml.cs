using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFofThrones.Models;

namespace WPFofThrones
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private static async Task<HouseModel> GetHouse(int ID)
        {
            HouseModel House = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/House/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    House = JsonConvert.DeserializeObject<HouseModel>(temp);
                }
            }
            return House;
        }
        private async Task<List<HouseModel>> getHouseList()
        {
            List<HouseModel> Houses = new List<HouseModel>();
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/House");
                
                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Houses = JsonConvert.DeserializeObject<List<HouseModel>>(temp);
                }
            }
            return Houses;
        }
        private static async Task<WhiteWalkerModel> GetWhiteWalker(int ID)
        {
            WhiteWalkerModel WhiteWalker = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/WhiteWalker/" + ID);

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    WhiteWalker = JsonConvert.DeserializeObject<WhiteWalkerModel>(temp);
                }
            }
            return WhiteWalker;
        }
        private async Task<List<WhiteWalkerModel>> getWhiteWalkerList()
        {
            List<WhiteWalkerModel> Houses = new List<WhiteWalkerModel>();
            using (var client = new System.Net.Http.HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/WhiteWalker");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Houses = JsonConvert.DeserializeObject<List<WhiteWalkerModel>>(temp);
                }
            }
            return Houses;
        }
        private async Task<List<FightModel>> getFightList()
        {
            List<FightModel> Fights = new List<FightModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Fight");

                if (response.IsSuccessStatusCode)
                {
                    string temp = await response.Content.ReadAsStringAsync();
                    Fights = JsonConvert.DeserializeObject<List<FightModel>>(temp);

                    foreach (FightModel fm in Fights)
                    {
                        fm.AttArmy_obj = await GetHouse(fm.AttArmy);
                        if (fm.DefArmy > 0)
                            fm.DefArmy_obj = await GetHouse(fm.DefArmy);
                        else if (fm.DefArmy < 0)
                            fm.DefArmy_obj = await GetWhiteWalker(fm.DefArmy);

                        if (fm.WinningArmy > 0)
                            fm.WinningArmy_obj = await GetHouse(fm.WinningArmy);
                        else if (fm.WinningArmy < 0)
                            fm.WinningArmy_obj = await GetWhiteWalker(fm.WinningArmy);
                    }
                }
            }
            return Fights;
        }

        private async void RefreshHouse_Click(object sender, RoutedEventArgs e)
        {
            houseList.ItemsSource = await getHouseList();
        }
        private async void RefreshWW_Click(object sender, RoutedEventArgs e)
        {
            wwList.ItemsSource = await getWhiteWalkerList();
        }
        private async void RefreshFight_Click(object sender, RoutedEventArgs e)
        {
            fightList.ItemsSource = await getFightList();
        }
        private void listViewItem_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            WhiteWalkerModel ww = ((ListViewItem)sender).Content as WhiteWalkerModel;
            new WWEdit(ww).ShowDialog();
        }
    }
}
