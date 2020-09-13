using System;

namespace Testing.Delegates.Event
{
  // feature
  public class TestClassForEvent
  {
    public void Subscribe(TestEvent m)
    {
      m.Event += Completed;
    }

    private void Completed(TestEvent m, EventArgs e)
    {
      Console.WriteLine("Done!");
    }

  }
}
