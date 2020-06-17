using System;
using System.Collections.Generic;
using System.Linq;

namespace KlingonClass
{
    public class Kling
    {
        public string[] SplitKlingArray(string item)
        {
            string[] ft = item.Split(' ');
            return ft;
        }
        public List<string> SplitKlingList(string item)
        {
            List<string> ret = new List<string>();
            string[] ft = SplitKlingArray(item);
            for (int i = 0; i < ft.Count(); i++)
            {
                ret.Add(ft[i]);
            }
            return ret;
        }
        public int FindPreps(string item)
        {
            int prep = 0;
            string[] ft = SplitKlingArray(item);
            for (int i = 0; i < ft.Count(); i++)
            {
                if (ft[i].Length == 3)
                {
                    string last = ft[i].Substring(ft[i].Length - 1);
                    if (last != "s" && last != "l" && last != "f" && last != "w" && last != "k")
                    {
                        if (!ft[i].Contains("d"))
                        {
                            prep++;
                        }
                    }
                }
            }
            return prep;
        }
        public int FindVerbs(string item)
        {
            int verb = 0;
            string[] ft = SplitKlingArray(item);
            for (int i = 0; i < ft.Count(); i++)
            {
                if (ft[i].Length >= 8)
                {
                    string last = ft[i].Substring(ft[i].Length - 1);
                    if (last == "s" || last == "l" || last == "f" || last == "w" || last == "k")
                    {
                        verb++;
                    }
                }
            }
            return verb;
        }
        public int FindVerbsInFirstPerson(string item)
        {
            int verb = 0;
            string[] ft = SplitKlingArray(item);
            for (int i = 0; i < ft.Count(); i++)
            {
                if (ft[i].Length >= 8)
                {
                    string last = ft[i].Substring(ft[i].Length - 1);
                    if (last == "s" || last == "l" || last == "f" || last == "w" || last == "k")
                    {
                        string first = ft[i].Substring(0, 1);
                        if (first != "s" && first != "l" && first != "f" && first != "w" && first != "k")
                        {
                            verb++;
                        }
                    }
                }
            }
            return verb;
        }
        public List<string> Vocabs(string item)
        {
            List<string> words = SplitKlingList(item);
            string word, wordToSort;
            for (int i = 0; i < words.Count; i++)
            {
                word = words[i];
                wordToSort = string.Empty;
                for (int j = 0; j < word.Length; j++)
                {
                    char pl = word[j];
                    wordToSort += ChangeLeter(pl);
                }
                words.RemoveAt(i);
                words.Insert(i, wordToSort);
            }
            words.Sort();
            for (int i = 0; i < words.Count; i++)
            {
                wordToSort = string.Empty;
                for (int j = 0; j < words[i].Length; j++)
                {
                    char newOrder = words[i][j];
                    wordToSort += ChangeLeterToNewOrder(newOrder);
                }
                words.RemoveAt(i);
                words.Insert(i, wordToSort);
            }
            return words;
        }
        public string ListOfVocabs(string item)
        {
            string words = string.Empty;
            List<string> lista = Vocabs(item);
            foreach (string voc in lista)
            {
                words += " " + voc;
            }
            string word = words.Substring(1);
            return word;
        }
        public int BeautifulNumbers(string item)
        {
            List<string> ft = SplitKlingList(item);
            string ord = "kbwrqdnfxjmlvhtcgzps";
            int count = 0;
            int indOf = 0;
            Int64 value = 0;
            Int64 mult = 0;
            string n = string.Empty;
            for (int i = 0; i < ft.Count; i++)
            {
                value = 0;
                for (int j = 0; j < ft[i].Length; j++)
                {
                    indOf = ord.IndexOf(ft[i][j]);
                    mult = (int)Math.Pow(20, j);
                    value += indOf * mult;
                }
                if (value >= 440566 && value % 3 == 0)
                {
                    count++;
                }
            }
            return count;
        }
        private string ChangeLeter(char lt)
        {
            string wordToSort = string.Empty;
            switch (lt)
            {
                case 'k':
                    wordToSort += 'a';
                    break;
                case 'b':
                    wordToSort += 'b';
                    break;
                case 'w':
                    wordToSort += "c";
                    break;
                case 'r':
                    wordToSort += "d";
                    break;
                case 'q':
                    wordToSort += "e";
                    break;
                case 'd':
                    wordToSort += "f";
                    break;
                case 'n':
                    wordToSort += "g";
                    break;
                case 'f':
                    wordToSort += "h";
                    break;
                case 'x':
                    wordToSort += "i";
                    break;
                case 'j':
                    wordToSort += "j";
                    break;
                case 'm':
                    wordToSort += "k";
                    break;
                case 'l':
                    wordToSort += "l";
                    break;
                case 'v':
                    wordToSort += "m";
                    break;
                case 'h':
                    wordToSort += "n";
                    break;
                case 't':
                    wordToSort += "o";
                    break;
                case 'c':
                    wordToSort += "p";
                    break;
                case 'g':
                    wordToSort += "q";
                    break;
                case 'z':
                    wordToSort += "r";
                    break;
                case 'p':
                    wordToSort += "s";
                    break;
                case 's':
                    wordToSort += "t";
                    break;
            }
            return wordToSort;
        }
        private string ChangeLeterToNewOrder(char lt)
        {
            string wordToSort = string.Empty;
            switch (lt)
            {
                case 'a':
                    wordToSort += 'k';
                    break;
                case 'b':
                    wordToSort += 'b';
                    break;
                case 'c':
                    wordToSort += "w";
                    break;
                case 'd':
                    wordToSort += "r";
                    break;
                case 'e':
                    wordToSort += "q";
                    break;
                case 'f':
                    wordToSort += "d";
                    break;
                case 'g':
                    wordToSort += "n";
                    break;
                case 'h':
                    wordToSort += "f";
                    break;
                case 'i':
                    wordToSort += "x";
                    break;
                case 'j':
                    wordToSort += "j";
                    break;
                case 'k':
                    wordToSort += "m";
                    break;
                case 'l':
                    wordToSort += "l";
                    break;
                case 'm':
                    wordToSort += "v";
                    break;
                case 'n':
                    wordToSort += "h";
                    break;
                case 'o':
                    wordToSort += "t";
                    break;
                case 'p':
                    wordToSort += "c";
                    break;
                case 'q':
                    wordToSort += "g";
                    break;
                case 'r':
                    wordToSort += "z";
                    break;
                case 's':
                    wordToSort += "p";
                    break;
                case 't':
                    wordToSort += "s";
                    break;
            }
            return wordToSort;
        }
    }
}
