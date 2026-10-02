using System;
using System.Runtime.InteropServices;

namespace API
{
  class Program
  {
    const string LibraryName = "libmath.so"; // Shared Library Name
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr MathOperations_New();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern int MathOperations_Add(IntPtr instance, int a, int b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern int MathOperations_Subtract(IntPtr instance, int a, int b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern void MathOperations_Delete(IntPtr instance);

    public static void Main()
    {
      Console.WriteLine("Hello API DHUNIYA, deewani");
      Console.WriteLine("Initiating C++ object in C#");

      IntPtr mathInstance = MathOperations_New();
      if(mathInstance == IntPtr.Zero)
      {
        Console.WriteLine("Failed to initiate/create C++ instance");
        return;
      }
      try
      {
        int sum = MathOperations_Add(mathInstance, 20, 8);
        int difference = MathOperations_Subtract(mathInstance, 20, 8);

        Console.WriteLine($"Result of 20 + 8 = {sum}");
        Console.WriteLine($"Result of 20 + 8 = {difference}");
      }
      finally
      {
        // Clean up memory
        MathOperations_Delete(mathInstance);
      }
    }
  }
}