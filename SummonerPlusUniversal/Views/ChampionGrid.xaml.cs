using SummonerPlusUniversal.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using Windows.Data.Json;
using Newtonsoft.Json;
using System.Linq;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SummonerPlusUniversal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChampionGrid : Page
    {
        private ChampionViewModel model;
        public ChampionGrid()
        {
            model = new ChampionViewModel
            {
                Champions = getChampionsAsync().Select(x => x.Value).ToList()
            };

            this.DataContext = model;
            this.InitializeComponent();
        }


        private Dictionary<string, ChampionViewModel> getChampionsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://summonerapi.azurewebsites.net");
                HttpResponseMessage response = client.GetAsync("/api/Champion/").Result;
                if(response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Dictionary<string, ChampionViewModel> champDict = JsonConvert.DeserializeObject<Dictionary<string, ChampionViewModel>>(json);
                    return champDict;
                }
                else
                {
                    return new Dictionary<string, ChampionViewModel>();
                }
            }
        }

        private void Champion_Click(object sender, ItemClickEventArgs e)
        {
            ChampionViewModel champion = (ChampionViewModel)e.ClickedItem;
            //if()
            //get champion information, make new view that contains champion info, initialize the component here.


        }
    }
}
