namespace Aplicacion
{
    partial class FrmEliminar
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
            groupBox1 = new GroupBox();
            lsBProductos = new ListBox();
            btnEliminar = new Button();
            button1 = new Button();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lsBProductos);
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1150, 356);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Seleccionar un producto";
            // 
            // lsBProductos
            // 
            lsBProductos.FormattingEnabled = true;
            lsBProductos.ItemHeight = 15;
            lsBProductos.Location = new Point(22, 22);
            lsBProductos.Name = "lsBProductos";
            lsBProductos.Size = new Size(1109, 319);
            lsBProductos.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.HighlightText;
            btnEliminar.Location = new Point(517, 408);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(106, 41);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(12, 9);
            button1.Name = "button1";
            button1.Size = new Size(80, 25);
            button1.TabIndex = 2;
            button1.Text = "Volver";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmEliminar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 461);
            Controls.Add(button1);
            Controls.Add(btnEliminar);
            Controls.Add(groupBox1);
            Name = "FrmEliminar";
            Text = "Eliminar producto";
            Load += FrmEliminarcs_Load;
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox lsBProductos;
        private Button btnEliminar;
        private Button button1;
    }
}