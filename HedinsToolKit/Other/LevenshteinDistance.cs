using System;
using System.Collections.Generic;
using System.Text;

namespace HedinsToolKit.Other
{
    public static class LevenshteinDistance
    {
        /// <summary>
        ///  Levenshtein distance is a string metric for measuring the difference between two sequences. 
        /// Informally, the Levenshtein distance between two words is the minimum number of 
        /// single-character edits (insertions, deletions or substitutions) required to change one word into the other.
        /// </summary>
        /// <param name="first">First string</param>
        /// <param name="second">Secons string</param>
        /// <returns></returns>
        private static int Compare(string first, string second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));
            if (second == null) throw new ArgumentNullException(nameof(second));

            var resultMatrix = new int[first.Length + 1, second.Length + 1];

            for (var i = 0; i <= first.Length; i++)
                resultMatrix[i, 0] = i;

            for (var j = 0; j <= second.Length; j++)
                resultMatrix[0, j] = j;

            for (var i = 1; i <= first.Length; i++)
            {
                for (var j = 1; j <= second.Length; j++)
                {
                    var diff = (first[i - 1] == second[j - 1]) ? 0 : 1;

                    var temp = Math.Min(
                        Math.Min(
                            resultMatrix[i - 1, j] + 1,
                            resultMatrix[i, j - 1] + 1),
                        resultMatrix[i - 1, j - 1] + diff
                    );

                    resultMatrix[i, j] = temp;

                }
            }

            return resultMatrix[first.Length, second.Length];
        }

     

       
    }
}
