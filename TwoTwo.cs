// https://www.hackerrank.com/challenges/two-two/problem?utm_campaign=challenge-recommendation&utm_medium=email&utm_source=24-hour-campaign
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

class Solution {

    /*
     * Complete the twoTwo function below.
     */
    static int twoTwo(string a) {
        /*
         * Write your code here.
         */
        Dictionary<char, List<string>> powersOf2Map = 
                                new Dictionary<char, List<string>>();
//        string[] powersOf2 = new string[ 800 ];
        BigInteger b = 1;
        for( int i = 0; i < 800; i++ ) {
            string powerOf2 = b.ToString();
/*
            // solution #1: simple array to check all 800 numbers
            powersOf2[ i ] = powerOf2;
*/
/*
            // solution #2: map indexed by first digit
            List<string> nbrList = powersOf2Map.ContainsKey( powerOf2[ 0 ] ) ?
                            powersOf2Map[ powerOf2[ 0 ] ]
                            : new List<string>();
            nbrList.Add( powerOf2 );
            powersOf2Map[ powerOf2[ 0 ] ] = nbrList;
*/
            // solution #3: map indexed by last digit
            int lastDigit = powerOf2.Length - 1;
            List<string> nbrList = powersOf2Map.ContainsKey( powerOf2[ lastDigit ] ) ?
                            powersOf2Map[ powerOf2[ lastDigit ] ]
                            : new List<string>();
            nbrList.Add( powerOf2 );
            powersOf2Map[ powerOf2[ lastDigit ] ] = nbrList;

            b = b << 1;
        }
//Console.WriteLine( powersOf2Map[ '0' ][ 10 ].ToString() );
        int count = 0;
/*
        // solution #1: this loop checks all 800 numbers to count 
        // how many times they're contained in the a string
        for( int i = 0; i < powersOf2.Length; i++ ) {
            int pos = a.IndexOf( powersOf2[ i ] );
            while( pos >= 0 ) {
                count++;
                pos = a.IndexOf( powersOf2[ i ], pos + 1 );
            }
        }
*/
/*
        // solution #2: this loop does the reverse of the previous loop
        // and checks each character in the string to see if it could be
        // one of the 800 numbers
        for( int i = 0; i < a.Length; i++ ) {
            List<string> nbrList = powersOf2Map.ContainsKey( a[ i ] ) ?
                                    powersOf2Map[ a[ i ] ]
                                    : null;
            if( nbrList == null ) {
                continue;
            }

            for( int j = 0; j < nbrList.Count; j++ ) {
                // stop checking if nbr is bigger than the remaining string a
                if( nbrList[ j ].Length > a.Length - i ) {
                    break;
                }
                if( nbrList[ j ] == a.Substring( i, nbrList[ j ].Length ) ) {
                    count++;
                }
            }
        }
*/

        // solution #3: this loop does the reverse of the previous loop
        // and checks each character in the string to see if it could be
        // one of the 800 numbers, but in the reverse order using last digit
        for( int i = a.Length - 1; i >= 0; i-- ) {
            List<string> nbrList = powersOf2Map.ContainsKey( a[ i ] ) ?
                                    powersOf2Map[ a[ i ] ]
                                    : null;
            if( nbrList == null ) {
                continue;
            }

            for( int j = 0; j < nbrList.Count; j++ ) {
                // stop checking if nbr is bigger than the remaining string a
                if( nbrList[ j ].Length > i + 1 ) {
                    break;
                }
                
                if( nbrList[ j ] == a.Substring( i - nbrList[ j ].Length + 1
                                                , nbrList[ j ].Length ) ) {
                    count++;
                }
            }
        }
        return count;

    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine());

        for (int tItr = 0; tItr < t; tItr++) {
            string a = Console.ReadLine();

            int result = twoTwo(a);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
