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

# Build (with implicit Restore).
RUN dotnet build

# Run tests (Glob pattern for all folders in `test/`, with assumption that
# their `.csproj` files are one level
# deeper. eg. `test/thingTest/thingTest.csproj`).
WORKDIR /app/test
Run dotnet test **/

# Publish artefacts.
WORKDIR /app
RUN dotnet publish -o out

# Run the artefact.
FROM base
WORKDIR /app
COPY --from=base /app/src/HelloWorld/out .
ENTRYPOINT ["dotnet", "HelloWorld.dll"]
