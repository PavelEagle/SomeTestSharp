namespace Testing
{
  public class Car
  {
    public string Name { get; set; }
    public string Color { get; set; }
    public int Price { get; set; }

    public override string ToString()
    {
      return $"{Color} {Name}";
    }

    public override int GetHashCode()
    {
      return (Name + Color).Length;
    }
  }
}
