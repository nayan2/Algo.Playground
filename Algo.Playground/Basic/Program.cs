using System;
using Basic.BST;

namespace Basic
{
    public static class Program
    {
        static void Main(string[] args)
        {
            MyBst test = new MyBst();
            test.Insert(7);
            test.Insert(4);
            test.Insert(9);
            test.Insert(1);
            test.Insert(6);
            test.Insert(8);
            test.Insert(10); 
            
            MyBst test2 = new MyBst();
            test2.Insert(7);
            test2.Insert(4);
            test2.Insert(9);
            test2.Insert(1);
            test2.Insert(6);
            test2.Insert(8);
            test2.Insert(10); 
            
            // bool result = test.Find(1);
            // Console.WriteLine(test.TraversePreOrder());
            // Console.WriteLine(test.TraverseInOrder());
            // Console.WriteLine(test.TraversePostOrder());
            //var height = test.Height();
            //var min = test.MinInATree();
            var isTreeEqual = test.IsEqual(test, test2);
        }
    }
    
    

    // public class Person
    // {
    //     private string FirstName;
    //     private string LastName;
    //
    //     public Person(string firstName, string lastName)
    //         => (FirstName, LastName) = (firstName, LastName);
    //
    //     public void Deconstruct(out string firstName, out string lastName)
    //         => (firstName, lastName) = (FirstName, LastName);
    //
    //     public static bool IsInChat(Person p) => p switch
    //     {
    //         ("x", "y") => true,
    //         _ => false
    //     };
    // }
    
    // Testing
    // var testQueue = new PriorityQueue<int>(5);
    // testQueue.Enqueue(10);
    // testQueue.Enqueue(20);
    // testQueue.Enqueue(30);
    // testQueue.Dequeue();
    // testQueue.Dequeue();
    // testQueue.Enqueue(40);
    // testQueue.Enqueue(50);
    // testQueue.Enqueue(60);
    // testQueue.Enqueue(70);
    // testQueue.Enqueue(80);
    // Console.WriteLine(testQueue.Dequeue());
}