
using System;
using System.Collections.Generic;

namespace Testing.Generics
{
  public class GenericComplex<T>: IComparable<GenericComplex<T>> where T: struct
  {
    private T real;
    private T imaginary;
    private BinaryOp mult;
    private BinaryOp add;
    private Converter<T, double> converterToDouble;
    private Converter<double, T> converterToT;

    public GenericComplex(T real, T imaginary, BinaryOp mult, BinaryOp add, 
          Converter<T, double> converterToDouble, Converter<double, T> converterToT)
    {
      this.real = real;
      this.imaginary = imaginary;
      this.mult = mult;
      this.add = add;
      this.converterToDouble = converterToDouble;
      this.converterToT = converterToT;
    }
    public delegate T BinaryOp(T val, T val2);

    public T Real
    {
      get => real;
      set => real = value;
    }

    public T Imaginary
    {
      get => imaginary;
      set => imaginary = value;
    }

    public T Magnitude =>
      converterToT(Math.Sqrt(converterToDouble(add(
          mult(real, real), mult(imaginary, imaginary)))));

    public int CompareTo(GenericComplex<T> other)
    {
      return Comparer<T>.Default.Compare(Magnitude, other.Magnitude);
    }
  }
}
