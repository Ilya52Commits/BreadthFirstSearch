using System;
using System.Collections.Generic;

namespace GraphProject
{
  internal class Program
  {
    // Создание и заполнение графа
    private static Dictionary<string, string[]> graph = new Dictionary<string, string[]>();

    #region Реализация поиска в ширину
    // Функция поиска в ширину (Breadth-First Search)
    private static bool BFS(string name)
    {
      // Создание очереди поиска и списка посещенных узлов
      Queue<(string, List<string>)> searchQueue = new Queue<(string, List<string>)>();
      searchQueue.Enqueue((name, new List<string>()));
      List<string> searched = new List<string>();

      while (searchQueue.Count > 0)
      {
        // Извлечение текущего узла и его пути
        var (person, path) = searchQueue.Dequeue();
        if (!searched.Contains(person))
        {
          if (personIsSearched(person))
          {
            // Если узел является продавцом манго, выводим сообщение и кратчайший путь
            Console.WriteLine(person + " is a mango seller");
            Console.WriteLine("Shortest path: " + string.Join(" -> ", path));
            return true;
          }
          else
          {
            foreach (var s in graph[person])
            {
              // Создание нового пути с добавлением текущего узла и добавление его в очередь
              var newPath = new List<string>(path);
              newPath.Add(person);
              searchQueue.Enqueue((s, newPath));
            }

            // Добавление текущего узла в список посещенных узлов
            searched.Add(person);
          }
        }
      }

      return false;
    }
    // Функция для проверки, является ли имя ключевым
    private static bool personIsSearched(string name) => name[name.Length - 1] == 'm';
    #endregion

    public static void Main(string[] args)
    {

      // Добавление связей в граф
      graph.Add("you", new string[] { "alice", "bob", "claire" });
      graph.Add("bob", new string[] { "anuj", "peggy" });
      graph.Add("alice", new string[] { "peggy" });
      graph.Add("claire", new string[] { "thom", "jonny" });
      graph.Add("anuj", new string[] { });
      graph.Add("peggy", new string[] { });
      graph.Add("thom", new string[] { });
      graph.Add("jonny", new string[] { });

      // Вызов функции BFS с начальным узлом "you"
      Console.WriteLine(BFS("you"));
    }
  }
}
