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

After a user has signed up, check that the user has been successfully added to the database by running the following command while the `db` container is running:
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

## Notes

- A valid password is a password that has a length inbetween 12 and 32 characters. This makes the password significantly hard to crack and allows users the freedom to enter whichever characters they desire. Complex passwords are still highly recommended. See [Password Security: Complexity vs. Length](http://resources.infosecinstitute.com/password-security-complexity-vs-length/#gref) for more information.

- The script used to create the database and tables used by the app is located at [setup.sql](db/setup.sql). This script gets run as part of `docker-compose up`. No manual run is needed.
