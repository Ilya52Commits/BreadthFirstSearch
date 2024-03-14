using System;
using System.Collections.Generic;

namespace GraphProject;
internal abstract class Program
{
  // Создание и заполнение графа
  private static readonly Dictionary<string, string[]> AdjacencyList = new Dictionary<string, string[]>();
  private static readonly int[,] AdjacencyMatrix = {
    { 0, 1, 1, 0 },
    { 1, 0, 0, 1 },
    { 1, 0, 0, 0 },
    { 0, 1, 0, 0 }
  };

  #region Реализация поиска в ширину
  // Функция поиска в ширину для списка смежности
  private static void BfSforAdjacencyList(string startVertex)
  {
    // Создание очереди поиска и списка посещенных узлов
    var searchQueue = new Queue<string>();
    searchQueue.Enqueue(startVertex);
    var searched = new List<string>();

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

  // Функция поиска в ширину для матрицы смежности
  private static void BfSforAdjacencyMatrix(int startVertex)
  {
    // Создание массива пройденных вершин
    var searched = new bool[AdjacencyMatrix.GetLength(0)] ; 
    // Создание очереди для поиска
    var searchQueue = new Queue<int>();

    // Добавление первого элемента в очередь
    searchQueue.Enqueue(startVertex);
    // Добавление первого эелемента в список "проверенных"
    searched[startVertex] = true;

    while(searchQueue.Count > 0)
    {
      var extractedVertex = searchQueue.Dequeue();
      Console.WriteLine($"Посещённая вершина: {extractedVertex}");

      for (var i = 0; i < AdjacencyMatrix.GetLength(0); i++)
      {
        if (AdjacencyMatrix[extractedVertex, i] == 1 && !searched[i])
        {
          searched[i] = true; 
          searchQueue.Enqueue(i);
        }
      }
    }
  }
  #endregion
    
  public static void Main()
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
    BfSforAdjacencyList("you");
    // Выхов функции BFS с начальным узлом "0"
    BfSforAdjacencyMatrix(0);
  }
}