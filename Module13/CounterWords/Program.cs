using System;

namespace WordsCounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            string path = @"C:\Users\mrvov\Desktop\test\Text1.txt";

            Counter.ShowTopWords(path);
        }
    }
}