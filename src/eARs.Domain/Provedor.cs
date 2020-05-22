namespace eARs.Domain
{
    public class Provedor
    {
        public Provedor(string nomeProvedor)
        {
            this.NomeProvedor = nomeProvedor;
        }
        protected Provedor() { }

        public string IdProvedor { get; private set; }
        public string NomeProvedor { get; private set; }

        public void SetId(string idProvedor)
        {
            this.IdProvedor = idProvedor;
        }

        public void ModificarNome(string novoNome)
        {
            this.NomeProvedor = novoNome;
        }
    }
}
