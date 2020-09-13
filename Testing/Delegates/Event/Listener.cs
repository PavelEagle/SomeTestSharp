using System;

namespace Testing.Delegates.Event
{
  public class Listener
  {
    public void Subscribe(Metronome m)
    {
      m.Tick += HeardIt;
    }

    private void HeardIt(Metronome m, EventArgs e)
    {
      Console.WriteLine("HEARD IT");
    }
  }
}
