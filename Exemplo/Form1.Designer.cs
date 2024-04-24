namespace Exemplo;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblResult = new System.Windows.Forms.Label();
            this.txbValorFatura = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbValorPagoFatura = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbValorInvestido = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txbValorCompras = new System.Windows.Forms.TextBox();
            this.txbScript = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(608, 343);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(12, 15);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "-";
            // 
            // txbValorFatura
            // 
            this.txbValorFatura.Location = new System.Drawing.Point(110, 83);
            this.txbValorFatura.Name = "txbValorFatura";
            this.txbValorFatura.Size = new System.Drawing.Size(179, 23);
            this.txbValorFatura.TabIndex = 1;
            this.txbValorFatura.Text = "3500";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Valor Pago Fatura";
            // 
            // txbValorPagoFatura
            // 
            this.txbValorPagoFatura.Location = new System.Drawing.Point(110, 142);
            this.txbValorPagoFatura.Name = "txbValorPagoFatura";
            this.txbValorPagoFatura.Size = new System.Drawing.Size(179, 23);
            this.txbValorPagoFatura.TabIndex = 1;
            this.txbValorPagoFatura.Text = "3500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Valor Investido";
            // 
            // txbValorInvestido
            // 
            this.txbValorInvestido.Location = new System.Drawing.Point(110, 199);
            this.txbValorInvestido.Name = "txbValorInvestido";
            this.txbValorInvestido.Size = new System.Drawing.Size(179, 23);
            this.txbValorInvestido.TabIndex = 1;
            this.txbValorInvestido.Text = "150";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(97, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Valor de compras no periodo";
            // 
            // txbValorCompras
            // 
            this.txbValorCompras.Location = new System.Drawing.Point(112, 249);
            this.txbValorCompras.Name = "txbValorCompras";
            this.txbValorCompras.Size = new System.Drawing.Size(179, 23);
            this.txbValorCompras.TabIndex = 1;
            this.txbValorCompras.Text = "300";
            // 
            // txbScript
            // 
            this.txbScript.Location = new System.Drawing.Point(604, 83);
            this.txbScript.Multiline = true;
            this.txbScript.Name = "txbScript";
            this.txbScript.Size = new System.Drawing.Size(368, 205);
            this.txbScript.TabIndex = 1;
            this.txbScript.Text = resources.GetString("txbScript.Text");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(604, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Script";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(604, 307);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Verificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor da fatura";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 387);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txbScript);
            this.Controls.Add(this.txbValorCompras);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txbValorInvestido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbValorPagoFatura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbValorFatura);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblResult);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private Label lblResult;
    private TextBox txbValorFatura;
    private Label label2;
    private TextBox txbValorPagoFatura;
    private Label label3;
    private TextBox txbValorInvestido;
    private Label label4;
    private TextBox txbValorCompras;
    private TextBox txbScript;
    private Label label5;
    private Button button1;
    private Label label1;
}
