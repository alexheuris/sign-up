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
./run-unit-tests.sh
```

## Publishing

From the project root, run:
```
./publish.sh
```

## Running

This step requires that the solution has been restored and published (see above). Ensure that docker has access to at least 4GB of RAM for the MSSQL container. Note also that the database takes ~15 seconds to initialise.

From the project root, run:
```
docker-compose up
```

To check that a user has been successfully added to the database run the following command while the `db` container is running:
```
docker exec -it db /opt/mssql-tools/bin/sqlcmd -U sa -P myPASSWORD123 -d SignUp -Q "SELECT * FROM users;"
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
