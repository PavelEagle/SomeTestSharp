using System.Collections.Generic;

namespace Testing.Generics
{
  public class MyCovarianceCollection<T>: IMyCollection<T>, IMyEnumerator<T>
  {
    private readonly List<T> collection = new List<T>();
    public void AddItem(T item)
    {
      collection.Add(item);
    }

    public T GetItem(int index)
    {
      return collection[index];
    }
  }

  interface IMyEnumerator<out T>
  {
    T GetItem(int index);
  }
  interface IMyCollection<T>
  {
    void AddItem(T item);
  }
}
