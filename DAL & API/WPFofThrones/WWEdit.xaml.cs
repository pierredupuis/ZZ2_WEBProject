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
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPFofThrones.Models;



namespace WPFofThrones
{
    /// <summary>
    /// Logique d'interaction pour WWEdit.xaml
    /// </summary>
    public partial class WWEdit : Window
    {
        WhiteWalkerModel wwm;
        public WWEdit(WhiteWalkerModel wwm)
        {
            InitializeComponent();
            this.wwm = wwm;
        }
        public void ConfirmEdit(object sender, RoutedEventArgs e)
        {
            wwm.NumberOfUnits = Convert.ToInt32(NumberTextBox.Text);
            Edit(wwm);
            this.Close();
        }


        public async void Edit(WhiteWalkerModel wwm)
        {
            try
            {
                using (var client = new HttpClient())
                {

                    client.BaseAddress = new Uri("http://localhost:" + Globals.api_port + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage res = await client.PutAsJsonAsync("api/WhiteWalker/" + wwm.Id + "/", wwm);
                    if (!res.IsSuccessStatusCode)
                    {
                        throw new Exception("Error : " + res.StatusCode);
                    }

                }
            }
            catch
            {
               // Good luck :)
            }
        }
    }
}
