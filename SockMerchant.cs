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

    // Complete the sockMerchant function below.
    static int sockMerchant(int n, int[] ar) {
        Dictionary<int, int> sockCountMap = new Dictionary<int, int>();
        for( int i = 0; i < ar.Length; i++ ) {
            int sock = ar[ i ];
            if( ! sockCountMap.ContainsKey( sock ) ) {
                sockCountMap.Add( sock, 0 );
            }
            sockCountMap[ sock ] = sockCountMap[ sock ] + 1;
        }

        int pairCount = 0;
        foreach( KeyValuePair<int, int> kvp in sockCountMap ) {
            int nbrSocks = sockCountMap[ kvp.Key ];
            int nbrPairs = nbrSocks / 2;
            if( nbrPairs > 0 ) {
                pairCount += nbrPairs;
            }
        }

        return pairCount;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
        ;
        int result = sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
