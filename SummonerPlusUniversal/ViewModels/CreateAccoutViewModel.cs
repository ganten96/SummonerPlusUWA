using Newtonsoft.Json;
using SummonerPlusUniversal.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace SummonerPlusUniversal.ViewModels
{
    public class CreateAccoutViewModel : ViewModelBase<LeagueUser>
    {
        public async Task<bool> CreateAccount(LeagueUser user)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Uri url = new Uri("https://summonerapi.azurewebsites.net/api/account/create/");
                    string json = JsonConvert.SerializeObject(user);
                    HttpResponseMessage msg = await client.PostAsync(url, new HttpStringContent(json));
                    if (msg.IsSuccessStatusCode)
                    {
                        string result = await msg.Content.ReadAsStringAsync();
                        var isMade = JsonConvert.DeserializeObject<bool>(result);
                       
                        return isMade;
                    }
                    if (msg.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return false;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
