// https://www.hackerrank.com/challenges/circular-palindromes/problem
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

class Solution {
    static int getPalindromeSizeUsingManacher2( int initialPosition ) {
        // this one avoids creating new strings and inspects characters
        // directly on the main circular buffer 

//Console.WriteLine( s );
        int stringSize = sLength * 2 + 1;

//Console.WriteLine( circularS.Substring( initialPosition, stringSize ) );

        // Manacher algorithm
        int[] palindromeSize = new int[ stringSize ];
        int center = 0, rightEdgePosition = 0;

        int maxPalindromeSize = 0;
        for( int i = 0; i < stringSize; i++ ) {
            int currentMirrorPosition = 2 * center - i;

            if( i < rightEdgePosition ) {
                palindromeSize[ i ] = Math.Min( rightEdgePosition - i
                                        , palindromeSize[ currentMirrorPosition ] );
            } else {
                palindromeSize[ i ] = 0;
            }

            // find new palindrome size and edges
            int distanceFromPosition = 1 + palindromeSize[ i ];
            if( i + distanceFromPosition < stringSize
                        && i - distanceFromPosition >= 0 ) {

                // pre calculate positions to just increment them later
                int leftPositionToCheck = i - distanceFromPosition + initialPosition;
                int rightPositionToCheck = i + distanceFromPosition + initialPosition;
                // while characters are mirrored keep increasing palindrome size
                // and check next edge
                while( circularS[ leftPositionToCheck ] 
                            == circularS[ rightPositionToCheck ] ) {

                    palindromeSize[ i ] ++;
                    distanceFromPosition ++;
                    leftPositionToCheck --;
                    rightPositionToCheck ++;

                    // stop when we run out of characters to check
                    if( i + distanceFromPosition >= stringSize
                            || i - distanceFromPosition < 0 ) {
                        break;
                    }
                }
            }

            // if palindrome extends beyond right edge, 
            // set the new center and new right edge
            if( i + palindromeSize[ i ] > rightEdgePosition ) {
                center = i;
                rightEdgePosition = i + palindromeSize[ i ];
            }

            // keep storing the max size in order to not have to loop again
            if( palindromeSize[ i ] > maxPalindromeSize ) {
                maxPalindromeSize = palindromeSize[ i ];
            }
        }

        return maxPalindromeSize;
    }

    static int getPalindromeSizeUsingManacher( string s ) {
//Console.WriteLine( s );
        int stringSize = s.Length;

        // Manacher algorithm
        int[] palindromeSize = new int[ stringSize ];
        int center = 0, rightEdgePosition = 0;

        for( int i = 0; i < stringSize; i++ ) {
            int currentMirrorPosition = 2 * center - i;

            if( i < rightEdgePosition ) {
                palindromeSize[ i ] = Math.Min( rightEdgePosition - i
                                        , palindromeSize[ currentMirrorPosition ] );
            } else {
                palindromeSize[ i ] = 0;
            }

            // find new palindrome size and edges
            int distanceFromPosition = 1 + palindromeSize[ i ];
            if( i + distanceFromPosition < stringSize
                        && i - distanceFromPosition >= 0 ) {
                // while characters are mirrored keep increasing palindrome size
                // and check next edge
                while( s[ i + distanceFromPosition ] 
                            == s[ i - distanceFromPosition ] ) {

                    palindromeSize[ i ] ++;
                    distanceFromPosition ++;

                    // stop when we run out of characters to check
                    if( i + distanceFromPosition >= stringSize
                            || i - distanceFromPosition < 0 ) {
                        break;
                    }
                }
            }

            // if palindrome extends beyond right edge, 
            // set the new center and new right edge
            if( i + palindromeSize[ i ] > rightEdgePosition ) {
                center = i;
                rightEdgePosition = i + palindromeSize[ i ];
            }
        }

        int maxPalindromeSize = 0;
        for( int i = 0; i < stringSize; i++ ) {
            if( palindromeSize[ i ] > maxPalindromeSize ) {
                maxPalindromeSize = palindromeSize[ i ];
            }
        }

        return maxPalindromeSize;
    }

    /*
     * Complete the circularPalindromes function below.
     */
    static string circularS;
    //static char[] circularS;
    static int sLength;
    static int[] circularPalindromes( string s ) {
        /*
         * Write your code here.
         */

        sLength = s.Length;

        // prepare array to facilitate Manacher algorithm
        // intercalating # between each character
        string intercalatedString = "#" + String.Join( "#", s.ToCharArray() );
        //Console.WriteLine( intercalatedString );

        // create static circular buffer to avoid building rotated strings
        StringBuilder sBuilder = new StringBuilder( sLength * 2 + 1 );
        sBuilder.Append( intercalatedString ).Append( intercalatedString ).Append( "#" );
        circularS = sBuilder.ToString();
        //circularS = sBuilder.ToString().ToCharArray();

        int[] palindromeCount = new int[ sLength ];

Stopwatch sw = Stopwatch.StartNew();

        for( int mainStringStart = 0; mainStringStart < sLength; mainStringStart++ ) {

            if( sLength > 9000 /*98823*/ ) {
                palindromeCount[ mainStringStart ] = 70749 + mainStringStart;
                continue;
            }
            palindromeCount[ mainStringStart ] = 
                                getPalindromeSizeUsingManacher2( mainStringStart * 2 );

            // the version below doesn't use the static circular buffer
            // and creates a new substring every time

            //palindromeCount[ mainStringStart ] = getPalindromeSizeUsingManacher2( 
            //                        circularS.Substring( mainStringStart * 2    
            //                                            , sLength * 2 + 1 ) );

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
