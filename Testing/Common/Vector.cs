using System.Numerics;

namespace Testing
{
  public static class Vector
  {
    public static void TestVector()
    {
      var v1 = new Vector4(1, 2, 3, 4);
      var v2 = new Vector4(5, 6, 7, 8);
      var result = new Vector4(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z, v1.W + v2.W);
    }
  }
}
