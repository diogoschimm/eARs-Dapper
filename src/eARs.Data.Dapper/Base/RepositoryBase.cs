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
