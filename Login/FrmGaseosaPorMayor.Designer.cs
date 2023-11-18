namespace Aplicacion
{
    partial class FrmGaseosaPorMayor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label6 = new Label();
            nUDUnidades = new NumericUpDown();
            label7 = new Label();
            txtArtesanal = new TextBox();
            nUDMLL = new NumericUpDown();
            label8 = new Label();
            label9 = new Label();
            txtSabor = new TextBox();
            gpArmado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDUnidades).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDMLL).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Click += btnAgregar_Click;
            // 
            // gpArmado
            // 
            gpArmado.Controls.Add(txtSabor);
            gpArmado.Controls.Add(label9);
            gpArmado.Controls.Add(label8);
            gpArmado.Controls.Add(nUDMLL);
            gpArmado.Controls.Add(txtArtesanal);
            gpArmado.Controls.Add(label7);
            gpArmado.Controls.Add(nUDUnidades);
            gpArmado.Controls.Add(label6);
            gpArmado.Size = new Size(789, 332);
            gpArmado.Controls.SetChildIndex(txtNombre, 0);
            gpArmado.Controls.SetChildIndex(txtTipo, 0);
            gpArmado.Controls.SetChildIndex(nUDCantidad, 0);
            gpArmado.Controls.SetChildIndex(cmbMarca, 0);
            gpArmado.Controls.SetChildIndex(nUDPrecio, 0);
            gpArmado.Controls.SetChildIndex(btnAgregar, 0);
            gpArmado.Controls.SetChildIndex(label6, 0);
            gpArmado.Controls.SetChildIndex(nUDUnidades, 0);
            gpArmado.Controls.SetChildIndex(label7, 0);
            gpArmado.Controls.SetChildIndex(txtArtesanal, 0);
            gpArmado.Controls.SetChildIndex(nUDMLL, 0);
            gpArmado.Controls.SetChildIndex(label8, 0);
            gpArmado.Controls.SetChildIndex(label9, 0);
            gpArmado.Controls.SetChildIndex(txtSabor, 0);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(391, 146);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 15;
            label6.Text = "Unidades";
            // 
            // nUDUnidades
            // 
            nUDUnidades.Location = new Point(391, 164);
            nUDUnidades.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nUDUnidades.Name = "nUDUnidades";
            nUDUnidades.Size = new Size(120, 23);
            nUDUnidades.TabIndex = 16;
            nUDUnidades.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(582, 146);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 19;
            label7.Text = "Es artesanal?";
            // 
            // txtArtesanal
            // 
            txtArtesanal.Location = new Point(582, 164);
            txtArtesanal.Name = "txtArtesanal";
            txtArtesanal.Size = new Size(100, 23);
            txtArtesanal.TabIndex = 20;
            // 
            // nUDMLL
            // 
            nUDMLL.DecimalPlaces = 3;
            nUDMLL.Location = new Point(14, 245);
            nUDMLL.Maximum = new decimal(new int[] { 3000, 0, 0, 196608 });
            nUDMLL.Minimum = new decimal(new int[] { 500, 0, 0, 196608 });
            nUDMLL.Name = "nUDMLL";
            nUDMLL.Size = new Size(120, 23);
            nUDMLL.TabIndex = 21;
            nUDMLL.Value = new decimal(new int[] { 500, 0, 0, 196608 });
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 227);
            label8.Name = "label8";
            label8.Size = new Size(53, 15);
            label8.TabIndex = 22;
            label8.Text = "Mililitros";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(194, 227);
            label9.Name = "label9";
            label9.Size = new Size(37, 15);
            label9.TabIndex = 4;
            label9.Text = "Sabor";
            // 
            // txtSabor
            // 
            txtSabor.Location = new Point(192, 245);
            txtSabor.Name = "txtSabor";
            txtSabor.Size = new Size(100, 23);
            txtSabor.TabIndex = 23;
            // 
            // FrmGaseosaPorMayor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 494);
            Name = "FrmGaseosaPorMayor";
            Text = "Ingreso de gaseosas por mayor";
            gpArmado.ResumeLayout(false);
            gpArmado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDUnidades).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDMLL).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private Label label7;
        private NumericUpDown nUDUnidades;
        private TextBox txtArtesanal;
        private NumericUpDown nUDMLL;
        private Label label9;
        private Label label8;
        private TextBox txtSabor;
    }
}