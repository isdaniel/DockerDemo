ARG VERSION
FROM mcr.microsoft.com/dotnet/sdk:${VERSION}
ENV webdir /WebFolder
COPY ./bin $webdir
WORKDIR $webdir
EXPOSE 5000
CMD dotnet $webdir/ConsoleWeb.dll