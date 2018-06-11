# Команды работы с консолью при создании проекта
*`./ - корень репозитория ( = 144.math.spbu-II/ )`*

```
$ cd ./homeWork\ 9/T1-PrimeGenerator/
$ dotnet new sln
$ mkdir PrimeGeneratorSource/
$ dotnet new classlib ./PrimeGeneratorSource/
$ dotnet sln add ./PrimeGeneratorSource/PrimeGeneratorSource.csproj
$ mkdir Tests/ && cd ./Tests/
$ dotnet new mstest 
$ dotnet add reference ../PrimeGeneratorSource/PrimeGeneratorSource.csproj
$ cd ..
$ dotnet sln add ./Tests/Tests.csproj

$ dotnet build
$ dotnet test ./Tests/
```