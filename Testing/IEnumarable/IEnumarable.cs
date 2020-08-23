using System;
using System.Collections.Generic;

namespace Testing
{
  public static class IEnumarable
  {
    public static void TestIEnumarable()
    {

      //Test custom simple collection with enumerator
      MyCollection<int> collection = new MyCollection<int>( new [] {1,2,3,4});
      Console.WriteLine("MyCollection: ");
      foreach (var n in collection)
      {
        Console.Write($"{n} ");
      }
      Console.WriteLine();

      //Test Bidirectional iterator 
      LinkedList<int> intList = new LinkedList<int>();
      for (int i = 0; i < 6; i++)
      {
        intList.AddLast(i);
      }
      BidirectionalIterator<int> bidirectionalIterator = new BidirectionalIterator<int>(intList, intList.First, TIterationDirection.Forward);
      Console.WriteLine("Bidirectional iterator: ");
      foreach (var n in bidirectionalIterator)
      {
        Console.Write($"{n} ");
        if (n == 5) //change direction
        {
          bidirectionalIterator.Direction = TIterationDirection.Backward;
        }
      }
      Console.WriteLine();

      //Test Circular iterator
      CircularIterator<int> circularIterator = new CircularIterator<int>(intList, intList.First);
      int counter = 0;
      Console.WriteLine("Circular iterator: ");
      foreach (var n in circularIterator)
      {
        Console.Write($"{n} ");
        if (counter++ == 20)
        {
          circularIterator.Stop();
        }
      }
    }
  }
}
