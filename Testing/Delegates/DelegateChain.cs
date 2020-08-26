namespace Testing
{
  public class DelegateChain
  {
    private double _factor;
    public DelegateChain(double factor)
    {
      _factor = factor;
    }

    public double Compute(double x, double y)
    {
      double result = (x + y) * _factor;
      return result;
    }

    public static double StaticCompute(double x, double y)
    {
      double result = (x + y) * 0.5;
      return result;
    }
  }
}
