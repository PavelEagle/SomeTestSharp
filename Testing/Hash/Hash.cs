using System;
using System.Threading.Channels;

namespace Testing
{
  public static class Hash
  {
    public static void TestingHash()
    {
      var hashTable = new HashTable<Car>(100);
      var testCar = new Car() {Color = "red", Name = "Honda", Price = 1000000};
      hashTable.Add(testCar);
      hashTable.Add(new Car() {Color = "blue", Name = "BMW", Price = 2500000});
      hashTable.Add(new Car() {Color = "white", Name = "Toyota", Price = 3000000});
      hashTable.Add(new Car() {Color = "black", Name = "Lada", Price = 200000});
      hashTable.Add(new Car() {Color = "yellow", Name = "Ferrari", Price = 14000000});
      hashTable.Add(new Car() {Color = "red", Name = "Volvo", Price = 1400000});

      Console.WriteLine(hashTable.Search(testCar));
      Console.WriteLine(hashTable.Search(new Car() { Color = "red", Name = "Lada", Price = 1000000 }));
    }
  }
}
