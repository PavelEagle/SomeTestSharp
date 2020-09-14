using System.Collections;
using System.Threading;

namespace Testing.Multithreading
{
  public class CrudeThreadPool
  {
    private readonly int _maxWorkThreads = 4;
    private readonly int _waitTimeout = 2000;
    private Semaphore _semaphore;
    private Queue _workQueue;
    private Thread[] _threads;
    private volatile bool _stop;

    public delegate void WorkDelegate();
    public CrudeThreadPool()
    {
      _stop = false;
      _semaphore = new Semaphore(0, int.MaxValue);
      _workQueue = new Queue();
      _threads = new Thread[_maxWorkThreads];
      for (var i = 0; i < _maxWorkThreads; i++)
      {
        _threads[i] = new Thread(new ThreadStart(ThreadFunc));
      }
    }

    private void ThreadFunc()
    {
      do
      {
        if (!_stop)
        {
          WorkDelegate workItem;
          if (_semaphore.WaitOne(_waitTimeout))
          {
            lock (_workQueue)
            {
              workItem = (WorkDelegate) _workQueue.Dequeue();
            }

            workItem();
          }
        }
      } while (!_stop);
    }

    public void SubmitWorkItem(WorkDelegate item)
    {
      lock (_workQueue)
      {
        _workQueue.Enqueue(item);
      }

      _semaphore.Release();
    }

    public void ShutDown()
    {
      _stop = true;
    }
  }
}
