using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Node{
    public Node left,right;
    public int data;
    public Node(int data){
        this.data=data;
        left=right=null;
    }
}
class Solution{
    
	static void levelOrder( Node root ) {
        //Write your code here
        Queue<Node> queue = new Queue<Node>();
        string output = "";

        if( root == null ) {
            return;
        }

        queue.Enqueue( root );

        while( queue.Count > 0 ) {
            Node aNode = queue.Dequeue();
            output += ( output != "" ? " " : "" ) + aNode.data;

            if( aNode.left != null ) {
                queue.Enqueue( aNode.left );
            }

            if( aNode.right != null ) {
                queue.Enqueue( aNode.right );
            }
        }

        Console.WriteLine( output );
    }

	static Node insert(Node root, int data){
