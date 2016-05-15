using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.Classes
{
    public class LeagueUser
    {
        public string SummonerName { get; set; }
        
        public long SummonerID { get; set; }

        //comes in hashed.
        public string Password { get; set; }

        public bool IsAuthenicated { get; }

        public string Token { get; set; }
        
        public int ProfileIconID { get; set; }
        
        public long SummonerLevel { get; set; }

        public string ProfileIconURL { get { return "http://ddragon.leagueoflegends.com/cdn/5.24.2/img/profileicon/" + ProfileIconID; } }
    }
}
