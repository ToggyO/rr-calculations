FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
#COPY *.csproj ./
COPY . .
RUN dotnet restore --force ./RrNetBack.sln
RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/sdk:5.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "RrNetBack.API.dll"]
