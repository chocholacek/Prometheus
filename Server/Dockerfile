FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
RUN mkdir /src
WORKDIR /src
COPY ./ ./
RUN dotnet build -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:5.0
RUN mkdir /src
WORKDIR /src
COPY --from=build-env /src/out ./

ENTRYPOINT dotnet Server.dll