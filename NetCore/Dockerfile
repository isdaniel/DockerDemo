ARG VERSION
FROM mcr.microsoft.com/dotnet/sdk:${VERSION}
MAINTANER dog830228@gmail.com
#設定環境變數
ENV webdir /WebFolder
COPY ./bin $webdir
#當作進入點時目錄
WORKDIR $webdir
EXPOSE 5000
CMD dotnet $webdir/ConsoleWeb.dll