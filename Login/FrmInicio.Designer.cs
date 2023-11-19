namespace Aplicacion
{
    partial class FrmInicio
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
            btnEliminar = new Button();
            btnModificar = new Button();
            btnCargar = new Button();
            btnGuardar = new Button();
            groupBox2 = new GroupBox();
            btnOrdenar = new Button();
            groupBox4 = new GroupBox();
            rbPrecioTotal = new RadioButton();
            rbCantidad = new RadioButton();
            groupBox3 = new GroupBox();
            rbMayor = new RadioButton();
            rbMenor = new RadioButton();
            lstProductos = new ListBox();
            label1 = new Label();
            lblUsuario = new Label();
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            ingresarProductoToolStripMenuItem = new ToolStripMenuItem();
            gaseosaToolStripMenuItem = new ToolStripMenuItem();
            arrozToolStripMenuItem = new ToolStripMenuItem();
            salchichaToolStripMenuItem = new ToolStripMenuItem();
            milanesasToolStripMenuItem = new ToolStripMenuItem();
            historialDePersonasToolStripMenuItem = new ToolStripMenuItem();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnModificar);
            groupBox1.Controls.Add(btnCargar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(lstProductos);
            groupBox1.Location = new Point(24, 49);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1124, 416);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Productos";
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.Red;
            btnEliminar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEliminar.ForeColor = SystemColors.ButtonHighlight;
            btnEliminar.Location = new Point(578, 310);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(116, 59);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnModificar.Location = new Point(722, 310);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(116, 59);
            btnModificar.TabIndex = 10;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnCargar
            // 
            btnCargar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnCargar.Location = new Point(860, 310);
            btnCargar.Name = "btnCargar";
            btnCargar.Size = new Size(116, 57);
            btnCargar.TabIndex = 3;
            btnCargar.Text = "Cargar nuevos productos";
            btnCargar.UseVisualStyleBackColor = true;
            btnCargar.Click += btnCargar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnGuardar.Location = new Point(992, 310);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(116, 57);
            btnGuardar.TabIndex = 2;
            btnGuardar.Text = "Guardar cambios";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnOrdenar);
            groupBox2.Controls.Add(groupBox4);
            groupBox2.Controls.Add(groupBox3);
            groupBox2.Location = new Point(15, 302);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(497, 93);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ordenar por:";
            // 
            // btnOrdenar
            // 
            btnOrdenar.Location = new Point(401, 30);
            btnOrdenar.Name = "btnOrdenar";
            btnOrdenar.Size = new Size(75, 41);
            btnOrdenar.TabIndex = 2;
            btnOrdenar.Text = "Ordenar";
            btnOrdenar.UseVisualStyleBackColor = true;
            btnOrdenar.Click += btnOrdenar_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(rbPrecioTotal);
            groupBox4.Controls.Add(rbCantidad);
            groupBox4.Location = new Point(214, 8);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(168, 79);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Tipo";
            // 
            // rbPrecioTotal
            // 
            rbPrecioTotal.AutoSize = true;
            rbPrecioTotal.Location = new Point(6, 22);
            rbPrecioTotal.Name = "rbPrecioTotal";
            rbPrecioTotal.Size = new Size(85, 19);
            rbPrecioTotal.TabIndex = 0;
            rbPrecioTotal.TabStop = true;
            rbPrecioTotal.Text = "Precio total";
            rbPrecioTotal.UseVisualStyleBackColor = true;
            // 
            // rbCantidad
            // 
            rbCantidad.AutoSize = true;
            rbCantidad.Location = new Point(6, 44);
            rbCantidad.Name = "rbCantidad";
            rbCantidad.Size = new Size(73, 19);
            rbCantidad.TabIndex = 1;
            rbCantidad.TabStop = true;
            rbCantidad.Text = "Cantidad";
            rbCantidad.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(rbMayor);
            groupBox3.Controls.Add(rbMenor);
            groupBox3.Location = new Point(81, 8);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(127, 79);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Cantidad";
            // 
            // rbMayor
            // 
            rbMayor.AutoSize = true;
            rbMayor.Location = new Point(6, 22);
            rbMayor.Name = "rbMayor";
            rbMayor.Size = new Size(59, 19);
            rbMayor.TabIndex = 3;
            rbMayor.TabStop = true;
            rbMayor.Text = "Mayor";
            rbMayor.UseVisualStyleBackColor = true;
            // 
            // rbMenor
            // 
            rbMenor.AutoSize = true;
            rbMenor.Location = new Point(6, 44);
            rbMenor.Name = "rbMenor";
            rbMenor.Size = new Size(60, 19);
            rbMenor.TabIndex = 2;
            rbMenor.TabStop = true;
            rbMenor.Text = "Menor";
            rbMenor.UseVisualStyleBackColor = true;
            // 
            // lstProductos
            // 
            lstProductos.FormattingEnabled = true;
            lstProductos.ItemHeight = 15;
            lstProductos.Location = new Point(15, 22);
            lstProductos.Name = "lstProductos";
            lstProductos.Size = new Size(1093, 274);
            lstProductos.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(494, 0);
            label1.MaximumSize = new Size(0, 28);
            label1.MinimumSize = new Size(0, 28);
            label1.Name = "label1";
            label1.Size = new Size(165, 28);
            label1.TabIndex = 4;
            label1.Text = "Mayorista Trapal";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblUsuario.Location = new Point(842, 0);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(52, 21);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "label2";
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.MaximumSize = new Size(80, 25);
            menuStrip1.MinimumSize = new Size(80, 25);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(80, 25);
            menuStrip1.TabIndex = 8;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ingresarProductoToolStripMenuItem, historialDePersonasToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(62, 21);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // ingresarProductoToolStripMenuItem
            // 
            ingresarProductoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gaseosaToolStripMenuItem, arrozToolStripMenuItem, salchichaToolStripMenuItem, milanesasToolStripMenuItem });
            ingresarProductoToolStripMenuItem.Name = "ingresarProductoToolStripMenuItem";
            ingresarProductoToolStripMenuItem.Size = new Size(226, 26);
            ingresarProductoToolStripMenuItem.Text = "Ingresar producto";
            // 
            // gaseosaToolStripMenuItem
            // 
            gaseosaToolStripMenuItem.Name = "gaseosaToolStripMenuItem";
            gaseosaToolStripMenuItem.Size = new Size(222, 26);
            gaseosaToolStripMenuItem.Text = "Gaseosa";
            gaseosaToolStripMenuItem.Click += gaseosaToolStripMenuItem_Click;
            // 
            // arrozToolStripMenuItem
            // 
            arrozToolStripMenuItem.Name = "arrozToolStripMenuItem";
            arrozToolStripMenuItem.Size = new Size(222, 26);
            arrozToolStripMenuItem.Text = "Arroz";
            arrozToolStripMenuItem.Click += arrozToolStripMenuItem_Click;
            // 
            // salchichaToolStripMenuItem
            // 
            salchichaToolStripMenuItem.Name = "salchichaToolStripMenuItem";
            salchichaToolStripMenuItem.Size = new Size(222, 26);
            salchichaToolStripMenuItem.Text = "Gaseosas por mayor";
            salchichaToolStripMenuItem.Click += salchichaToolStripMenuItem_Click;
            // 
            // milanesasToolStripMenuItem
            // 
            milanesasToolStripMenuItem.Name = "milanesasToolStripMenuItem";
            milanesasToolStripMenuItem.Size = new Size(222, 26);
            milanesasToolStripMenuItem.Text = "Milanesas";
            milanesasToolStripMenuItem.Click += milanesasToolStripMenuItem_Click;
            // 
            // historialDePersonasToolStripMenuItem
            // 
            historialDePersonasToolStripMenuItem.Name = "historialDePersonasToolStripMenuItem";
            historialDePersonasToolStripMenuItem.Size = new Size(226, 26);
            historialDePersonasToolStripMenuItem.Text = "Historial de personas";
            historialDePersonasToolStripMenuItem.Click += historialDePersonasToolStripMenuItem_Click;
            // 
            // FrmInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1174, 494);
            Controls.Add(lblUsuario);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MinimumSize = new Size(1190, 533);
            Name = "FrmInicio";
            Text = "Mayorista Trapal";
            FormClosing += FrmInicio_FormClosing;
            Load += FrmInicio_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private ListBox lstProductos;
        private Label label1;
        private Label lblUsuario;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem ingresarProductoToolStripMenuItem;
        private ToolStripMenuItem gaseosaToolStripMenuItem;
        private ToolStripMenuItem arrozToolStripMenuItem;
        private ToolStripMenuItem salchichaToolStripMenuItem;
        private ToolStripMenuItem historialDePersonasToolStripMenuItem;
        private GroupBox groupBox2;
        private RadioButton rbMayor;
        private RadioButton rbMenor;
        private RadioButton rbCantidad;
        private RadioButton rbPrecioTotal;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private Button btnOrdenar;
        private Button btnGuardar;
        private Button btnCargar;
        private Button btnModificar;
        private ToolStripMenuItem milanesasToolStripMenuItem;
        private Button btnEliminar;
    }
}