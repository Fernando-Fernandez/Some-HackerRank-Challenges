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

class Result
{

    /*
     * Complete the 'getTotalX' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static int getTotalX(List<int> a, List<int> b)
    {
        // sort arrays to be able to loop from maximum a to minimum b
        //a.Sort();
        //b.Sort();
        //b.Sort( delegate( int x, int y ) {
        //    return x.CompareTo( y );
        //} );

        // find candidate numbers that could be factors of elements in 2nd array
        HashSet<int> candidateNbrSet = new HashSet<int>();

        // from the maximum nbr in 1st array to minimum nbr in 2nd array
        int aMax = a.Max(), bMin = b.Min();
        for( int aNbr = aMax; aNbr <= bMin; aNbr ++ ) {

            // check that he elements of the first array are all factors 
            // of the integer being considered
            int remainder = 0;
            for( int i = 0; i < a.Count; i++ ) {
                remainder = aNbr % a[ i ];
                if( remainder != 0 ) {
                    // disqualified
                    break;
                }
            }

            // if disqualified, skip to the next candidate nbr
            if( remainder != 0 ) {
                continue;
            }

            // check that the integer being considered is a factor 
            // of all elements of the second array
            for( int j = 0; j < b.Count; j++ ) {
                remainder = b[ j ] % aNbr;
                if( remainder != 0 ) {
                    // disqualified
                    break;
                }
            }

            // if disqualified, skip to the next candidate nbr
            if( remainder != 0 ) {
                continue;
            }

            // we could simply increment a counter here instead
            candidateNbrSet.Add( aNbr );
        }

        return candidateNbrSet.Count;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> brr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(brrTemp => Convert.ToInt32(brrTemp)).ToList();

        int total = Result.getTotalX(arr, brr);

        textWriter.WriteLine(total);

        textWriter.Flush();
        textWriter.Close();
    }
}
