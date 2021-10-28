using Game2048.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.ViewModels
{
    internal class ScoreboardViewModel : ViewModel
    {
        private string title;
        private int score;
        public string Title
        {
            get => title;
            set => Set(ref title, value);
        }

        public int Score
        {
            get => score;
            set => Set(ref score, value);
        }
    }
}
