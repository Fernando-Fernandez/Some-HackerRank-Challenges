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

    static string getBinary( int n ) {
        string bin = "";
        while( n > 0 ) {
            int remainder = n % 2;
            n = n / 2;
            bin = remainder + bin;
        }
        return bin;
    }

    static int countOnes( string binaryN ) {
        int counter = 0, maxCount = 0;
        for( int index = 0; index < binaryN.Length; index++ ) {
            counter = (binaryN[ index ] == '1')? counter + 1 : 0;
            maxCount = (counter > maxCount)? counter : maxCount;
        }
        return maxCount;
    }

    static void Main(string[] args) {
        int n = Convert.ToInt32(Console.ReadLine());
        string binaryN = getBinary( n );
        
        Console.WriteLine( countOnes( binaryN ) );

        /*
        int counter = 0, maxCount = 0;
        for( int index = 0; index < binaryN.Length; index++ ) {
            if( binaryN[ index ] == '1' ) {
                counter ++;
                if( counter > maxCount ) {
                    maxCount = counter;
                }
            } else {
                counter = 0;
            }
        }
        Console.WriteLine( maxCount );
        */
    }
}
