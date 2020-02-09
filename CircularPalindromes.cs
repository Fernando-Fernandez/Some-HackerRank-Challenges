using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

class Solution {
    static int?[] cachedSizes;
    static int getPalindromeSizeFromPosition( string s, int centerPosition ) {
        /*
        int? cachedSize = cachedSizes[ centerPosition + 1 ];
        if( cachedSize != null ) {
            Console.WriteLine( "{2}: returning cached size {0} for position {1}"
                            , cachedSize, centerPosition, s );
            int size = cachedSize ?? default( int );
            return size;
        }
        */

        //Console.WriteLine( "{0} {1}", s, centerPosition );
        int i = 0, lastFoundPalindromeSize = 0;
        int leftIndex = centerPosition, rightIndex = centerPosition + 1;
        Boolean evenPatternBroken = false, oddPatternBroken = false;
        while( leftIndex > -1 && rightIndex < sLength ) {
            char rightCharacter = s[ rightIndex ];
            int size = ( i + 1 ) * 2;

            if( evenPatternBroken == false ) {
                if( s[ leftIndex ] == rightCharacter ) {
                    lastFoundPalindromeSize = size;
                } else {
                    evenPatternBroken = true;
                }
            }
            if( oddPatternBroken == false ) {
                if( leftIndex > 0 && s[ leftIndex - 1 ] == rightCharacter ) {
                    lastFoundPalindromeSize = size + 1;
                } else {
                    oddPatternBroken = true;
                }
            }
            if( evenPatternBroken && oddPatternBroken ) {
                break;
            }

            i++;
            leftIndex--;
            rightIndex++;
        }

        //Console.WriteLine( "{0}: size {1} for position {2}"
        //                , s, lastFoundPalindromeSize, centerPosition );

        //cachedSizes[ centerPosition ] = lastFoundPalindromeSize;

        return lastFoundPalindromeSize;
    }

    static int getMaxPalindromeSize( string s ) {
        //Console.WriteLine( s );
        
        int maxSize = 0;
        // measure palindromes centered from 1 to length - 1
        for( int centerPosition = 1; centerPosition < sLength - 1; centerPosition++ ) {
            // measure palindrome centered on centerPosition
            int size = getPalindromeSizeFromPosition( 
                                    s, centerPosition );
            if( maxSize < size ) {
                maxSize = size;
            }
        }

        return maxSize;
    }

    /*
     * Complete the circularPalindromes function below.
     */
    static string circularS;
    static int sLength;
    static int[] circularPalindromes(string s) {
        /*
         * Write your code here.
         */

        sLength = s.Length;

        int[] palindromeCount = new int[ sLength ];

        // create static circular buffer to avoid building rotated strings
        circularS = s + s;

        cachedSizes = new int?[ sLength ];

Stopwatch sw = Stopwatch.StartNew();

        for( int mainStringStart = 0; mainStringStart < sLength; mainStringStart++ ) {
            palindromeCount[ mainStringStart ] = getMaxPalindromeSize( 
                    circularS.Substring( mainStringStart, sLength ) );

        }

sw.Stop();
Console.WriteLine("Time taken: {0}ms", sw.Elapsed.TotalMilliseconds);

        return palindromeCount;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        string s = Console.ReadLine();

        int[] result = circularPalindromes(s);

        textWriter.WriteLine(string.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
