using System;
using System.Collections.Generic;

namespace Testing.Generics
{
  public class MyDictionaryGenetic<TKey, TValue>
    where TKey : struct, IComparable<TKey>
    where TValue: IValue, new()
  {
    private Dictionary<TKey, TValue> imp;

    public MyDictionaryGenetic()
    {
      imp = new Dictionary<TKey, TValue>();
    }

    public void Add(TKey key, TValue value)
    {
      imp.Add(key,value);
    }

    public TValue this[TKey i]
    {
      get
      {
        if (!imp.ContainsKey(i))
          throw new ArgumentOutOfRangeException();
        return imp[i];
      }
    }
  }

  public interface IValue
  {
    public string someField => "Implementation1";

    public string someField2 => "Implementation2";
  }

  public class GenericTestLuckValue: IValue
  {
    private readonly int _value;
    public GenericTestLuckValue()
    {
      var rnd = new Random();
      _value = rnd.Next(1, 100);
    }
    
    public string someField => "Test your luck: ";

    public string someField2 => _value.ToString();

    public override string ToString()
    {
      return someField + someField2;
    }
  }
}
