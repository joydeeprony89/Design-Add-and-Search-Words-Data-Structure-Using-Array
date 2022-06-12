using System;

namespace Design_Add_and_Search_Words_Data_Structure_Using_Array
{
  class Program
  {
    static void Main(string[] args)
    {
      WordDictionary dictionary = new WordDictionary();
      dictionary.AddWord("bad");
      dictionary.AddWord("mad");
      Console.WriteLine(dictionary.Search("pad"));
      Console.WriteLine(dictionary.Search("mad"));
      Console.WriteLine(dictionary.Search(".ad"));
      Console.WriteLine(dictionary.Search("b.."));
    }
  }

  public class WordDictionary
  {
    WordDictionary[] children;
    bool IsWord;
    public WordDictionary()
    {
      children = new WordDictionary[26];
      IsWord = false;
    }

    public void AddWord(string word)
    {
      WordDictionary current = this;
      foreach (char c in word)
      {
        if (current.children[c - 'a'] == null)
        {
          current.children[c - 'a'] = new WordDictionary();
        }
        current = current.children[c - 'a'];
      }

      current.IsWord = true;
    }

    public bool Search(string word)
    {
      WordDictionary current = this;
      for (int i = 0; i < word.Length; i++)
      {
        char c = word[i];
        if(c == '.')
        {
          string subStr = word.Substring(i + 1);
          foreach(var cur in current.children)
          {
            if (cur != null && cur.Search(subStr)) return true;
          }

          return false;
        }
        else
        {
          if (current.children[c - 'a'] == null) return false;
          current = current.children[c - 'a'];
        }
      }

      return current != null && current.IsWord;
    }
  }
}
