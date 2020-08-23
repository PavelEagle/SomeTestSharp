using System;
using System.Collections.Generic;

namespace Testing
{
  public static class IEnumarable
  {
    public static void TestIEnumarable()
    {

      MyCollection<int> collection = new MyCollection<int>( new [] {1,2,3,4});
      Console.WriteLine("MyCollection: ");
      foreach (var n in collection)
      {
        Console.Write($"{n} ");
      }
      Console.WriteLine();

      LinkedList<int> intList = new LinkedList<int>();
      for (int i = 0; i < 6; i++)
      {
        intList.AddLast(i);
      }
      BidirectionalIterator<int> iterator = new BidirectionalIterator<int>(intList, intList.First, TIterationDirection.Forward);
      Console.WriteLine("Bidirectional iterator: ");
      foreach (var n in iterator)
      {
        Console.Write($"{n} ");
        if (n == 5)
        {
          iterator.Direction = TIterationDirection.Backward;
        }
      }
    }
  }
}
