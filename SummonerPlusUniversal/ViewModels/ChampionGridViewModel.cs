using Newtonsoft.Json;
using SummonerPlusUniversal.Classes;
using SummonerPlusUniversal.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.Web.Http;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.ViewModels
{
    public class ChampionGridViewModel : ViewModelBase<ObservableCollection<Champion>>
    {
        public ChampionGridViewModel()
        {
            champions = GetChampionsAsync().GetAwaiter().GetResult();
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
                champions = this.GetChampionsAsync().GetAwaiter().GetResult();
                this.OnPropertyChanged("Champions");
            }
        }

        public async Task<ObservableCollection<Champion>> GetChampionsAsync()
        {
            using (var client = new HttpClient())
            {
                Uri uri = new Uri("https://summonerapi.azurewebsites.net");
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

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
