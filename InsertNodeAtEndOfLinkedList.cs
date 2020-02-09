using System;
class Node
{
	public int data;
	public Node next;
    public Node(int d){
        data=d;
        next=null;
    }
		
}
class Solution {

	public static  Node insert(Node head,int data)
	{
        //Complete this method
        if( head == null ) {
            head = new Node( data );
            return head;
        }
        
        Node current = head;
        while( current.next != null ) {
            current = current.next;
        }
        current.next = new Node( data );

        return head;
    }

	public static void display(Node head)
