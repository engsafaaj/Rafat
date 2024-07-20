@echo off
sqlcmd -S .\SQLEXPRESS -d master -Q "IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'RafatDB') CREATE DATABASE RafatDB"
sqlcmd -S .\SQLEXPRESS -d RafatDB -i setup.sql
pause
