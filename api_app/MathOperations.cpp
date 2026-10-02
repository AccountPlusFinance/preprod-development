#include "MathOperations.h"

MathOperations::MathOperations() {} // Class Constructor

int MathOperations::Square(int value){
  return (value * value)+1;
}

int MathOperations::Add(int a, int b){
  a = Square(a);
  return a+b;
}

int MathOperations::Subtract(int a, int b){
  b = Square(b);
  return a-b;
}
