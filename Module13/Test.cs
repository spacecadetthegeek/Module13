using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Module13
{
    class Test
    {
        private static string[] Text(string path)
        {
            string textFromFile = File.ReadAllText(path);
            return textFromFile.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.None);
        }

        public static void Testing(string path)
        {
            Console.WriteLine();
            LinkedListTest(path);

            Console.WriteLine();
            ListTest(path);
        }

        public static void LinkedListTest(string pathToFile)
        {
            var watchOne = Stopwatch.StartNew();

            LinkedList<string> lList = new LinkedList<string>(Text(pathToFile));

            Console.WriteLine("LinkedList 'Add': {0}", watchOne.Elapsed.TotalMilliseconds);

            watchOne = Stopwatch.StartNew();

            var insetOper = lList.Find("Part");

            lList.AddAfter(insetOper, "Test");

            Console.WriteLine("LinkedList 'Inset': {0}", watchOne.Elapsed.TotalMilliseconds);
        }

        private static void ListTest(string pathToFile)
        {
            var watchTwo = Stopwatch.StartNew();

            List<string> listForTest = new List<string>(Text(pathToFile));

            Console.WriteLine("List 'Add' operation: {0} мс", watchTwo.Elapsed.TotalMilliseconds);

            watchTwo = Stopwatch.StartNew();

            listForTest.Insert(listForTest.IndexOf("Часть"), "Test");

            Console.WriteLine("List 'Insert' operation: {0} мс", watchTwo.Elapsed.TotalMilliseconds);
        }
    }
}
