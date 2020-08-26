using System;

namespace Testing
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
