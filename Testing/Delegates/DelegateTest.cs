using System;
using System.Collections.Generic;
using System.Reflection;
using Testing.Delegates;
using Testing.Delegates.Event;

namespace Testing
{
  public static class DelegateTest
  {
    public delegate double ProcessResults(double x, double y);

    public delegate void ApplyRaiseDelegate<in T>(T instance, decimal percent);
    public static void TestingChain()
    {
      DelegateChain dc1 = new DelegateChain(1.5);
      DelegateChain dc2 = new DelegateChain(2.5);

      ProcessResults[] delegates = {
        dc1.Compute,
        dc2.Compute,
        DelegateChain.StaticCompute,
      };

      ProcessResults cheined = delegates[0] + delegates[1] + delegates[2];

      Delegate[] chain = cheined.GetInvocationList();
      double acc = 0;
      for (var i = 0; i < chain.Length; i++)
      {
        ProcessResults current = (ProcessResults) chain[i];
        acc += current(4, 5);
      }
      Console.WriteLine($"Accumulator: {acc}");

      double combined = cheined(4, 5);
      Console.WriteLine($"Combined: {combined}");
    }

    public static void TestingDelegateSalaryRaiseOf()
    {
      Console.WriteLine("Open type: ");
      List<Employee> employees = new List<Employee>
      {
        new Employee(40000),
        new Employee(60000), 
        new Employee(70000)
      };

      MethodInfo mi = typeof(Employee).GetMethod("ApplyRaiseOf", BindingFlags.Instance | BindingFlags.Public);
      ApplyRaiseDelegate<Employee> applyRaise = (ApplyRaiseDelegate<Employee>) 
                  Delegate.CreateDelegate(typeof(ApplyRaiseDelegate<Employee>), mi);

      foreach (var e in employees)
      {
        applyRaise(e, (decimal) 0.1);
        Console.WriteLine(e.Salary);
      }
    }

    public static void EventTest()
    {
      Metronome m = new Metronome();
      Listener l = new Listener();
      l.Subscribe(m);
      m.Start();
    }

    public static void TestDelegateStrategy()
    {
      var strategyTest = new DelegateStrategy(SortAlgorithms.SortFast);
      strategyTest.DoSomeWork();
      strategyTest.Strategy = SortAlgorithms.SortSlow;
      strategyTest.DoSomeWork();
    }
  }
}
