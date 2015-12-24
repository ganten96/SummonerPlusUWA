using SummonerPlusUniversal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummonerPlusUniversal.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private ViewModelBase currentViewModel;

        public MainPageViewModel()
        {
            //this.LoadChampionGrid();
        }

        public ViewModelBase CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
            }
        }

        private void LoadChampionGrid()
        {
            CurrentViewModel = new ChampionGridViewModel();
        }
    }
}
