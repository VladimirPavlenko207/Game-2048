using Game2048.Infrastructure.Commands;
using Game2048.Models;
using Game2048.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game2048.ViewModels
{
    internal class GameViewModel : ViewModel
    {
        #region TileViewModel fields and Properties

        private TileViewModel tile00;
        private TileViewModel tile01;
        private TileViewModel tile02;
        private TileViewModel tile03;
        private TileViewModel tile10;
        private TileViewModel tile11;
        private TileViewModel tile12;
        private TileViewModel tile13;
        private TileViewModel tile20;
        private TileViewModel tile21;
        private TileViewModel tile22;
        private TileViewModel tile23;
        private TileViewModel tile30;
        private TileViewModel tile31;
        private TileViewModel tile32;
        private TileViewModel tile33;

        public TileViewModel Tile00
        {
            get => tile00;
            set => Set(ref tile00, value);
        }
        public TileViewModel Tile01
        {
            get => tile01;
            set => Set(ref tile01, value);
        }
        public TileViewModel Tile02
        {
            get => tile02;
            set => Set(ref tile02, value);
        }
        public TileViewModel Tile03
        {
            get => tile03;
            set => Set(ref tile03, value);
        }
        //----------------------------------------
        public TileViewModel Tile10
        {
            get => tile10;
            set => Set(ref tile10, value);
        }
        public TileViewModel Tile11
        {
            get => tile11;
            set => Set(ref tile11, value);
        }
        public TileViewModel Tile12
        {
            get => tile12;
            set => Set(ref tile12, value);
        }
        public TileViewModel Tile13
        {
            get => tile13;
            set => Set(ref tile13, value);
        }
        //-----------------------------------
        public TileViewModel Tile20
        {
            get => tile20;
            set => Set(ref tile20, value);
        }
        public TileViewModel Tile21
        {
            get => tile21;
            set => Set(ref tile21, value);
        }
        public TileViewModel Tile22
        {
            get => tile22;
            set => Set(ref tile22, value);
        }
        public TileViewModel Tile23
        {
            get => tile23;
            set => Set(ref tile23, value);
        }
        //-----------------------------------------
        public TileViewModel Tile30
        {
            get => tile30;
            set => Set(ref tile30, value);
        }
        public TileViewModel Tile31
        {
            get => tile31;
            set => Set(ref tile31, value);
        }
        public TileViewModel Tile32
        {
            get => tile32;
            set => Set(ref tile32, value);
        }
        public TileViewModel Tile33
        {
            get => tile33;
            set => Set(ref tile33, value);
        }
        #endregion

        #region ScoreboardViewModel fields and Properties
        private ScoreboardViewModel score;
        private ScoreboardViewModel highScore;

        public ScoreboardViewModel Score
        {
            get => score;
            set => Set(ref score, value);
        }

        public ScoreboardViewModel HighScore
        {
            get => highScore;
            set => Set(ref highScore, value);
        }
        #endregion

        public TilesModel TilesModel { get; } = new();

        #region Commands
        public ICommand MoveLeftCommand { get; }
        private bool CanMoveLeftCommandExequte(object p) => true;
        private void OnMoveLeftCommandExequted(object p)
        {
            TilesModel.RowsMoveLeft();
            Update();
        }
        //-------------------------------------------------
        public ICommand MoveRightCommand { get; }
        private bool CanMoveRightCommandExequte(object p) => true;
        private void OnMoveRightCommandExequted(object p)
        {
            TilesModel.RowsMoveRight();
            Update();
        }
        //------------------------------------------------------
        public ICommand MoveUpCommand { get; }
        private bool CanMoveUpCommandExequte(object p) => true;
        private void OnMoveUpCommandExequted(object p) 
        {
            TilesModel.ColumnsMoveUp();
            Update();
        }
        //----------------------------------------------------
        public ICommand MoveDownCommand { get; }
        private bool CanMoveDownCommandExequte(object p) => true;
        private void OnMoveDownCommandExequted(object p) 
        {
            TilesModel.ColumnsMoveDown();
            Update();
        }
        #endregion

        public GameViewModel()
        {
            #region InitCommands
            MoveLeftCommand = new RelayCommand(OnMoveLeftCommandExequted, CanMoveLeftCommandExequte);
            MoveRightCommand = new RelayCommand(OnMoveRightCommandExequted, CanMoveRightCommandExequte);
            MoveUpCommand = new RelayCommand(OnMoveUpCommandExequted, CanMoveUpCommandExequte);
            MoveDownCommand = new RelayCommand(OnMoveDownCommandExequted, CanMoveDownCommandExequte);
            #endregion

            InitTiles();
            InitScoreboards();
            Update();
            TilesModel.GemeOverEvent += GameOver;
        }

        private void GameOver(int score, bool res)
        {
            Update();
            HighScore.Score = TilesModel.HighScore;
            string message = res ? $"Congratulations! You won with the score {score}!" 
                : $"Dont be upset! Try again.\n Your score {score}.";
            MessageBox.Show(message, "Game Over!", MessageBoxButton.OK, MessageBoxImage.Information);
            TilesModel.NewGame();
        }

        private void InitScoreboards()
        {
            Score = new ScoreboardViewModel() { Title = "Score" };
            HighScore = new ScoreboardViewModel() { Title = "High Score" };
        }

        private void InitTiles()
        {
            Tile00 = new TileViewModel();
            Tile01 = new TileViewModel();
            Tile02 = new TileViewModel();
            Tile03 = new TileViewModel();

            Tile10 = new TileViewModel();
            Tile11 = new TileViewModel();
            Tile12 = new TileViewModel();
            Tile13 = new TileViewModel();

            Tile20 = new TileViewModel();
            Tile21 = new TileViewModel();
            Tile22 = new TileViewModel();
            Tile23 = new TileViewModel();

            Tile30 = new TileViewModel();
            Tile31 = new TileViewModel();
            Tile32 = new TileViewModel();
            Tile33 = new TileViewModel();
        }

        private void Update()
        {
            Tile00.ValueStr = TilesModel[0, 0].ToString();
            Tile01.ValueStr = TilesModel[0, 1].ToString();
            Tile02.ValueStr = TilesModel[0, 2].ToString();
            Tile03.ValueStr = TilesModel[0, 3].ToString();

            Tile10.ValueStr = TilesModel[1, 0].ToString();
            Tile11.ValueStr = TilesModel[1, 1].ToString();
            Tile12.ValueStr = TilesModel[1, 2].ToString();
            Tile13.ValueStr = TilesModel[1, 3].ToString();

            Tile20.ValueStr = TilesModel[2, 0].ToString();
            Tile21.ValueStr = TilesModel[2, 1].ToString();
            Tile22.ValueStr = TilesModel[2, 2].ToString();
            Tile23.ValueStr = TilesModel[2, 3].ToString();

            Tile30.ValueStr = TilesModel[3, 0].ToString();
            Tile31.ValueStr = TilesModel[3, 1].ToString();
            Tile32.ValueStr = TilesModel[3, 2].ToString();
            Tile33.ValueStr = TilesModel[3, 3].ToString();

            Score.Score = TilesModel.Score;
        }
    }
}
