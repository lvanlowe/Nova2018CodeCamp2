## Nova2018CodeCamp2

### Dependencies
* .net core 2.0
	* `dotnet --version`
* [visual studio](https://www.visualstudio.com/downloads/)

### Setup
* `dotnet restore`

### Db mssql setup

Db is run in memory, can launch live mssql instance using this method

* docker
* https://github.com/Microsoft/sqlopsstudio
* `docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=yourStrong(!)Password' -p 1433:1433 -d microsoft/mssql-server-linux:2017-CU6`
* open sqlopsstudio & connect to server: localhost, user: sa, pw: yourStrong(!)Password, & create Nova2018CodeCamp db
	* `CREATE DATABASE Nova2018CodeCamp;`

### Run Tests
* `dotnet run --project Nova2018CodeCamp.Test/Nova2018CodeCamp.Test.csproj`

### Run Project
* `dotnet run --project Nova2018CodeCamp.sln`