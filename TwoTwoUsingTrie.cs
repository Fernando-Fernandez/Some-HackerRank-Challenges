// https://www.hackerrank.com/challenges/two-two/problem
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

class Trie {
    public Trie[] Nodes;
    public Boolean ownDigit;
    public Trie() {
        Nodes = new Trie[ 10 ];
        ownDigit = false;
    }
    public void Add( string s ) {
        int i = 0;
        Trie currentTrie = this;
        while( i < s.Length ) {
            int charIndex = s[ i ] - '0';
            if( currentTrie.Nodes[ charIndex ] == null ) {
                currentTrie.Nodes[ charIndex ] = new Trie();
            }
            
            currentTrie = currentTrie.Nodes[ charIndex ];
            i++;
        }
        currentTrie.ownDigit = true;
    }
    public Boolean Find( string s ) {
        int i = 0;
        Trie currentTrie = this;
        while( i < s.Length ) {
            int charIndex = s[ i ] - '0';
            if( currentTrie.Nodes[ charIndex ] == null ) {
                // if next digit is not found, it didn't match
                return false;
            }

            currentTrie = currentTrie.Nodes[ charIndex ];
            i++;
        }

        // found last matching digit but the number continues
        if( currentTrie.ownDigit == false ) {
            return false;
        }
        // found last matching digit
        return true;
    }
    public Boolean FindInNode( char c ) {
        int charIndex = c - '0';
        return Nodes[ charIndex ] != null
                && Nodes[ charIndex ].ownDigit == true;
    }
    public int FindAndCountMatches( string s, int startingPosition = 0 ) {
        int count = 0;
        int i = startingPosition;
        Trie currentTrie = this;
        while( i < s.Length ) {
            int charIndex = s[ i ] - '0';
            Trie nextNode = currentTrie.Nodes[ charIndex ];
            if( nextNode == null ) {
                // if next digit is not found, stop counting
                return count;
            }

            if( nextNode.ownDigit == true ) {
                count++;
            }

            currentTrie = nextNode;
            i++;
        }
        return count;
    }
    public void Print( string s = "" ) {
        if( ownDigit == true ) {
            Console.WriteLine( "Number: {0}", s );
        }
        for( int i = 0; i < Nodes.Length; i++ ) {
            if( Nodes[ i ] != null ) {
                Nodes[ i ].Print( s + i );
            }
        }
    }
}

class Solution {

    /*
     * Complete the twoTwo function below.
     */
    const int nbrPowersOf2 = 801; //800;
    static Trie trie;
    static void createTrie() {
        if( trie != null ) {
            return;
        }
        trie = new Trie();
        BigInteger b = 1;
        for( int i = 0; i < nbrPowersOf2; i++ ) {
            string powerOf2 = b.ToString();
            // solution #4: add number to trie
            trie.Add( powerOf2 );

            b = b << 1;
        }
/*
        trie.Print(); 
        Console.WriteLine( "END" );

        Console.WriteLine( "Found 65536= {0}", trie.Find( "65536" ) );
        Console.WriteLine( "Found 2= {0}", trie.Find( "2" ) );
        Console.WriteLine( "Found 8192= {0}", trie.Find( "8192" ) );
        Console.WriteLine( "Found 81= {0}", trie.Find( "81" ) );
        Console.WriteLine( "Found in node 2= {0}", trie.FindInNode( '2' ) );
        Console.WriteLine( "Found in node 9= {0}", trie.FindInNode( '9' ) );
*/
    }
    static int twoTwo( string a ) {
        /*
         * Write your code here.
         */
        createTrie();
        
        int count = 0;

        // solution #4: find matching numbers in trie and count
        for( int i = 0; i < a.Length; i++ ) {
            count = count + trie.FindAndCountMatches( a, startingPosition: i );
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
