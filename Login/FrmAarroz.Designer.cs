namespace Aplicacion
{
    partial class FrmAarroz
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
            txtOrigen = new TextBox();
            txtProveedor = new TextBox();
            label6 = new Label();
            label7 = new Label();
            gpArmado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Click += btnAgregar_Click;
            // 
            // gpArmado
            // 
            gpArmado.Controls.Add(label7);
            gpArmado.Controls.Add(label6);
            gpArmado.Controls.Add(txtOrigen);
            gpArmado.Controls.Add(txtProveedor);
            gpArmado.Controls.SetChildIndex(txtNombre, 0);
            gpArmado.Controls.SetChildIndex(txtTipo, 0);
            gpArmado.Controls.SetChildIndex(nUDCantidad, 0);
            gpArmado.Controls.SetChildIndex(cmbMarca, 0);
            gpArmado.Controls.SetChildIndex(nUDPrecio, 0);
            gpArmado.Controls.SetChildIndex(btnAgregar, 0);
            gpArmado.Controls.SetChildIndex(txtProveedor, 0);
            gpArmado.Controls.SetChildIndex(txtOrigen, 0);
            gpArmado.Controls.SetChildIndex(label6, 0);
            gpArmado.Controls.SetChildIndex(label7, 0);
            // 
            // txtOrigen
            // 
            txtOrigen.Location = new Point(376, 164);
            txtOrigen.Name = "txtOrigen";
            txtOrigen.Size = new Size(100, 23);
            txtOrigen.TabIndex = 4;
            // 
            // txtProveedor
            // 
            txtProveedor.Location = new Point(565, 164);
            txtProveedor.Name = "txtProveedor";
            txtProveedor.Size = new Size(100, 23);
            txtProveedor.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(376, 145);
            label6.Name = "label6";
            label6.Size = new Size(43, 15);
            label6.TabIndex = 15;
            label6.Text = "Origen";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(565, 145);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 16;
            label7.Text = "Proveedor";
            // 
            // FrmAarroz
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 494);
            Name = "FrmAarroz";
            Text = "Ingreso de Aarroz";
            gpArmado.ResumeLayout(false);
            gpArmado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtOrigen;
        private TextBox txtProveedor;
        internal Label label7;
        internal Label label6;
    }
}