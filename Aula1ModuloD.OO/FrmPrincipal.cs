using Aspose.Cells;
using Aula1ModuloD.OO.Entidades;
using System;
using System.Windows.Forms;

namespace Aula1ModuloD.OO
{
    public partial class FrmPrincipal : Form
    {
        // criando uma variavel do tipo conta
        Conta conta = new Conta();

        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // encapsular as propriedades
            // criar instancia de cliente
            var clienteTeste = new Cliente();
            clienteTeste.Cpf = "015.527.640-95";
            clienteTeste.Rg = "6096800617";
            clienteTeste.Endereco = null;

            // criar instancia de endereco
            var endereco = new Endereco();
            endereco.Logradouro = "Rua Teste";
            endereco.Bairro = "Bairro Teste";

            // agregação de dados de endereco do cliente
            clienteTeste.Endereco = endereco;

            // agregação de dados de cliente da conta
            conta.Titular = clienteTeste;

            // chamando o método depositar do objeto conta
            conta.Depositar(0.01);
            // chamando o método Ativar
            conta.Ativar(true);

            // setei o texto do lblSaldo com o R$ + o saldo da conta
            lblSaldo.Text = $"R$ " + conta.ObterSaldo().ToString("F2");

            lblCPF.Text = "CPF: " + conta.Titular.Cpf;
            lblRG.Text = "RG: " + conta.Titular.Rg;
            lblLogradouro.Text = "Logradouro: " + conta.Titular.Endereco.Logradouro;
            lblBairro.Text = "Bairro: " + conta.Titular.Endereco.Bairro;
        }

        private void lblSaldo_Click(object sender, EventArgs e)
        {

        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDepositar_Click(object sender, EventArgs e)
        {
            // chamada do metodo Depositar do objeto conta
            conta.Depositar(10);
            
            // atualiza o saldo na tela 
            lblSaldo.Text = "R$ " + conta.ObterSaldo().ToString("F2");
        }

        private void btnSacar_Click(object sender, EventArgs e)
        {
            // chamada do metodo Sacar do objeto conta
            // passando por parametro o valor do saque
            var saqueOk = conta.Sacar(10);

            if (!saqueOk)
            {
                MessageBox.Show("Saldo insuficiente!");
            }

            // atualiza o saldo do label da tela 
            lblSaldo.Text = "R$ " + conta.ObterSaldo().ToString("F2");

            GerarExcel();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GerarExcel();
        }

        private void GerarExcel()
        {
            // Instanciar um objeto Workbook que representa o arquivo do Excel.
            Workbook wb = new Workbook();

            // Quando você cria uma nova pasta de trabalho, uma "Planilha1" padrão é adicionada à pasta de trabalho.
            Worksheet sheet = wb.Worksheets[0];

            // Acesse a célula "A1" na planilha.
            Cell cell = sheet.Cells["A1"];

            // Insira o "Olá Mundo!" texto na célula "A1".
            cell.PutValue("Hello World!");

            // Salve o Excel como arquivo .xlsx.
            wb.Save("Excel.xlsx", SaveFormat.Xlsx);
        }
    }
}
