# Get build image - using 2.1 as it is LTS
FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-stage
WORKDIR /app

# Copy source
COPY . ./

# Build project and run tests
RUN dotnet restore
RUN dotnet pack -c Release --no-restore -o /app/publish

ENTRYPOINT ["/bin/bash", "docker-deploy.bash"]
