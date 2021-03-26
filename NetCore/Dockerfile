#FROM mcr.microsoft.com/dotnet/sdk:${VERSION}
FROM mcr.microsoft.com/dotnet/sdk:3.1
ENV webdir /WebFolder
COPY ./bin $webdir
WORKDIR $webdir
EXPOSE 5000
CMD dotnet $webdir/ConsoleWeb.dll