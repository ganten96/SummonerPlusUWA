using Newtonsoft.Json;
using SummonerPlusUniversal.Classes;
using SummonerPlusUniversal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.ViewModels
{
    public class ChampionGridViewModel : ViewModelBase
    {
        public ChampionGridViewModel()
        {
            champions = GetChampionsAsync();
        }

        private ObservableCollection<Champion> champions;

        public ObservableCollection<Champion> Champions
        {
            get
            {
                return champions;
            }
            set
            {
                champions = this.GetChampionsAsync();
                this.OnPropertyChanged("Champions");
            }
        }

        public ObservableCollection<Champion> GetChampionsAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://summonerapi.azurewebsites.net");
                HttpResponseMessage response =  client.GetAsync("/api/Champion/").Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Dictionary<string, Champion> champDict = JsonConvert.DeserializeObject<Dictionary<string, Champion>>(json);

                    List<Champion> list = champDict.Values.ToList();
                    ObservableCollection<Champion> champs = new ObservableCollection<Champion>(list);
                    return champs;
                }
                else
                {
                    return new ObservableCollection<Champion>();
                }
            }
        }
    }
}
