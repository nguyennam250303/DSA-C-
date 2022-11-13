using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm
{
    class Book
    {
        class Node
        {
            public object val;
            public Node next;
            public Node(object val = null)
            {
                this.val = val;
                next = null;
            }
        }
        class LinkedList
        {
            public Node head;
            public LinkedList()
            {
                head = null;
            }
            public void PrintLinkedList()
            {
                Node temp = head;
                if (temp == null)
                {
                    Console.WriteLine("null");
                    return;
                }
                while (temp != null)
                {
                    Console.Write(temp.val + "->");
                    temp = temp.next;
                }
                Console.WriteLine("null");
            }
            public void AddAtBegin(object val)
            {
                Node newnode = new Node(val);
                newnode.next = head;
                head = newnode;
            }
            public void AddAtEnd(object val)
            {
                Node newnode = new Node(val);
                Node temp = head;
                if (temp == null)
                {
                    head = newnode;
                    return;
                }
                while (temp.next != null)
                {
                    temp = temp.next;
                }
                temp.next = newnode;
            }
            public void CreateManyNodes(List<object> list)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    AddAtEnd(list[i]);
                }
            }
            public void InsertAfterNodeGiven(Node node_given, object val)
            {
                Node newnode = new Node(val);
                if (head == null)
                {
                    Console.WriteLine("LinkedList is empty");
                    return;
                }
                newnode.next = node_given.next;
                node_given.next = newnode;
            }
            public int Length()
            {
                int count = 0;
                Node temp = head;
                while (temp != null)
                {
                    count++;
                    temp = temp.next;
                }
                return count;
            }
            public int GetLengthRec(Node head)
            {
                if (head == null)
                {
                    return 0;
                }
                return 1 + GetLengthRec(head.next);
            }
            public int LengthRec()
            {
                return GetLengthRec(head);
            }
            public void RemoveLastNode()
            {
                Node temp = head;
                Node prev = null;
                while (temp.next != null)
                {
                    prev = temp;
                    temp = temp.next;
                }
                if (temp == head)
                {
                    head = null;
                    temp = null;
                    return;
                }
                prev.next = null;
                temp = null;
            }
            public void RemoveNodeIndex(int i)
            {
                int count = 0;
                Node temp = head;
                Node prev = null;
                if (i == 0)
                {
                    head = head.next;
                    temp = null;
                    return;
                }
                if (i >= Length())
                {
                    Console.WriteLine("Out Of Index");
                    return;
                }
                while (temp.next != null && count != i)
                {
                    prev = temp;
                    count++;
                    temp = temp.next;

                }
                prev.next = temp.next;
                temp = null;
            }
            public int ExamElementInLinkedList(object val, Node head)
            {
                if (head == null)
                {
                    return 0;
                }
                if ((dynamic)val == (dynamic)head.val)
                {
                    return 1;
                }
                return ExamElementInLinkedList(val, head.next);
            }
            public void ExamElementInLinkedListRec(object val)
            {
                if (ExamElementInLinkedList(val, head) == 1)
                {
                    Console.WriteLine("Yes");
                }
                else
                {
                    Console.WriteLine("No");
                }
            }
            public Node getNodeFromIndex(int i)
            {
                int count = 0;
                Node temp = head;
                if(i >= LengthRec())
                {
                    Console.WriteLine("Out Of Index");
                }    
                while(count != i)
                {
                    count++;
                    temp = temp.next;
                }
                return temp;
            }
            public int CountValInLinkedList(object val)
            {
                Node temp = head;
                int count = 0;
                while(temp != null)
                {
                    if((dynamic)temp.val == (dynamic)val)
                    {
                        count++;
                    }
                    temp = temp.next;
                }
                return count;
                
            }
            public void FindLoop()
            {
                Node slow = head;
                Node fast = head;
                while(fast != null && fast.next != null)
                {   
                    slow = slow.next;
                    fast = fast.next.next;
                    if (slow == fast)
                    {
                        Console.WriteLine("Loop Found");
                        return;
                    }
                }
                Console.WriteLine("Loop not Found");
            }
            public int LengthLoopInLinkedList()
            {
                Node slow = head;
                Node fast = head;
                while (fast != null && fast.next != null)
                {
                    slow = slow.next;
                    fast = fast.next.next;
                    if (slow == fast)
                    {
                        break;
                    }
                }
                int count = 1;
                while(slow != null)
                {
                    slow = slow.next;
                    if(slow == fast)
                    {
                        break;
                    }
                    count++;
                }
                return count;
            }
            public void ReverseLinkedList()
            {
                Node prev = null;
                Node cur = head;
                if(cur == null)
                {
                    return;
                }    
                while(cur.next != null)
                {
                    Node next = cur.next;
                    cur.next = prev;
                    prev = cur;
                    cur = next;
                }
                head = cur;
                cur.next = prev;
            }
            public void IsPalindrome()
            {
                Stack s = new Stack();
                Node temp = head;
                while(temp != null)
                {
                    s.Push(temp.val);
                    temp = temp.next;
                }
                temp = head;
                bool flag = true;
                while(temp != null)
                {
                    if ((dynamic)temp.val != (dynamic)s.Pop())
                    {
                        flag = false;
                    }
                    temp = temp.next;
                }
                if(flag)
                {
                    Console.WriteLine("Yes");
                    return;
                }
                Console.WriteLine("No");
            }
            public void RemoveDuplicatesFromSortedLinkedList()
            {
                Node cur = head;
                Node next_next;
                if(head == null)
                {
                    return;
                }
                while(cur.next != null)
                {
                    if((dynamic)cur.val == (dynamic)cur.next.val)
                    {
                        next_next = cur.next.next;
                        cur.next = null;
                        cur.next = next_next;
                    }
                    else
                    {
                        cur = cur.next;
                    }    
                }    
            }
            public void RemoveDuplicates()
            {
                Node cur1 = head;
                Node cur2;

                while (cur1 != null)
                {
                    Node prev_cur2 = cur1;
                    cur2 = cur1.next;
                    while (cur2 != null)
                    {
                        if ((dynamic)cur1.val == (dynamic)cur2.val)
                        {
                            Node temp = prev_cur2.next;
                            prev_cur2.next = cur2.next;
                            temp = null;
                        }
                        else
                        {
                            prev_cur2 = cur2;
                        }

                        cur2 = cur2.next;
                    }
                    cur1 = cur1.next;

                }

            }
            public void SwapNode(object a, object b)
            {
                Node curA = head;
                Node prevA = null;
                Node curB = head;
                Node prevB = null;
                if ((dynamic)a==(dynamic)b)
                {
                    return;
                }    
                while (curA != null && (dynamic)curA.val != (dynamic)a)
                {
                    prevA = curA;
                    curA = curA.next;
                }
                while (curA != null && (dynamic)curB.val != (dynamic)b)
                {
                    prevB = curB;
                    curB = curB.next;
                }
                if(prevA == null)
                {
                    head = curB;
                }
                else
                {
                    prevA.next = curB;
                }    
                if(prevB == null)
                {
                    head = curA;
                }
                else
                {
                    prevB.next = curA;
                }    
                Node temp = curB.next;
                
                
                curB.next = curA.next;
                curA.next = temp;
            }
        }
        class Node2
        {
            public object val;
            public Node2 prev;
            public Node2 next;
            public Node2(object val = null)
            {
                this.val = val;
                prev = null;
                next = null;
            }
        }
        class DoublyLinkedList
        {
            public Node2 head;
            public DoublyLinkedList()
            {
                head = null;
            }
            public void PrintDoublyLinkedList()
            {
                Node2 cur = head;
                if(cur == null)
                {
                    Console.WriteLine("null");
                    return;
                }    
                while (cur != null) 
                {
                    Console.Write(cur.val + "->");
                    cur = cur.next;
                }
                Console.WriteLine("null");
            }
            public void PrintReverseDoublyLinkedList()
            {
                Node2 cur = head;
                if (cur == null)
                {
                    Console.WriteLine("null");
                    return;
                }
                while (cur.next != null)
                {
                    cur = cur.next;
                }
                while(cur != null)
                {
                    Console.Write(cur.val + "->");
                    cur = cur.prev;
                }    
                Console.WriteLine("null");
            }
            public void AddAtBegin(object val)
            {
                Node2 newnode = new Node2(val);
                newnode.next = head;
                head.prev = newnode;
                head = newnode;
            }
            public void AddAtEnd(object val)
            {
                Node2 newnode = new Node2(val);
                Node2 cur = head;
                if(cur == null)
                {
                    head = newnode;
                    return;
                }    
                while(cur.next != null)
                {
                    cur = cur.next;
                }
                cur.next = newnode;
                newnode.prev = cur;
            }
            public void CreateManyNodes(List<object> list)
            {
                foreach(object val in list)
                {
                    AddAtEnd(val);
                }    
            }
            public void InsertAfterNodeGiven(Node2 node_given, object val)
            {
                Node2 newnode = new Node2(val);
                if(head == null)
                {
                    return;
                }    
                newnode.next = node_given.next;
                if(node_given.next != null)
                    node_given.next.prev = newnode;
                node_given.next = newnode;
                newnode.prev = node_given;
            }
            public int Length()
            {
                Node2 cur = head;
                int count = 0;
                while(cur != null)
                {
                    count++;
                    cur = cur.next;
                }
                return count;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
