using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.ViewModels
{
    public class ChampionViewModel
    {
        [JsonProperty(PropertyName = "id")]
        public long ChampionID { get; set; }

        [JsonProperty(PropertyName = "key")]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string ChampionName { get; set; }

        [JsonProperty(PropertyName = "freeToPlay")]
        public bool FreeToPlay { get; set; }

        [JsonProperty(PropertyName = "rankedPlayEnabled")]
        public bool RankedPlayEnabled { get; set; }

        [JsonProperty(PropertyName = "blurb")]
        public string Blurb { get; set; }

        [JsonProperty(PropertyName = "enemytips")]
        public List<string> EnemyTips { get; set; }

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public string ImageUrl { get { return @"http://ddragon.leagueoflegends.com/cdn/5.20.1/img/champion/" + Key + ".png"; } }

        public List<ChampionViewModel> Champions { get; set; }
        //[JsonProperty(PropertyName = "info")]
        //public ChampionInfo Info { get; set; }
    }
}
/*

*/
