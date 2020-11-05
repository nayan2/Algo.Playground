using System.Net.NetworkInformation;
using Basic.AVL;

namespace Basic
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var avl = new AvlTree();
            avl.Insert(10);
            avl.Insert(14);
            avl.Insert(16);
            avl.Insert(15);
        }
    }
}