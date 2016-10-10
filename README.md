# SqlServer-Replace-Utility

Single purpose project to replace a string in SQL Server objects (views, stored procedures and user defined functions) with another string.

It helps in two-databases scenario where one DB references the other and uses multi dot syntax (e.g. [databaseName].[dbo].[tableName]). In case another pair of dtabases is needed (e.g. for testing), this tool can help.

It uses SMO, references local SQL Server 2014 (64-bit) assemblies.
