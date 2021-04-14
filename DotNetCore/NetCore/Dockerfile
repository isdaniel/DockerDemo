FROM mcr.microsoft.com/dotnet/sdk:3.1 as build
Copy ./ConsoleWeb /ConsoleWeb
WORKDIR /ConsoleWeb
RUN dotnet restore
RUN dotnet publish -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:3.1 as server
WORKDIR /app
COPY --from=build /app .
CMD dotnet ConsoleWeb.dll


