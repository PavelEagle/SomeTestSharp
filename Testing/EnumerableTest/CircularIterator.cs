using System;
using System.Collections;
using System.Collections.Generic;

namespace Testing.EnumerableTest
{
  public class CircularIterator<T>: IEnumerable<T>
  {
    private Type _enumType;
    private IEnumerator<T> _enumerator;
    private bool stop;
    public CircularIterator(LinkedList<T> list, LinkedListNode<T> start)
    {
      _enumerator = CreateEnumerator(list, start, false);
      _enumType = _enumerator.GetType();
    }

    public void Stop()
    {
      _enumType.GetField("stop")?.SetValue(_enumerator, true);
    }
    public IEnumerator<T> GetEnumerator()
    {
      return _enumerator;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    private IEnumerator<T> CreateEnumerator(LinkedList<T> list, LinkedListNode<T> start, bool stop)
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
          current = current.Next ?? start;
        }

        yield return current.Value;
      } while (!stop);
    }
  }
}
