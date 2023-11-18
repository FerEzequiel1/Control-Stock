namespace Aplicacion
{
    partial class FrmMilanesas
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
            label7 = new Label();
            txtOrigenAnimal = new TextBox();
            txtNacionalidad = new TextBox();
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
            gpArmado.Controls.Add(txtNacionalidad);
            gpArmado.Controls.Add(txtOrigenAnimal);
            gpArmado.Controls.Add(label6);
            gpArmado.Controls.Add(label7);
            gpArmado.Controls.SetChildIndex(txtNombre, 0);
            gpArmado.Controls.SetChildIndex(txtTipo, 0);
            gpArmado.Controls.SetChildIndex(nUDCantidad, 0);
            gpArmado.Controls.SetChildIndex(cmbMarca, 0);
            gpArmado.Controls.SetChildIndex(nUDPrecio, 0);
            gpArmado.Controls.SetChildIndex(btnAgregar, 0);
            gpArmado.Controls.SetChildIndex(label7, 0);
            gpArmado.Controls.SetChildIndex(label6, 0);
            gpArmado.Controls.SetChildIndex(txtOrigenAnimal, 0);
            gpArmado.Controls.SetChildIndex(txtNacionalidad, 0);
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(341, 146);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 4;
            label6.Text = "Origen animal";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(565, 146);
            label7.Name = "label7";
            label7.Size = new Size(77, 15);
            label7.TabIndex = 5;
            label7.Text = "Nacionalidad";
            // 
            // txtOrigenAnimal
            // 
            txtOrigenAnimal.Location = new Point(341, 164);
            txtOrigenAnimal.Name = "txtOrigenAnimal";
            txtOrigenAnimal.Size = new Size(153, 23);
            txtOrigenAnimal.TabIndex = 15;
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(565, 164);
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(124, 23);
            txtNacionalidad.TabIndex = 16;
            // 
            // FrmMilanesas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(975, 494);
            Name = "FrmMilanesas";
            Text = "FrmMilanesas";
            gpArmado.ResumeLayout(false);
            gpArmado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nUDCantidad).EndInit();
            ((System.ComponentModel.ISupportInitialize)nUDPrecio).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label6;
        private Label label7;
        private TextBox txtNacionalidad;
        private TextBox txtOrigenAnimal;
    }
}