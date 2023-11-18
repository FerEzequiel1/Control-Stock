namespace Aplicacion
{
    partial class FrmGaseosa
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
            nUDMililitros = new NumericUpDown();
            txtSabor = new TextBox();
            label6 = new Label();
            label7 = new Label();
            gpArmado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDMililitros).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(626, 273);
            btnAgregar.Click += btnAgregar_Click;
            // 
            // gpArmado
            // 
            gpArmado.Controls.Add(label7);
            gpArmado.Controls.Add(label6);
            gpArmado.Controls.Add(txtSabor);
            gpArmado.Controls.Add(nUDMililitros);
            gpArmado.Controls.SetChildIndex(txtNombre, 0);
            gpArmado.Controls.SetChildIndex(txtTipo, 0);
            gpArmado.Controls.SetChildIndex(nUDCantidad, 0);
            gpArmado.Controls.SetChildIndex(nUDPrecio, 0);
            gpArmado.Controls.SetChildIndex(cmbMarca, 0);
            gpArmado.Controls.SetChildIndex(btnAgregar, 0);
            gpArmado.Controls.SetChildIndex(nUDMililitros, 0);
            gpArmado.Controls.SetChildIndex(txtSabor, 0);
            gpArmado.Controls.SetChildIndex(label6, 0);
            gpArmado.Controls.SetChildIndex(label7, 0);
            // 
            // nUDMililitros
            // 
            nUDMililitros.DecimalPlaces = 3;
            nUDMililitros.Location = new Point(360, 164);
            nUDMililitros.Maximum = new decimal(new int[] { 3000, 0, 0, 196608 });
            nUDMililitros.Minimum = new decimal(new int[] { 500, 0, 0, 196608 });
            nUDMililitros.Name = "nUDMililitros";
            nUDMililitros.Size = new Size(120, 23);
            nUDMililitros.TabIndex = 4;
            nUDMililitros.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // txtSabor
            // 
            txtSabor.Location = new Point(565, 163);
            txtSabor.Name = "txtSabor";
            txtSabor.Size = new Size(100, 23);
            txtSabor.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(360, 145);
            label6.Name = "label6";
            label6.Size = new Size(53, 15);
            label6.TabIndex = 16;
            label6.Text = "Mililitros";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(565, 145);
            label7.Name = "label7";
            label7.Size = new Size(37, 15);
            label7.TabIndex = 17;
            label7.Text = "Sabor";
            // 
            // FrmGaseosa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 494);
            Name = "FrmGaseosa";
            Text = "Ingreso de gaseosas";
            gpArmado.ResumeLayout(false);
            gpArmado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDMililitros).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label7;
        private Label label6;
        private TextBox txtSabor;
        private NumericUpDown nUDMililitros;
    }
}