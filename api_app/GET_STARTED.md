# First install .NET10
- sudo apt update (if needed)
- sudo apt install -y dotnet-sdk-10.0

# Compile C++ to a .so
g++ -shared -fPIC -o libmath.so math_lib.cpp
