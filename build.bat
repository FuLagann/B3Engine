
dotnet clean
dotnet restore
dotnet build build/B3Engine.OpenGL.csproj
dotnet build test/Base
dotnet build test/GLSL
dotnet build test/SDL
