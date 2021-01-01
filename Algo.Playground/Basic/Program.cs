using System;
using static System.Console;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.NetworkInformation;
using Basic.AVL;

namespace Basic
{
    public static class Program
    {
        static void Main(string[] args)
        {
            const int totalCount = 11;
            var maxProcessCount = 2;
            var files = new List<string> {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k"};
            var processCount = Math.Ceiling(totalCount / (float) maxProcessCount);

            for (var i = 0; i < processCount; i++)
            {
                if (i == (int) (processCount - 1))
                    maxProcessCount = totalCount - (i * maxProcessCount);

                ProcessFiles(files.GetRange(i * maxProcessCount, maxProcessCount));
            }
        }

        private static void ProcessFiles(IEnumerable<string> list)
        {
            Console.WriteLine(string.Join(",", list));
        }
    }
}