## What

This is a repository whose code was created to be used as an example of how we can use Fixture of xUnit.

There is [this article](https://medium.com/@leogjorge/xunit-advanced-features-fixtures-6b0ca4d10469) explaining how the technology works and how to use it.

## How to run

This project contains only a test project, so it can only be executed running `dotnet test` on the command line.
The tests are using a connection with MongoDB on port 27017, so you need to have Docker running on your machine.

To set up the MongoDB container, run `docker run -p 27017:27017 -d mongo:latest` on your command line.

Then go to the path where the solution is stored and run `dotnet test`.
