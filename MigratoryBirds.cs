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

    // Complete the migratoryBirds function below.
    static int migratoryBirds(List<int> arr) {
        int mostCommon = arr[ 0 ];
        int highestCount = 0;
        Dictionary<int, int> countByBirdTypeMap = new Dictionary<int, int>();
        for( int i = 0; i < arr.Count; i++ ) {
            int birdType = arr[ i ];

            if( ! countByBirdTypeMap.ContainsKey( birdType ) ) {
                countByBirdTypeMap.Add( birdType, 0 );
            }
            countByBirdTypeMap[ birdType ] = countByBirdTypeMap[ birdType ] + 1;
            if( countByBirdTypeMap[ birdType ] > highestCount ) {
                highestCount = countByBirdTypeMap[ birdType ];
                mostCommon = birdType;
            } else if( countByBirdTypeMap[ birdType ] == highestCount ) {
                if( mostCommon > birdType ) {
                    mostCommon = birdType;
                }
            }
        }
/*
        foreach( KeyValuePair<int, int> birdTypeCountPair in countByBirdTypeMap ) {
            if( birdTypeCountPair.Value > highestCount ) {
                highestCount = birdTypeCountPair.Value;
                mostCommon = birdTypeCountPair.Key;
            } else if( birdTypeCountPair.Value == highestCount ) {
                if( mostCommon > birdTypeCountPair.Key ) {
                    mostCommon = birdTypeCountPair.Key;
                }
            }
        }
*/
        return mostCommon;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
