using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution {

    /*
     * Complete the pageCount function below.
     */
    static int pageCount(int n, int p) {
        /*
         * Write your code here.
         */

        int pageTurns1 = p / 2;
        int pageTurns2 = ( n - p ) / 2 + ( n % 2 == 0 && n == p + 1 ? 1 : 0 ) ;
        //Console.WriteLine( "{0} {1}", pageTurns1, pageTurns2 );

        return Math.Min( pageTurns1, pageTurns2 );
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int p = Convert.ToInt32(Console.ReadLine());

        int result = pageCount(n, p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
