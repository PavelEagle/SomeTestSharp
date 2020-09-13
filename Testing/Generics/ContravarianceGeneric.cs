using System.Collections.Generic;

namespace Testing.Generics
{
  public class A { }
  public class B:A {}

  interface IMyTrimmableCollection<in T>
  {
    void RemoveItem(T item);
  }

  public class MyContravarianceCollection<T>: IMyCollection<T>, IMyTrimmableCollection<T>
  {
    private List<T> collection = new List<T>();
    public void AddItem(T item)
    {
      collection.Add(item);
    }

    public void RemoveItem(T item)
    {
      collection.Remove(item);
    }
  }
}

