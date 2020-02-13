using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

class Solution {
    static int getPalindromeSizeUsingManacher2( int initialPosition ) {
        // this one avoids creating new strings and inspects characters
        // directly on the main circular buffer 
        
        int stringSize = sLength * 2 + 1;

        // Manacher algorithm
        int[] palindromeSize = new int[ stringSize ];
        int center = 0, rightEdgePosition = 0;

        int maxPalindromeSize = 0;
        for( int i = 0; i < stringSize; i++ ) {
            int currentMirrorPosition = 2 * center - i;

            int currentPalindromeSize = palindromeSize[ i ];
            
            if( i < rightEdgePosition ) {
                currentPalindromeSize = Math.Min( rightEdgePosition - i
                                        , palindromeSize[ currentMirrorPosition ] );
            } else {
                currentPalindromeSize = 0;
            }

            // find new palindrome size and edges
            int distanceFromPosition = 1 + currentPalindromeSize;
            if( i + distanceFromPosition < stringSize
                        && i - distanceFromPosition >= 0 ) {

                // pre calculate positions to just increment them later
                int leftPositionToCheck = i - distanceFromPosition + initialPosition;
                int rightPositionToCheck = i + distanceFromPosition + initialPosition;
                // while characters are mirrored keep increasing palindrome size
                // and check next edge
                while( circularS[ leftPositionToCheck ] 
                            == circularS[ rightPositionToCheck ] ) {

                    currentPalindromeSize ++;
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
            if( i + currentPalindromeSize > rightEdgePosition ) {
                center = i;
                rightEdgePosition = i + currentPalindromeSize;
            }

            // keep storing the max size in order to not have to loop again
            if( currentPalindromeSize > maxPalindromeSize ) {
                maxPalindromeSize = currentPalindromeSize;
            }

            palindromeSize[ i ] = currentPalindromeSize;
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

    public static void setPalindromeSizeUsingManacher( int mainStringStart ) {
        palindromeCount[ mainStringStart ] = 
                        getPalindromeSizeUsingManacher2( mainStringStart * 2 );
    }

    /*
     * Complete the circularPalindromes function below.
     */
    static string circularS;
    //static char[] circularS;
    //static int[] palindromeSize;
    static int[] palindromeCount;
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

        //palindromeSize = new int[ 2 * ( sLength * 2 + 1 ) ];

        
        palindromeCount = new int[ sLength ];

Stopwatch sw = Stopwatch.StartNew();

        //Task[] taskArray = new Task[ 3 ];

        for( int mainStringStart = 0; mainStringStart < sLength; mainStringStart++ ) {
            //int stringStart = mainStringStart;
            //taskArray[ 0 ] = Task.Factory.StartNew(
            //            () => setPalindromeSizeUsingManacher( stringStart ) );
            //if( stringStart + 1 < sLength ) {
            //    taskArray[ 1 ] = Task.Factory.StartNew(
            //            () => setPalindromeSizeUsingManacher( stringStart + 1 ) );
            //}
            //if( stringStart + 2 < sLength ) {
            //    taskArray[ 2 ] = Task.Factory.StartNew(
            //            () => setPalindromeSizeUsingManacher( stringStart + 2 ) );
            //}
            
            //mainStringStart++;
            //mainStringStart++;
            //Task.WaitAll( taskArray );

            setPalindromeSizeUsingManacher( mainStringStart );

            //palindromeCount[ mainStringStart ] = 
            //                    getPalindromeSizeUsingManacher2( mainStringStart * 2 );

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
