# Docker Compose Configuration

This Markdown document provides an overview of the Docker Compose configuration specified in the following YAML file:

```yaml
version: '3.8'
services:
  oracle.xe:
    image: gvenzl/oracle-xe
    ports:
      - "1521:1521"
    environment:
      - ORACLE_PASSWORD=test.123
    container_name: oracle-server
  ora2pg:
    container_name: ora2pg
    environment:
      CONFIG_LOCATION: "/ora2pg_lib/config/ora2pg.conf"
      OUTPUT_LOCATION: "/data"
      ORA_HOST: "dbi:Oracle:host=oracle.xe;sid=SIDNAME;port=1521"
      ORA_USER: "system"
      ORA_PWD: "test.123"
    command: tail -f /dev/null
    volumes:
      - './config:/ora2pg_lib/config'
      - './data:/ora2pg_lib/data'
    image: georgmoser/ora2pg
```

## Overview

This Docker Compose configuration defines two services: oracle.xe and ora2pg. Each service is described with its specific properties and configurations.


## Services

### oracle.xe

* Image: The service uses the gvenzl/oracle-xe Docker image to run an Oracle Express Edition database.
* Ports: It maps port 1521 of the host to port 1521 of the container, allowing access to the Oracle database.
* Environment Variables: The service sets an environment variable ORACLE_PASSWORD with the value test.123, which presumably sets the Oracle database password.
* Container Name: The container is named oracle-server.

### ora2pg

* Container Name: The container for this service is named ora2pg.
* Environment Variables: This service sets several environment variables, including:
* CONFIG_LOCATION: Specifies the location of the ora2pg configuration file.
* OUTPUT_LOCATION: Specifies the location for ora2pg output.
* ORA_HOST: Defines the Oracle database connection string.
* ORA_USER: Specifies the Oracle database username as "system".
* ORA_PWD: Sets the Oracle database password as "test.123".
* Command: The container runs the command tail -f /dev/null, which effectively keeps the container running without executing any other processes.
* Volumes: It mounts two host directories into the container:
* ./config is mapped to /ora2pg_lib/config in the container, likely containing ora2pg configuration files.
* ./data is mapped to /ora2pg_lib/data in the container, potentially used for storing ora2pg data.
* Image: The service uses the georgmoser/ora2pg Docker image, presumably for running the ora2pg tool.
