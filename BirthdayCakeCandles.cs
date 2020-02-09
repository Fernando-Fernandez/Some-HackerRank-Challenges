using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {

    // Complete the birthdayCakeCandles function below.
    static int birthdayCakeCandles(int[] ar) {
        Dictionary<int, int> countDict = new Dictionary<int, int>();
        for( int index = 0; index < ar.Length; index++ ) {
            int height = ar[ index ];

            if( ! countDict.ContainsKey( height ) ) {
                countDict.Add( height, 0 );
            }
            countDict[ height ] = countDict[ height ] + 1;
        }

        int maxCount = -9999;
        foreach( KeyValuePair<int, int> item in countDict ) {
            if( item.Value > maxCount ) {
                maxCount = item.Value;
            }
        }

        return maxCount;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arCount = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
        ;
        int result = birthdayCakeCandles(ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
