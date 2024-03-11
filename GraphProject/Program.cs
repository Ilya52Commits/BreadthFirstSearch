using System;
using System.Collections.Generic;
using System.Linq;

namespace GraphProject
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Dictionary<string, string[]> graph = new Dictionary<string, string[]>();

      graph.Add("you", new string[] { "alice", "bob", "claire" });
      graph.Add("bob", new string[] { "anuj", "peggy" });
      graph.Add("alice", new string[] { "peggy" });
      graph.Add("claire", new string[] { "thom", "jonny" });
      graph.Add("anuj", new string[] { });
      graph.Add("peggy", new string[] { });
      graph.Add("thom", new string[] { });
      graph.Add("jonny", new string[] { });

      foreach (var s in  graph)
      {
        Console.WriteLine(s.Key);
        foreach (var v in s.Value)
        {
          Console.WriteLine(" " + v);
        }
      }

      bool BFS(string name)
      {
        Queue<string> searchQueue = new Queue<string>();
        searchQueue.Enqueue(name);
        string[] searched = { };

        while (searchQueue.Count > 0)
        {
          var person = searchQueue.Dequeue();
          if (!searched.Contains(person))
          {
            if (personIsSerched(person))
            {
              Console.WriteLine(person + " is a mango seller");
              return true;
            }
            else
            {
              searchQueue.Enqueue(person);
              searched.Append(person);
            }
          }
        }

        return false;
      }

      Console.WriteLine(BFS("you"));
    }

    private static bool personIsSerched(string name) => name[-1] == 'm';

  }
}
