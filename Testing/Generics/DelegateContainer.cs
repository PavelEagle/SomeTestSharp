using System.Collections.Generic;

namespace Testing.Generics
{
  public delegate void MyDelegate<in T>(T i);
  public class DelegateContainer<T>
  {
    private List<MyDelegate<T>> _imp = new List<MyDelegate<T>>();
    public void Add(MyDelegate<T> del)
    {
      _imp.Add(del);
    }

    public void CallDelegates(T k)
    {
      foreach (var del in _imp)
      {
        del(k);
      }
    }
  }
}
