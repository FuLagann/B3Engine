
all: restore
	dotnet build build/B3Engine.OpenGL.csproj
	dotnet build test/Base
	dotnet build test/SDL
	dotnet build test/GLSL

clean:
	dotnet clean

restore: clean
	dotnet restore
