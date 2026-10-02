#include <iostream>
#include "MathOperations.h"


extern "C" {

  /*
    * 1. Expose MathOperations Class as a pointer
        -- Create a method that retuns a pointer to MathOperations Class
  */
  MathOperations* MathOperations_New(){
    return new MathOperations(); // return new pointer of class object
  }

  /* EXPOSE NEEDED METHODS
    1. Expose Add Method
    2. Subtract Method
  */

  // Add Method, C# will be passing in a pointer to the class, so a pointer to the class is needed
  int MathOperations_Add(MathOperations* instance, int a, int b){
    if(instance != nullptr){
      return instance->Add(a,b);
    }
    return 0; // Default Condition
  }

  // Expose Subtract Method, be sure to include the pointer to the class object
  int MathOperations_Subtract(MathOperations* instance, int a, int b){
    if(instance != nullptr){
      return instance->Subtract(a,b);
    }
    return 0; // Default Condiiton
  }

  void MathOperations_Delete(MathOperations* instance){
    delete instance; // Delete Pointer From Memory (Clean Up)
  }

}