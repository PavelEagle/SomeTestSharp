using System;

namespace ASPNetCoreTest
{
  public class RandomCounter : ICounter
  {
    private static Random rnd = new Random();
    private readonly int _value;

    public RandomCounter()
    {
      _value = rnd.Next(0, 100000);
    }
    public int Value => _value;
  }
}
