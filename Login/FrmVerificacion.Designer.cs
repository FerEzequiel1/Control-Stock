using Control_de_ingresos;

namespace Login
{
    partial class FrmVerificacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmVerificacion));
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtContraseña = new TextBox();
            btnIngresar = new Button();
            btnCancelar = new Button();
            checkContraseña = new CheckBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 20);
            label1.Name = "label1";
            label1.Size = new Size(97, 15);
            label1.TabIndex = 0;
            label1.Text = "Ingrese su correo";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 75);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 1;
            label2.Text = "Ingrese su contraeña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(69, 38);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(211, 23);
            txtUsuario.TabIndex = 2;
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(69, 95);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.Size = new Size(211, 23);
            txtContraseña.TabIndex = 3;
            // 
            // btnIngresar
            // 
            btnIngresar.DialogResult = DialogResult.OK;
            btnIngresar.Location = new Point(69, 132);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(211, 36);
            btnIngresar.TabIndex = 4;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(69, 174);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(211, 36);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // checkContraseña
            // 
            checkContraseña.Appearance = Appearance.Button;
            checkContraseña.AutoSize = true;
            checkContraseña.FlatStyle = FlatStyle.Flat;
            checkContraseña.Image = (Image)resources.GetObject("checkContraseña.Image");
            checkContraseña.Location = new Point(286, 96);
            checkContraseña.MaximumSize = new Size(20, 22);
            checkContraseña.MinimumSize = new Size(20, 22);
            checkContraseña.Name = "checkContraseña";
            checkContraseña.Size = new Size(20, 22);
            checkContraseña.TabIndex = 6;
            checkContraseña.UseVisualStyleBackColor = true;
            checkContraseña.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // FrmVerificacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(345, 227);
            Controls.Add(checkContraseña);
            Controls.Add(btnCancelar);
            Controls.Add(btnIngresar);
            Controls.Add(txtContraseña);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(label1);
            MaximumSize = new Size(361, 266);
            Name = "FrmVerificacion";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtUsuario;
        private TextBox txtContraseña;
        private Button btnIngresar;
        private Button btnCancelar;
        private CheckBox checkContraseña;
    }
}