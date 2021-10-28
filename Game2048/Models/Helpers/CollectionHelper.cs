using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2048.Models.Helpers
{
    internal static class CollectionHelper
    {
        public static List<T> GetRowFromArray2Dim<T>(T[,]array, int row)
        {
            var list = new List<T>();
            for (int i = 0; i <= array.GetUpperBound(1); i++)
                list.Add(array[row, i]);
            return list;
        }

        public static List<T> GetColumnFromArray2Dim<T>(T[,] array, int column)
        {
            var list = new List<T>();
            for (int i = 0; i <= array.GetUpperBound(0); i++)
                list.Add(array[i, column]);
            return list;
        }

        public static bool CompareLists(List<int> First, List<int> Second)
        {
            if (First.Count != Second.Count) return false;
            for (int i = 0; i < First.Count; i++)
            {
                if (First[i] != Second[i]) return false;
            }
            return true;
        }

        public static void ListOfListToArray2Dim<T>(T[,] array, List<List<T>> list, bool byRow)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 0; j < list.Count; j++)
                {
                    if (byRow) array[i, j] = list[i][j];
                    else array[j, i] = list[i][j];
                }
            }
        }
    }
}
