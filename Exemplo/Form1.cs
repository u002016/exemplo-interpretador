using System.Data;

namespace Exemplo;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        var interpreter = new Interpreter.InterpreterAgent<ContextoCalculo, ResultadoCalculo>(this.txbScript.Text);

        if (interpreter.Validate(out var messages))
        {
            var contexto = new ContextoCalculo(
                Convert.ToDecimal(this.txbValorFatura.Text),
                Convert.ToDecimal(this.txbValorPagoFatura.Text),
                Convert.ToDecimal(this.txbValorInvestido.Text),
                Convert.ToDecimal(this.txbValorCompras.Text));
            var result = interpreter.Execute(contexto);
            lblResult.Text = result.Ok.ToString();
        }
        else
        {
            var strMessages = string.Join(Environment.NewLine, messages.Select(m => m.Text));
            MessageBox.Show(strMessages);

        }
    }
}
