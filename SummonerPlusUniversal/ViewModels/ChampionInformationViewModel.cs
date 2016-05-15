using Newtonsoft.Json;
using SummonerPlusUniversal.Classes;
using SummonerPlusUniversal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.ViewModels
{
    public class ChampionInformationViewModel
    {
        public ChampionInformationViewModel(long championID)
        {
            selectedChampion = GetChampionInformation(championID);
        }

        private Champion selectedChampion;
        
        public Champion Champion
        {
            get { return selectedChampion; }
        }

        public Champion GetChampionInformation(long championID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://summonerapi.azurewebsites.net");
                HttpResponseMessage response = client.GetAsync("/api/Champion/" + championID).Result;
                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Champion champ = JsonConvert.DeserializeObject<Champion>(json);
                    
                    return champ;
                }
                else
                {
                    return new Champion();
                }
            }
        }
    }
}
