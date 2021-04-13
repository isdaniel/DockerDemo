FROM mcr.microsoft.com/mssql/server:2017-latest
ENV scriptPath="/script"
ENV PATH="/opt/mssql-tools/bin:${PATH}"
RUN apt-get update && apt-get install -y  \
	curl \
	apt-transport-https 


RUN curl https://packages.microsoft.com/keys/microsoft.asc | apt-key add - \
    && curl https://packages.microsoft.com/config/ubuntu/16.04/prod.list > /etc/apt/sources.list.d/mssql-release.list \ 
	&& /opt/mssql/bin/mssql-conf set sqlagent.enabled true 

RUN apt-get install -y locales \
    && mkdir "/var/opt/mssql/ReplData" \ 
    && echo "en_US.UTF-8 UTF-8" > /etc/locale.gen \
	&& apt-get -y install vim 


COPY ./script/ $scriptPath

WORKDIR $scriptPath

CMD /bin/bash "$scriptPath/EntryPoint.sh"




