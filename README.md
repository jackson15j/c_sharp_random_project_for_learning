C# Learning Project
===================

Quick and dirty project to get my head around C#, how it uses the .NET
libraries, compilation on Linux via Mono and some basic testing. ...hopefully.

Hierarchical Setup
------------------

* Make directory: `ProjectName/src/ProjectName/` and run `dotnet new console`
  to initialise the source code folder.
* Make directory: `ProjectName/test/ProjectNameTest/` and run `dotnet new
  xunit` to initialise the test code folder. Followed by `dotnet add reference
  ../../src/ProjectName/ProjectName.csproj` to direct the tests at the src code
  folder.

Commands
--------

* Run code: `dotnet run` from `src/ProjectName/` folder.
* Test code: `dotnet test` from `test/ProjectNameTest/` folder.

Or use the docker container to do a full development cycle
(clean/build/test/publish/run):

```bash
cd $(git rev-parse --show-toplevel)/HelloWorld   # Go to git root folder.
docker build -t devapp .  # Build docker image (Runs clean/build/test/publish).
docker run --rm devapp  # Runs an instance which implicitly calls `dotnet run`.
```
