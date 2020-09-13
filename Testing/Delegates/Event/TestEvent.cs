using System.ComponentModel;

namespace Testing.Delegates.Event
{
  // feature
  public class TestEvent
  {
    public event AsyncCompletedEventHandler Event;
    public delegate void AsyncCompletedEventHandler(TestEvent sender, AsyncCompletedEventArgs e);
    public void Start()
    {
      Event?.Invoke(this, null);
    }
  }
}
