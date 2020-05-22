using eARs.Domain.Interfaces;

namespace eARs.WebApp.Imp
{
    public class OptionsApp : IOptionsApp
    {
        private readonly string _strConexao;

        public OptionsApp(string strConexao)
        {
            this._strConexao = strConexao;
        }

        public int ObterIdUsuarioLog()
        {
            return 1;
        }

        public string ObterNomeUsuarioLog()
        {
            return "";
        }

        public string ObterStringConexao()
        {
            return _strConexao;
        }
    }
}
