using System;

namespace Testing
{
  public class Metronome
  {
    public event TickHandler Tick;
    public delegate void TickHandler(Metronome m, EventArgs e);
    public void Start()
    {
      while (true)
      {
        System.Threading.Thread.Sleep(1000);
        Tick?.Invoke(this, null);
      }
    }
  }
}
