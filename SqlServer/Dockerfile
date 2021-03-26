FROM microsoft/mssql-server-linux:latest
MAINTANER dog830228@gmail.com
RUN apt-get update && apt-get install -y  \
	curl \
	apt-transport-https
ENV BakDir="/var/opt/mssql/backup"
ENV PATH="/opt/mssql-tools/bin:${PATH}"

RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list > /etc/apt/sources.list.d/mssql-release.list

RUN apt-get install -y locales \
    && echo "en_US.UTF-8 UTF-8" > /etc/locale.gen \
    && locale-gen \
	&& apt-get -y install vim

COPY ./script/ $BakDir

WORKDIR $BakDir

RUN mkdir -p $BakDir \
	&& curl -L -o AdventureWorksDW2017.bak https://github.com/Microsoft/sql-server-samples/releases/download/adventureworks/AdventureWorksDW2017.bak

CMD /bin/bash "$BakDir/EntryPoint.sh"




