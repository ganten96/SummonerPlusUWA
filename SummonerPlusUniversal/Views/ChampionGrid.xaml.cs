using SummonerPlusUniversal.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using System.Net.Http;
using Windows.Data.Json;
using Newtonsoft.Json;
using System.Linq;
using Windows.UI.Xaml;
using SummonerPlusUniversal.Classes;
using System.Collections.ObjectModel;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SummonerPlusUniversal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ChampionGrid : Page
    {
        public ChampionGrid()
        {
            this.InitializeComponent();
            this.DataContext = new ChampionGridViewModel();
        }

        private void Champion_Click(object sender, ItemClickEventArgs e)
        {
            Champion champion = (Champion)e.ClickedItem;
            ChampionInformation champInfo = new ChampionInformation(champion.ChampionID);
            this.Content = champInfo;
        }
    }
}
