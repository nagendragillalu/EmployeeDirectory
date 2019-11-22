FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ./EmployeeDirectoryAPI/EmployeeDirectoryAPI.csproj EmployeeDirectoryAPI/
RUN dotnet restore EmployeeDirectoryAPI/EmployeeDirectoryAPI.csproj
COPY . .

WORKDIR /src/EmployeeDirectoryAPI
RUN dotnet build EmployeeDirectoryAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EmployeeDirectoryAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmployeeDirectoryAPI.dll"]




