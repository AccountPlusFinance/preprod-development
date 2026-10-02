#include <iostream>
using namespace std;

class MathOperations{
  private:
    int Square(int value){
      return value*value;
    }
  public:
    int Add(int a, int b){
      int a_squared = Square(a);
      return a_squared+b;
    }

    int Subtract(int a, int b){
      b = Square(b);
      return a-b;
    }
}; 

extern "C" {
  MathOperations* MathOperations_New(){
    return new MathOperations();
  }

  int MathOperations_Add(MathOperations* instance, int a, int b){
    if(instance != nullptr){
      return instance->Add(a,b);
    }
    return 0;
  }

  int MathOperations_Subtract(MathOperations* instance, int a, int b){
    if(instance != nullptr){
      return instance->Subtract(a,b);
    }
    return 0; 
  }

  void MathOperations_Delete(MathOperations* instance){
    delete instance;
  }
}