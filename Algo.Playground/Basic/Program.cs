using Basic.AVL;

namespace Basic
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var avl = new AvlTree();
            avl.Insert(1);
            avl.Insert(2);
            avl.Insert(3);
        }
    }
}