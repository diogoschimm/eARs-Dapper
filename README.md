# eARs-Dapper
Exemplo com uso de Dapper para Repository

## Package

```
  Install-Package Dapper
```

## Classe Base

```c#
using eARs.Domain.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace eARs.Data.Dapper.Base
{
    public abstract class RepositoryBase
    {
        private readonly IOptionsApp options;

        public RepositoryBase(IOptionsApp options)
        {
            this.options = options;
        }

        public IDbConnection Bd
        {
            get
            { 
                return new SqlConnection(this.options.ObterStringConexao());
            }
        }
    }
}

```

## Classe de Acesso a Dados

```c#
using Dapper;
using eARs.Data.Dapper.Base;
using eARs.Domain;
using eARs.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eARs.Data.Dapper
{
    public class ProvedorRepository : RepositoryBase, IProvedorRepository
    {
        public ProvedorRepository(IOptionsApp options) : base(options) { }

        public async Task<IEnumerable<Provedor>> List()
        {
            return await Bd.QueryAsync<Provedor>("SELECT * from Provedor");
        }

        public async Task<Provedor> Get(int idProvedor)
        {
            return await Bd.QueryFirstAsync<Provedor>("SELECT * from Provedor WHERE idProvedor = @idProvedor", new { idProvedor });
        }

        public async Task<Provedor> Save(Provedor provedor)
        {
            var retorno = await Bd.QueryAsync<int>("INSERT INTO Provedor (nomeProvedor) VALUES (@nomeProvedor); SELECT SCOPE_IDENTITY();", provedor);
            provedor.SetId(retorno.Single().ToString());

            return provedor;
        }

        public async Task<bool> Update(Provedor provedor)
        {
            return await Bd.ExecuteAsync("UPDATE Provedor SET nomeProvedo = @nomeProvedor WHERE idProvedor = @idProvedor", provedor) > 0;
        }

        public async Task<bool> Delete(int idProvedor)
        {
            return await Bd.ExecuteAsync("DELETE Provedor WHERE idProvedor = @idProvedor", new { idProvedor }) > 0;
        }
    }
}
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
