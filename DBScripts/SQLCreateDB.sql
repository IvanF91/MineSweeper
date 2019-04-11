USE master
GO
IF NOT EXISTS (
   SELECT name
   FROM sys.databases
   WHERE name = N'MineSweeperGame'
)
CREATE DATABASE [MineSweeperGame]
GO