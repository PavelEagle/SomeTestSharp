using System;
using System.Collections;

namespace Testing.Delegates
{
  public delegate void SortStrategy(ICollection collection);
  public class DelegateStrategy
  {
    private SortStrategy _strategy;
    private readonly ArrayList _myCollection = new ArrayList(){1,2,3,4};

    public DelegateStrategy(SortStrategy defaultStrategy)
    {
      _strategy = defaultStrategy;
    }
    public SortStrategy Strategy
    {
      get => _strategy;
      set => _strategy = value;
    }

    public void DoSomeWork()
    {
      _strategy(_myCollection);
    }
  }

  public static class SortAlgorithms
  {
    public static void SortFast(ICollection collection)
    {
      Console.WriteLine("Fast sort");
    }

    public static void SortSlow(ICollection collection)
    {
      Console.WriteLine("Slow sort");
    }
  }
}
