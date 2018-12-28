FROM microsoft/dotnet:2.1-sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
#FROM microsoft/dotnet:aspnetcore-runtime
FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "Dotnetcore.Windowdocker.dll"]