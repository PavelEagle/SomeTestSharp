﻿namespace Testing
{
  class Program
  {
    static void Main(string[] args)
    {
      //Hash.TestingHash();
      //Vector.TestVector();
      //IEnumarable.TestIEnumarable();

      DelegateTest.TestDelegateStrategy();

      GenericTest.ContravarianceTest();
      GenericTest.MyDictionaryGeneticTest();
    }
  }
}
