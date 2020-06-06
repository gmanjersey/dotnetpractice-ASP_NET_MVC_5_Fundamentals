--CREATE LOGIN [Login] WITH PASSWORD = 'rdjdD;e|yrhmq>djlet{thfwmsFT7_&#$!~<g<eFlxpehQf$'

--CREATE LOGIN [IIS APPPOOL\OdeToFood] FROM WINDOWS
--GO

ALTER SERVER ROLE [dbcreator] ADD MEMBER  [IIS APPPOOL\OdeToFood]
GO