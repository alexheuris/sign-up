# Sign up

## Dependencies

- [Dotnet Core SDK](https://www.microsoft.com/net/core)
- [Docker](https://docs.docker.com/engine/installation/)
- [Docker Compose](https://docs.docker.com/compose/install/)

## Restore

From the project root, run:
```
dotnet restore
```

## Building

From the project root, run:
```
dotnet build
```

## Unit testing

From the project root, run:
```
dotnet test tests/SignUp.Tests/SignUp.Tests.csproj
```

## Publishing

From the project root, run:
```
./publish.sh
```

## Running

From the project root, run:
```
docker-compose up
```

## Stopping

From the project root, run:
```
Ctrl+C
docker-compose down
```

## Cleaning

From the project root, run:
```
./clean.sh
```
