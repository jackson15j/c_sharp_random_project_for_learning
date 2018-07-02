# Dockerfile for the dev clean/build/test/publish/run cycle.
#
# See:
# * https://github.com/dotnet/dotnet-docker-samples/blob/master/dotnetapp-dev/Dockerfile
# * https://docs.microsoft.com/en-us/dotnet/core/docker/intro-net-docker
# * https://docs.docker.com/engine/examples/dotnetcore/
#
# TODO: add entrypoints to call specific stages.
FROM microsoft/dotnet:latest AS base
WORKDIR /app

# Copying project in, in it's current state and then doing a clean...
COPY . .
RUN dotnet clean

# Explicit restore to separate out from the build logs.
RUN dotnet restore
RUN dotnet build

# Test the artefact entrypoint.
#
# TODO: Decide if I should have a test step in publish, if these stage is not
# explicitly called, or allow for two; publishWithTests/publishWithoutTests,
# stages??
#
# `docker build --target=test -t <...> /path/to/Dockerfile/directory/.`
# Run tests (Glob pattern for all folders in `test/`, with assumption that
# their `.csproj` files are one level
# deeper. eg. `test/thingTest/thingTest.csproj`).
FROM base AS testrunner
WORKDIR /app/test
# COPY test/. .
# RUN dotnet build **
# FIXME: Cannot run the exec form of entrypoint due to it quoting wildcards:
# ENTRYPOINT ["dotnet", "test", "--logger:trx", "/app/test/**"]
# FIXME: You can only `-v ~/logs/app/test/Project/TestResults/` to one project
# (it's a dotnet limitation).
ENTRYPOINT dotnet test --logger:trx **

# Docker build test stage if the above docker run call is not used.
From base AS test
WORKDIR /app/test
RUN dotnet test **

# Publish artefacts.
FROM test AS publish
WORKDIR /app
RUN dotnet publish -o out

# Run the artefact entrypoint.
FROM publish AS runtime
WORKDIR /app
COPY --from=publish /app/src/HelloWorld/out .
ENTRYPOINT ["dotnet", "HelloWorld.dll"]
