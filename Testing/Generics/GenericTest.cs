using System;
using System.Collections;
using System.Collections.Generic;
using Testing.Generics;

namespace Testing
{
  public static class GenericTest
  {
    public static void GenericDelegateContainerTest()
    {
      var delegates = new DelegateContainer<int>();
      delegates.Add(PrintInt);
      delegates.CallDelegates(55);
      delegates.CallDelegates(33);
      delegates.CallDelegates(44);

      static void PrintInt(int i)
      {
        Console.WriteLine(i);
      }
    }

    public static void GenericDefaultTest()
    {
      DefaultValues<int> intContainer = new DefaultValues<int>();
      DefaultValues<object> objectContainer = new DefaultValues<object>();
      Console.WriteLine(intContainer.IsDefault(0));
      Console.WriteLine(objectContainer.IsDefault(0));
    }

    public static void MyDictionaryGeneticTest()
    {
      MyDictionaryGenetic<int, GenericTestLuckValue> dictionaryGenetic = new MyDictionaryGenetic<int, GenericTestLuckValue>();
      dictionaryGenetic.Add(1,new GenericTestLuckValue());
      dictionaryGenetic.Add(2,new GenericTestLuckValue());
      dictionaryGenetic.Add(3,new GenericTestLuckValue());
      Console.WriteLine(dictionaryGenetic[1]);
      Console.WriteLine(dictionaryGenetic[2]);
      Console.WriteLine(dictionaryGenetic[3]);
    }

    public static void CovarianceTest()
    {
      var strings = new MyCovarianceCollection<string>();
      strings.AddItem("One");
      strings.AddItem("Two");
      strings.AddItem("Three");

      //Covariance
      IMyEnumerator<object> collString = strings;
      PrintCollection(collString, 2);

      void PrintCollection(IMyEnumerator<object> coll, int count)
      {
        for (var i = 0; i < count; i++)
        {
          Console.WriteLine(coll.GetItem(i));
        }
      }
    }

    public static void ContravarianceTest()
    {
      var items = new MyContravarianceCollection<A>();
      items.AddItem(new A());
      var b = new B();
      items.AddItem(b);
      IMyTrimmableCollection<A> collItems = items;

      //Contravariance
      IMyTrimmableCollection<B> trimColl = collItems;
      trimColl.RemoveItem(b);
    }

    public static void GenericComplexTest()
    {
      var complex = new GenericComplex<long>(3, 4, MultiplyLong, AddLong, LongToDouble, DoubleToLong);

      Console.WriteLine(complex.Magnitude);

      static long MultiplyLong(long val1, long val2) => val1 * val2;

      static long AddLong(long val1, long val2) => val1 + val2;

      static long DoubleToLong(double d) => Convert.ToInt64(d);

      static double LongToDouble(long d) => Convert.ToDouble(d);
    }
  }
}
