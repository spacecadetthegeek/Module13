using System;
using System.Collections.Generic;
using System.Linq;

namespace WordsCounter
{
    public class Counter
    {

        public static void ShowTopWords(string path)
        {
            List<string> topWords = new List<string>(WordsCounter(path).Keys);

            Console.WriteLine("Слова, которые чаще всего встречаются в тексте: ");
            Console.WriteLine();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i + 1} {topWords[i]}");
            }

            Console.WriteLine();
            Console.ReadKey();
        }

        private static string[] Text1(string path)
        {
            string textFromFile = File.ReadAllText(path);

            var clearText = new string(textFromFile.Where(c => char.IsLetter(c) || char.IsWhiteSpace(c)).ToArray());

            string[] text = clearText.Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            return text;
        }

        private static Dictionary<string, int> WorkWithText(List<string> text)
        {
            HashSet<string> uniqueWords = new HashSet<string>(text);

            Dictionary<string, int> topWords = new Dictionary<string, int>();

            foreach (string word in uniqueWords)
                topWords.Add(word, 0);

            return topWords;
        }

        private static List<string> TextFilter(List<string> sourceText)
        {
            List<string> text = new List<string>();
            for (int i = 0; i < sourceText.Count; i++)
            {
                if (sourceText[i].Length > 3)
                {
                    text.Add(sourceText[i]);
                }
            }

            return text;
        }

        private static Dictionary<string, int> WordsCounter(string path)
        {
            List<string> sourceText = new List<string>(Text1(path));

            sourceText.Sort();

            var text = TextFilter(sourceText);

            var wordsCounter = WorkWithText(text);

            for (int i = 0; i <= text.Count - 1; i++)
            {
                if (wordsCounter.ContainsKey(text[i]))
                    wordsCounter[text[i]]++;
            }

            var sortedDict = wordsCounter.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return sortedDict;
        }
    }
}