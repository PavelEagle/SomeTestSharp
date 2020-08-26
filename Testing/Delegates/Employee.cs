namespace Testing
{
  public class Employee
  {
    private decimal _salery;

    public Employee(decimal salery)
    {
      _salery = salery;
    }

    public decimal Salery => _salery;

    public void ApplyRaiseOf(decimal percent)
    {
      _salery *= (1 + percent);
    }
  }
}
