// https://www.hackerrank.com/challenges/magic-square-forming/problem
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
using System.Runtime.Serialization.Formatters.Binary;

class Solution {

    static int[][][] possibleMagicSquares;
    static void createPossibleMagicSquares() {
        if( possibleMagicSquares != null ) {
            return;
        }

        // create first square from the example (a clockwise rotated Lao Shu Square)
        int[][] firstMagicSquare = new int[3][] { 
            new int[] { 8, 3, 4 }
            , new int[] { 1, 5, 9 }
            , new int[] { 6, 7, 2 } 
        };

        possibleMagicSquares = new int[ 8 ][][];
        possibleMagicSquares[ 0 ] = firstMagicSquare;
        possibleMagicSquares[ 1 ] = FlipHorizontally( firstMagicSquare );
        possibleMagicSquares[ 2 ] = FlipVertically( firstMagicSquare );
        possibleMagicSquares[ 3 ] = FlipVertically( possibleMagicSquares[ 1 ] );
        possibleMagicSquares[ 4 ] = Transpose( firstMagicSquare );
        possibleMagicSquares[ 5 ] = FlipHorizontally( possibleMagicSquares[ 4 ] );
        possibleMagicSquares[ 6 ] = FlipVertically( possibleMagicSquares[ 4 ] );
        possibleMagicSquares[ 7 ] = FlipVertically( possibleMagicSquares[ 5 ] );
        /*
        Print( "Original", possibleMagicSquares[ 0 ] );
        Print( "Horizontal Flip", possibleMagicSquares[ 1 ] );
        Print( "Vertical Flip", possibleMagicSquares[ 2 ] );
        Print( "Horizontal + Vertical Flip", possibleMagicSquares[ 3 ] );
        Print( "Transposed", possibleMagicSquares[ 4 ] );
        */
    }

    static int[][] DeepClone( int[][] source ) {
        IFormatter formatter = new BinaryFormatter();
        Stream stream = new MemoryStream();
        using( stream ) {
            formatter.Serialize( stream, source );
            stream.Seek( 0, SeekOrigin.Begin );
            return (int[][]) formatter.Deserialize( stream );
        } 
    }

    static void SwitchPosition( int[][] square
                                , int firstX, int firstY
                                , int secondX, int secondY ) {
        int temp = square[ firstX ][ firstY ];
        square[ firstX ][ firstY ] = square[ secondX ][ secondY ];
        square[ secondX ][ secondY ] = temp;
    }

    static int[][] FlipHorizontally( int[][] aMagicSquare ) {
        int[][] newMagicSquare = DeepClone( aMagicSquare );
        for( int i = 0; i < 3; i++ ) {
            SwitchPosition( newMagicSquare, 0, i, 2, i );
        }
        return newMagicSquare;
    }

    static int[][] FlipVertically( int[][] aMagicSquare ) {
        int[][] newMagicSquare = DeepClone( aMagicSquare );
        for( int i = 0; i < 3; i++ ) {
            SwitchPosition( newMagicSquare, i, 0, i, 2 );
        }
        return newMagicSquare;
    }
    static void Print( string s, int[][] aMagicSquare ) {
        Console.WriteLine( s );
        Console.WriteLine( "{0} {1} {2}", aMagicSquare[ 0 ][ 0 ]
                        , aMagicSquare[ 0 ][ 1 ], aMagicSquare[ 0 ][ 2 ] );
        Console.WriteLine( "{0} {1} {2}", aMagicSquare[ 1 ][ 0 ]
                        , aMagicSquare[ 1 ][ 1 ], aMagicSquare[ 1 ][ 2 ] );
        Console.WriteLine( "{0} {1} {2}", aMagicSquare[ 2 ][ 0 ]
                        , aMagicSquare[ 2 ][ 1 ], aMagicSquare[ 2 ][ 2 ] );
    }

    static int[][] Transpose( int[][] aMagicSquare ) {
        int[][] newMagicSquare = DeepClone( aMagicSquare );
        SwitchPosition( newMagicSquare, 1, 0, 0, 1 );
        SwitchPosition( newMagicSquare, 2, 0, 0, 2 );
        SwitchPosition( newMagicSquare, 2, 1, 1, 2 );
            
        return newMagicSquare;
    }

    // Complete the formingMagicSquare function below.
    static int formingMagicSquare(int[][] s) {
        createPossibleMagicSquares();

        // check S against all possible magic squares counting the replacents required
        int minReplacements = 100;
        for( int n = 0; n < possibleMagicSquares.Length; n++ ) {
            int[][] aSquare = possibleMagicSquares[ n ];
            int replacementCount = 0;
            for( int i = 0; i < 3; i++ ) {
                for( int j = 0; j < 3; j++ ) {
                    int diff = aSquare[ i ][ j ] - s[ i ][ j ];
                    replacementCount += Math.Abs( diff );
                }
            }
            if( minReplacements > replacementCount ) {
                minReplacements = replacementCount;
            }
        }

        return minReplacements;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int[][] s = new int[3][];

        for (int i = 0; i < 3; i++) {
            s[i] = Array.ConvertAll(Console.ReadLine().Split(' '), sTemp => Convert.ToInt32(sTemp));
        }

        int result = formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
