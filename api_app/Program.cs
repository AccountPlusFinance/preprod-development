using System;


namespace API
{
  class Program
  {
    public static void Main()
    {
      using (var math = new MathOperationsNative())
      {
        int sum = (math.Get_Sum(2,3))+1;
        int diff = (math.Get_Difference(8,2))+1;
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {diff}");
      }
      // Deleting the pointer happens right here.
    }
  }
}