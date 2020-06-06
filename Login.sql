-- Do not use I want to use Windows LOGIN CREATE LOGIN [Login] WITH PASSWORD = 'rdjdD;e|yrhmq>djlet{thfwmsFT7_&#$!~<g<eFlxpehQf$'


--Use th ebelow script:
CREATE LOGIN [IIS APPPOOL\OdeToFood] FROM WINDOWS
GO
ALTER SERVER ROLE [dbcreator] ADD MEMBER  [IIS APPPOOL\OdeToFood]
GO

