## What

This is a repository which code was created to be used as an exemple of how we can use Fixture of xUnit. 

There is this article explaining how the technology works and how to use it.

## How to run

This project contains only test project, so can only be executed with `dotnet test` command on cmd.
The tests are using a connection with MongoDB on port 27017, so you need to have docker running on your machine.

Execute on your command line:
```
docker run -p 27017:27017 -d mongo:latest
```
