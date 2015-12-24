using Newtonsoft.Json;
using SummonerPlusUniversal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.Classes
{
    public class Champion
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

        public string NameAndTitle { get { return ChampionName + ", " + Title; } }

        public string SplashImageUrl { get { return @"http://ddragon.leagueoflegends.com/cdn/img/champion/splash/" + ChampionName + "_0.jpg"; } }

        public string ImageUrl { get { return @"http://ddragon.leagueoflegends.com/cdn/5.20.1/img/champion/" + Key + ".png"; } }

        [JsonProperty(PropertyName = "stats")]
        public ChampionStats ChampionStats { get; set; }
    }
}
