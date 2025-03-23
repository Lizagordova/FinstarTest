IF NOT EXISTS(SELECT [name] FROM [sys].[databases] WHERE [name] = 'Finstar')
	CREATE DATABASE [Finstar]