namespace Aula1ModuloD.OO.Entidades
{
    public class Conta
    {
        // propriedades
        // Titular
        public Cliente Titular { get; set; }
        public string rg { get; set; }

        // Código Conta
        public string CodigoConta { get; set; }
        // Saldo
        private double Saldo { get; set; }

        private bool Ativa { get; set; }


        // ações (métodos)
        public bool Depositar(double valor)
        {
            Saldo += valor;
            return true;
        }
        
        /// <summary>
        /// Método que realiza saque na conta
        /// </summary>
        /// <param name="valor"></param>
        /// <returns> true se saque ocorreu com sucesso</returns>
        public bool Sacar(double valor)
        {
            // se tem saldo retornar true
            if(TemSaldo(valor))
            {
                // decrementa o saldo
                Saldo -= valor;
                // returna true
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        private bool TemSaldo(double valor)
        {
            if (Saldo - valor > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // visibilidade, retorno, Nome, parametro(tipo, nome)
        /// <summary>
        /// Altere a conta para ativo mudando o valor da prop Ativa
        /// </summary>
        /// <param name="ativo">true ou false</param>
        public void Ativar(bool ativo)
        {
            this.Ativa = ativo;
        }

        public double ObterSaldo() 
        { 
            return Saldo; 
        }
    }
}
