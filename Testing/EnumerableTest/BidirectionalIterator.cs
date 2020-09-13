using System;
using System.Collections;
using System.Collections.Generic;

namespace Testing.EnumerableTest
{
  public class BidirectionalIterator<T>: IEnumerable<T>
  {
    private Type enumType;
    private IEnumerator<T> enumerator;
    public BidirectionalIterator(LinkedList<T> list, LinkedListNode<T> start, TIterationDirection dir)
    {
      enumerator = CreateEnumerator(list, start, dir);
      enumType = enumerator.GetType();
    }

    public TIterationDirection Direction
    {
      get
      {
        return (TIterationDirection) enumType.GetField("dir").GetValue(enumerator);
      }
      set
      {
        var aa = enumType.GetField("dir");
        enumType.GetField("dir").SetValue(enumerator, value);
      }
    }
    public IEnumerator<T> GetEnumerator()
    {
      return enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    private IEnumerator<T> CreateEnumerator(LinkedList<T> list, LinkedListNode<T> start, TIterationDirection dir)
    {
      LinkedListNode<T> current = null;
      do
      {
        if (current == null)
        {
          current = start;
        }
        else
        {
          if (dir == TIterationDirection.Forward)
          {
            current = current.Next;
          }
          else
          {
            current = current.Previous;
          }
        }

        if (current != null)
        {
          yield return current.Value;
        }
      } while (current != null);
    }
  }
}
