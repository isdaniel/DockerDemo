EXEC sp_adddistributor @distributor = 'distributor', @password = 'test.123'
EXEC sp_adddistributiondb @database = 'distribution';
EXEC sp_adddistpublisher @publisher = 'publisher', @distribution_db = 'distribution'

