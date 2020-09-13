namespace Testing.Delegates
{
  public class Employee
  {
    private decimal _salary;

    public Employee(decimal salary)
    {
      _salary = salary;
    }

    public decimal Salary => _salary;

    public void ApplyRaiseOf(decimal percent)
    {
      _salary *= (1 + percent);
    }
  }
}
