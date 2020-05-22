# eARs-Dapper
Exemplo com uso de Dapper para Repository

## Package

```
  Install-Package Dapper
```

## Banco de Dados

```tsql
  CREATE DATABASE [BDSamples];
  
  USE BDSamples;
  
  CREATE TABLE [dbo].[Provedor] (
	  [idProvedor] [int] IDENTITY(1,1) NOT NULL,
	  [nomeProvedor] [varchar](100) NULL 
  )  
  
```
