[![Build Status](https://travis-ci.com/jackson15j/c_sharp_random_project_for_learning.svg?branch=master)](https://travis-ci.com/jackson15j/c_sharp_random_project_for_learning)

C# Learning Project
===================

Quick and dirty project to get my head around C#, how it uses the .NET
libraries, compilation on Linux via Mono and some basic testing. ...hopefully.

**Majority of my research is in my [csharp_notes] file.**

Emacs config changes can be found in my [Github: .emacs] repo.

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

* Build and explicitly call the tests with a log folder (NOTE: that `dotnet`
  only allows for 1 project to be defined, despite my `Dockerfile` doing
  globbing for multiple projects):

```bash
mkdir ~/logs
cd $(git rev-parse --show-toplevel)/HelloWorld   # Go to git root folder.
docker build --target testrunner -t devapp:test  # build test runner image.
docker run --rm -v ~/logs:/app/tests/<Project>/TestResults devapp:test  # runs the test runner instance with log output.
```

* Build/test/publish all within the docker build and then call the app via run
  command:

```bash
cd $(git rev-parse --show-toplevel)/HelloWorld   # Go to git root folder.
docker build -t devapp .  # Build docker image (Runs clean/build/test/publish).
docker run --rm devapp -- [args]  # Runs an instance which implicitly calls `dotnet run`.
```

Coverage
--------

* Added [Github: Coverlet] to the test project with the following line in
  `test/`: `dotnet add package coverlet.msbuild`.
* To do a coverage test run: `dotnet test /p:CollectCoverage=true`.
* Can change output format (eg. Lcov for emacs [Github: coverlay] mode support)
  / excluded files / coverage file destination, easily.
* Actively developed.

CI
--

Travis is configured to build the Docker container.

[csharp_notes]: csharp_notes.md
[Github: .emacs]: https://github.com/jackson15j/dot_emacs
[Github: Coverlet]: https://github.com/tonerdo/coverlet
[Github: coverlay]: https://github.com/twada/coverlay.el
