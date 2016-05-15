using Newtonsoft.Json;
using SummonerPlusUniversal.Classes;
using System;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
namespace SummonerPlusUniversal.ViewModels
{
    public class LogInViewModel : ViewModelBase<LeagueUser>
    {
        private async Task<LeagueUser> verifySummonerName(string username)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    Uri url = new Uri("https://summonerapi.azurewebsites.net/api/Account/verify/" + username);
                    HttpResponseMessage msg = await client.GetAsync(url);
                    if (msg.IsSuccessStatusCode)
                    {
                        string result = await msg.Content.ReadAsStringAsync();
                        var user = JsonConvert.DeserializeObject<LeagueUser>(result);

                        return user;
                    }
                    if (msg.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return null;
                    }
                    return null;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> LogIn(string username, string password)
        {
            try
            {
                var summoner = verifySummonerName(username).GetAwaiter().GetResult();
                bool isVerified = summoner != null;
                if(!isVerified)
                {
                    return false;
                }

                LeagueUser user = new LeagueUser
                {
                    SummonerName = username,
                    Password = password
                };

                using (var client = new HttpClient())
                {
                    Uri url = new Uri("https://summonerapi.azurewebsites.net/api/Account/LogIn");
                    string json = JsonConvert.SerializeObject(user);
                    HttpResponseMessage msg = await client.PostAsync(url, new HttpStringContent(json));
                    if (msg.IsSuccessStatusCode)
                    {
                        string result = await msg.Content.ReadAsStringAsync();
                        bool isAuthenticated;
                        bool.TryParse(result, out isAuthenticated);

                        return isAuthenticated;
                    }
                    if (msg.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        return false;
                    }
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
