# About DockerDemo

This repository used docker-compose to build a POC web server with SqlServer(with DataBase restore).

* .net core web application
* sql-server 2019(auto restore AdventureWorksDW2017 DB)

## How to use

Make sure you had installed [docker-compose](https://docs.docker.com/compose/install/)

Please use this command in the Root path of this Repository

```
docker-compose up -d
```

Then you can execute http://localhost:6001 to see that docker web service.
