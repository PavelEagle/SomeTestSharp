using System.Collections;
using System.Collections.Generic;

namespace Testing
{
  public class MyCollection<T>: IEnumerable<T>
  {
    private T[] items;

    public MyCollection(T[] items)
    {
      this.items = items;
    }
    public IEnumerator<T> GetEnumerator()
    {
      lock (items.SyncRoot)
      {
        foreach (T item in items)
        {
          yield return item;
        }
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

  }
}
