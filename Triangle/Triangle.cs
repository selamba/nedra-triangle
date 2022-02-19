using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Triangle
{
    public class Triangle
    {
         private readonly IList<IList<int>> _numberRows;

         public Triangle(int height)
         {
             _numberRows = new List<IList<int>>(height);
             for (var row = 0; row < height; ++row)
             {
                 _numberRows.Add(new List<int>(row + 1));
                 FillICollectionWithRandomNumbers(_numberRows[row], row + 1);
             }
         }

         public int HighestSum()
         {
             var highestSum = 0;
             Traverse(0, 0, 0, ref highestSum);
             return highestSum;
         }

         private void Traverse(int accumulatedSum, int row, int index, ref int highestSum)
         {
             while (true)
             {
                 var currentValue = _numberRows[row][index];
                 if (row == _numberRows.Count - 1) // Bottom of triangle - end of summation
                 {
                     var currentSum = accumulatedSum + currentValue;
                     if (currentSum > highestSum)
                     {
                         highestSum = currentSum;
                     }

                     return;
                 }

                 // Left
                 Traverse(accumulatedSum + currentValue, row + 1, index, ref highestSum);
                 // Right
                 accumulatedSum = accumulatedSum + currentValue;
                 row = row + 1;
                 index = index + 1;
             }
         }

         public override string ToString()
         {
             var sb = new StringBuilder(_numberRows.Count * _numberRows.Count + 1);

             for (var i = 0; i < _numberRows.Count; ++i)
             {
                AppendSpacesToStringBuilder(ref sb, _numberRows.Count-i-1);
                sb.Append(IListToString(_numberRows[i]));
                AppendSpacesToStringBuilder(ref sb, _numberRows.Count-i-1);
                sb.Append('\n');
             }

             return sb.ToString();
         }
         
         private static void FillICollectionWithRandomNumbers(ICollection<int> ilist, int size) {
             var rnd = new Random();
             for (var i = 0; i < size; ++i)
             {
                 ilist.Add(rnd.Next(10));
             }
         }

         private static void AppendSpacesToStringBuilder(ref StringBuilder sb, int count)
         {
             for (var i = 0; i < count; ++i)
             {
                 sb.Append(' ');
             }
         }

         private static string IListToString(IList<int> ilist)
         {
             var sb = new StringBuilder();

             for (var i = 0; i < ilist.Count; ++i)
             {
                 if (i != 0)
                 {
                     sb.Append(' ');
                 }
                 sb.Append(ilist[i]);
             }

             return sb.ToString();
         }
    }
}