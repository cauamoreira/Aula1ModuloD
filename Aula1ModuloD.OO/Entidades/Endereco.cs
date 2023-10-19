namespace Aula1ModuloD.OO.Entidades
{
    public class Endereco
    {
        public string Logradouro { get; set; }
        public string Bairro { get; set; }

        public Endereco()
        {
            
        }

        public Endereco(string logradouro, string bairro)
        {
            Logradouro = logradouro;
            Bairro = bairro;
        }
    }
}