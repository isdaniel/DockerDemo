sleep 20s

sqlcmd -U sa -P test.123 -S "localhost,1433" -i "./RestoreCommand.sql"

