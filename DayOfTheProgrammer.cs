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

    // Complete the dayOfProgrammer function below.
    static string dayOfProgrammer( int year ) {
        Boolean julianCalendar = ( year <= 1918 );
        Boolean leapYear = ( year % 400 == 0 ) 
                        || ( year % 4 == 0 
                            && year % 100 != 0 );
        if( julianCalendar ) {
            leapYear = ( year % 4 == 0 );
        }
                   
        int februaryDays = ( year == 1918 ) ? 15 
                            : ( leapYear ? 29 : 28 );
Console.WriteLine( "leap= {0}  julian= {1}  year4= {2}   year400= {3}  feb={4}"
    , leapYear, julianCalendar, year % 4, year % 400, februaryDays ); 

        int[] monthDays = new int[] {
            31, februaryDays, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31
        };

        int sumDays = 0;
        int month = 0;
        while( month < monthDays.Length ) {
            if( sumDays + monthDays[ month ] > 256 ) {
                break;
            }
            sumDays += monthDays[ month ];
            month++;
        }

        int day = 256 - sumDays;

        return String.Format( "{0:00}.{1:00}.{2}", day, month + 1, year );
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
