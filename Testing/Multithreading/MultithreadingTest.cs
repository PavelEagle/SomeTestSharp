using System;
using System.Threading;
using Testing.Multithreading;

namespace Testing
{
  public static class MultithreadingTest
  {
    private static readonly object _theLock = new object();
    private static int _numberThreads = 0;
    private static Random rnd = new Random();


    public static void LockTest()
    {
      var reporter = new Thread(RptThreadFunc) {IsBackground = true};
      reporter.Start();

      var rndThreads = new Thread[50];
      for (var i = 0; i < 50; i++)
      {
        rndThreads[i] = new Thread(RndThreadFunc);
        rndThreads[i].Start();
      }

      static void RndThreadFunc()
      {
        lock (_theLock)
        {
          ++_numberThreads;
        }
        var time = rnd.Next(1000, 12000);
        Thread.Sleep(time);
        lock (_theLock)
        {
          --_numberThreads;
        }
      }

      static void RptThreadFunc()
      {
        while (true)
        {
          var threadCount = 0;
          lock (_theLock)
          {
            threadCount = _numberThreads;
          }

          Console.WriteLine("Number of active threads: " + threadCount);
          Thread.Sleep(1000);
        }
      }
    }

    public static void SemaphoreTest()
    {
      var pool = new CrudeThreadPool();
      for (var i = 0; i < 10; i++)
      {
        pool.SubmitWorkItem(new CrudeThreadPool.WorkDelegate((WorkFunction)));
      }

      Thread.Sleep(1000);
      pool.ShutDown();

      static void WorkFunction()
      {
        Console.WriteLine("Method is called in thread " + Thread.CurrentThread.ManagedThreadId);
      }
    }
  }
}
