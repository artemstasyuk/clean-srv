## API for clean-srv

#### REST, Domain Driven Design, Clean Architecture

#### Stack: 

ASP NET Core Web API, PostreSQL, EF Core, MediatR, Mapster, Redis, ErrorOr, Fluent API and Validation, Swagger, xUnit

#### Implemented: 

JWT bearer authentication, role-based authorization, division into commands/requests, global error handling, validation, model mapping,
shopping cart(distributed cache), admin panel, unit tests

#### Used patterns:

CQRS, Repository


#### How to Launch
1.  Install and launch Redis docker image 
```bash
docker run -p 6379:6379 --name redis-master -e REDIS_REPLICATION_MODE=master -e ALLOW_EMPTY_PASSWORD=yes bitnami/redis:latest
```
2.  Change the database connection string in the appsettings.json file of the project
3.  Start the project
4.  Done!
