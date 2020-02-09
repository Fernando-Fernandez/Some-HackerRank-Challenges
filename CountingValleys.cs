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

    // Complete the countingValleys function below.
    static int countingValleys(int n, string s) {
        char[] charAr = s.ToCharArray();

        Dictionary<char, int> upDownMap = new Dictionary<char, int> () {
            { 'U', 1 }
            , { 'D', -1 }
        };

        int currentLevel = 0;
        int valleyCount = 0;
        Boolean inValley = false;
        for( int i = 0; i < charAr.Length; i++ ) {
            int direction = upDownMap[ charAr[ i ] ];

            // if at sea level, check direction
            if( currentLevel == 0 ) {
                // if going up, no longer in valley
                // if going down, entering valley
                inValley = ( direction == -1 );

                // count a valley
                if( inValley ) {
                    valleyCount++;
                }
            }

            currentLevel = currentLevel + direction;
        }

        return valleyCount;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int result = countingValleys(n, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
