using Game2048.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game2048.Models
{
    internal struct MyPoint
    {
        public int _x;
        public int _y;
        public MyPoint(int x, int y)
        {
            _x = x;
            _y = y;
        }
    }
    internal class TilesModel
    {
        private readonly int size = 4;
        private readonly int finishNum = 2048;
        private Random random = new();
        private int[,] tiles;

        public int[,] Tiles { get => tiles; }
        public int Score { get; set; }
        public int HighScore { get; set; }
        public event Action<int, bool> GemeOverEvent;

        public TilesModel()
        {
            NewGame();
        }

        public int this[int x, int y]
        {
            get => Tiles[x, y];
            set => Tiles[x, y] = value;
        }
       
        public void NewGame()
        {
            tiles = new int[size, size];
            Score = 0;
            AddNewNum();
        }

        private void AddNewNum()
        {
            var num = AddRandomNum();
            if (!InputNumInFreeTile(num)) GameOver(false);
        }

        private bool InputNumInFreeTile(int num)
        {
            var col = new List<MyPoint>();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (tiles[i, j] == 0)
                    {
                        col.Add(new MyPoint(i, j));
                    }
                }
            }
            if (col.Count == 0) return false;

            MixTiles(col);
            tiles[col[0]._x, col[0]._y] = num;
            return true;
        }

        private void MixTiles(List<MyPoint> col)
        {
            for (int i = 0; i < col.Count; i++)
            {
                var count = col.Count;
                var j = random.Next(count);
                var tmp = col[i];
                col[i] = col[j];
                col[j] = tmp;
            }
        }

        private int AddRandomNum()
        {
            return random.Next(10) == 0 ? 4 : 2;
        }

        public void RowsMoveRight()
        {
            CellShift(true, true);
        }

        public void RowsMoveLeft()
        {
            CellShift(false, true);
        }
         
        public void ColumnsMoveUp()
        {
            CellShift(false, false);
        }

        public void ColumnsMoveDown()
        {
            CellShift(true, false);
        }

        private void CellShift(bool withReverse, bool isRow)
        {
            var Lists = new List<List<int>>();
            for (int i = 0; i < size; i++)
            {
                List<int> list;
                if (isRow) list = CollectionHelper.GetRowFromArray2Dim(Tiles, i);
                else list = CollectionHelper.GetColumnFromArray2Dim(Tiles, i);

                if (withReverse) list.Reverse();

                MoveNums(list);
                Lists.Add(list);
            }
            if (withReverse)
            {
                foreach (var item in Lists)
                {
                    item.Reverse();
                }
            }
            CollectionHelper.ListOfListToArray2Dim(Tiles, Lists, isRow);
            AddNewNum();
            
        }

        private void GameOver(bool isFinishNum)
        {
            if (Score > HighScore) HighScore = Score;
            GemeOverEvent?.Invoke(Score, isFinishNum);
        }

        private void MoveNums(List<int> list)
        {
            var isListChanged = true;
            while (isListChanged)
            {
                isListChanged = ToShiftNums(list);
                isListChanged = AddIfTheSameNums(list);
            }

        }

        private bool AddIfTheSameNums(List<int> list)
        {
            if (!list.Exists((e) => e > 0)) return false;
            for (int i = 0; i < list.Count - 1; i++) 
            {
                if (list[i] == 0) continue;

                if (list[i] == list[i + 1])
                {
                    list[i] += list[i + 1];
                    if (list[i] == finishNum) GameOver(true);
                    
                    list[i + 1] = 0;
                    Score += list[i];
                    return true;
                }
            }
            return false;
        }

        private bool ToShiftNums(List<int> list)
        {
            if (list.Exists((e) => e > 0) && list.Exists((e) => e == 0))
            {
                bool isChenged = true;
                while(isChenged)
                {
                    var zeroIndex = list.FindIndex((e) => e == 0);
                    var notZeroIndex = list.FindLastIndex((e) => e > 0);
                    if (zeroIndex < notZeroIndex)
                    {
                        isChenged = true;
                        list.RemoveAt(zeroIndex);
                        list.Add(0);
                    }
                    else isChenged = false;
                }
                return true;
            }
            else return false;
        }

       
    }
}
