using System;

namespace Testing.Generics
{
  public class DefaultValues<T>
  {
    private T[] imp; 
    public DefaultValues()
    {
      imp = new T[4];
      for (var i = 0; i < imp.Length; i++)
      {
        imp[i] = default;
      }
    }

    public bool IsDefault(int i)
    {
      if (i < 0 || i >= imp.Length)
      {
        throw new ArgumentOutOfRangeException();
      }

      return Equals(imp[i],default(T));
    }
  }
}
