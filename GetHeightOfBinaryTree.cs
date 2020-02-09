using System;
class Node{
    public Node left,right;
    public int data;
    public Node(int data){
        this.data=data;
        left=right=null;
    }
}
class Solution{

	static int getHeight( Node root ) {
        //Write your code here
        //Console.WriteLine( root.data );

        // empty subtree's height is -1
        int leftHeight = -1;
        int rightHeight = -1;
        
        if( root.left != null ) { 
            //Console.WriteLine( "getting height left" );
            leftHeight = getHeight( root.left );
        }
        if( root.right != null ) {
            //Console.WriteLine( "getting height right" );
            rightHeight = getHeight( root.right );
        }

        int height = 1 + Math.Max( leftHeight, rightHeight );

        return height;
    }

	static Node insert(Node root, int data){
