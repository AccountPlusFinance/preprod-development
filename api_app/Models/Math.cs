using System;
using System.Runtime.InteropServices;

namespace API
{
  class MathOperationsNative : IDisposable
  {
    const string LibraryName = "libmath.so"; // Shared Library Name

    // ATTRIBUTES FOR EXTERNAL SHARED OBJECT(S)
    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern IntPtr MathOperations_New();

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern int MathOperations_Add(IntPtr instance, int a, int b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern int MathOperations_Subtract(IntPtr instance, int a, int b);

    [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
    static extern void MathOperations_Delete(IntPtr instance);

    // Private pointer to C++ .so
    private IntPtr mathInstance { get; set; } = IntPtr.Zero; 

    public MathOperationsNative(){
      mathInstance = MathOperations_New(); // Create new pointer
    } // Default Constructor

    // Make sure we don't have a nullptr to the C++ Shared Object Class
    private bool IsValid => mathInstance != IntPtr.Zero; 

    private int Compute_Sum(int a, int b)
    {
      return MathOperations_Add(mathInstance, a, b);
    }

    private int Compute_Difference(int a, int b)
    {
      return MathOperations_Subtract(mathInstance, a, b);
    }

    // Print that the C++ obejct is not initiated
    private void PrintFailedPointer()
    {
      Console.WriteLine("Failed to initiate/create C++ instance");
    }

    public int Get_Sum(int a, int b)
    {
      if (!IsValid) {
        PrintFailedPointer();
        return -1;
      }
      return Compute_Sum(a,b);
    }

    public int Get_Difference(int a, int b)
    {
      if (!IsValid) {
        PrintFailedPointer();
        return -1;
      }
      return Compute_Difference(a,b);
    }

    // Clean up pointer
    public void Dispose()
    {
      if (IsValid){
        MathOperations_Delete(mathInstance);
        mathInstance = IntPtr.Zero; // Reset to zero so it's marked dead
      }
      // else do nothing, it was already a nullptr
    }
  }
}