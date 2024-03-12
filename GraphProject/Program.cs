using System;
using System.Collections.Generic;

namespace GraphProject
{
  internal abstract class Program
  {
    // Создание и заполнение графа
    private static Dictionary<string, string[]> AdjacencyList = new Dictionary<string, string[]>();
    private static int[,] AdjacencyMatrix = new int[,] { };

    #region Реализация поиска в ширину
    // Функция поиска в ширину для списка смежности
    private static void BFSforAdjacencyList(string startVertex)
    {
      // Создание очереди поиска и списка посещенных узлов
      Queue<string> searchQueue = new Queue<string>();
      searchQueue.Enqueue(startVertex);
      List<string> searched = new List<string>();

      while (searchQueue.Count > 0)
      {
        // Извлечение текущей вершины 
        var extractedVertex = searchQueue.Dequeue();
        if (!searched.Contains(extractedVertex))
        {
          // Вывод посещаемой вершины
          Console.WriteLine($"Посещённая вершина: {extractedVertex}");
          // Добавление соседей вершины
          foreach (var s in AdjacencyList[extractedVertex])
            // Создание нового пути с добавлением текущего узла и добавление его в очередь
            searchQueue.Enqueue(s);

          // Добавление текущего узла в список посещенных узлов
          searched.Add(extractedVertex);
        }
      }
    }

    private static void BFSforAdjacencyMatrix(int startVertex)
    {
      bool[] searched = new bool[] { }; 
      Queue<int> searchQueue = new Queue<int>();

      searchQueue.Enqueue(startVertex);
      searched[startVertex] = true;

      while(searchQueue.Count > 0)
      {
        var extractedVertex = searchQueue.Dequeue();
        Console.WriteLine($"Посещённая вершина: {extractedVertex}");

        for (int i = 0; i < AdjacencyMatrix.GetLength(0); i++)
        {
          if (AdjacencyMatrix[])
        }
      }
    }
    #endregion

    public class Graph
    {
      private int[,] adjacencyMatrix;
      private int numVertices;

      public Graph(int[,] matrix)
      {
        adjacencyMatrix = matrix;
        numVertices = matrix.GetLength(0);
      }

      public void BFS(int startVertex)
      {
        bool[] visited = new bool[numVertices];
        Queue<int> queue = new Queue<int>();

        visited[startVertex] = true;
        queue.Enqueue(startVertex);

        while (queue.Count > 0)
        {
          int currentVertex = queue.Dequeue();
          Console.WriteLine("Посещена вершина: " + currentVertex);

          for (int i = 0; i < numVertices; i++)
          {
            if (adjacencyMatrix[currentVertex, i] == 1 && !visited[i])
            {
              visited[i] = true;
              queue.Enqueue(i);
            }
          }
        }
      }
    }

    public static void Main(string[] args)
    {

      // Добавление связей в граф
      AdjacencyList.Add("you", new string[] { "alice", "bob", "claire" });
      AdjacencyList.Add("bob", new string[] { "anuj", "peggy" });
      AdjacencyList.Add("alice", new string[] { "peggy" });
      AdjacencyList.Add("claire", new string[] { "thom", "jonny" });
      AdjacencyList.Add("anuj", new string[] { });
      AdjacencyList.Add("peggy", new string[] { });
      AdjacencyList.Add("thom", new string[] { });
      AdjacencyList.Add("jonny", new string[] { });

      // Вызов функции BFS с начальным узлом "you"
      BFSforAdjacencyList("you");
      int[,] adjacencyMatrix = {
            { 0, 1, 1, 0 },
            { 1, 0, 0, 1 },
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 }
        };
      int startVertex = 0;

      Graph graph1 = new Graph(adjacencyMatrix);
      graph1.BFS(startVertex);
    }
  }
}
