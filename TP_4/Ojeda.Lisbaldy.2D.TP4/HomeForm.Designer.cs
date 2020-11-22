namespace Ojeda.Lisbaldy._2D.TP4
{
    partial class HomeForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitleShopCar = new System.Windows.Forms.Label();
            this.lblTituloProductos = new System.Windows.Forms.Label();
            this.txtCantidadHome = new System.Windows.Forms.TextBox();
            this.lblCantidadHome = new System.Windows.Forms.Label();
            this.btbAgregarAlCarro = new System.Windows.Forms.Button();
            this.btnResetCar = new System.Windows.Forms.Button();
            this.btnComprarHome = new System.Windows.Forms.Button();
            this.lblSubTotalCifraHome = new System.Windows.Forms.Label();
            this.lblSubTotalHome = new System.Windows.Forms.Label();
            this.lblBienvenidoHome = new System.Windows.Forms.Label();
            this.dataGridViewCarrito = new System.Windows.Forms.DataGridView();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.menuStripHome = new System.Windows.Forms.MenuStrip();
            this.agregarProductoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.menuStripHome.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitleShopCar
            // 
            this.lblTitleShopCar.AutoSize = true;
            this.lblTitleShopCar.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleShopCar.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTitleShopCar.Location = new System.Drawing.Point(571, 72);
            this.lblTitleShopCar.Name = "lblTitleShopCar";
            this.lblTitleShopCar.Size = new System.Drawing.Size(168, 19);
            this.lblTitleShopCar.TabIndex = 26;
            this.lblTitleShopCar.Text = "Carrito de Compras";
            // 
            // lblTituloProductos
            // 
            this.lblTituloProductos.AutoSize = true;
            this.lblTituloProductos.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloProductos.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblTituloProductos.Location = new System.Drawing.Point(126, 32);
            this.lblTituloProductos.Name = "lblTituloProductos";
            this.lblTituloProductos.Size = new System.Drawing.Size(183, 19);
            this.lblTituloProductos.TabIndex = 25;
            this.lblTituloProductos.Text = "Listado de Productos";
            // 
            // txtCantidadHome
            // 
            this.txtCantidadHome.Location = new System.Drawing.Point(226, 442);
            this.txtCantidadHome.Name = "txtCantidadHome";
            this.txtCantidadHome.Size = new System.Drawing.Size(49, 20);
            this.txtCantidadHome.TabIndex = 24;
            this.txtCantidadHome.Text = "1";
            // 
            // lblCantidadHome
            // 
            this.lblCantidadHome.AutoSize = true;
            this.lblCantidadHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadHome.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblCantidadHome.Location = new System.Drawing.Point(126, 442);
            this.lblCantidadHome.Name = "lblCantidadHome";
            this.lblCantidadHome.Size = new System.Drawing.Size(81, 20);
            this.lblCantidadHome.TabIndex = 23;
            this.lblCantidadHome.Text = "Cantidad";
            // 
            // btbAgregarAlCarro
            // 
            this.btbAgregarAlCarro.BackColor = System.Drawing.Color.DarkOrange;
            this.btbAgregarAlCarro.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btbAgregarAlCarro.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btbAgregarAlCarro.Location = new System.Drawing.Point(293, 434);
            this.btbAgregarAlCarro.Name = "btbAgregarAlCarro";
            this.btbAgregarAlCarro.Size = new System.Drawing.Size(152, 35);
            this.btbAgregarAlCarro.TabIndex = 22;
            this.btbAgregarAlCarro.Text = "Agregar al carro";
            this.btbAgregarAlCarro.UseVisualStyleBackColor = false;
            this.btbAgregarAlCarro.Click += new System.EventHandler(this.btbAgregarAlCarro_Click);
            // 
            // btnResetCar
            // 
            this.btnResetCar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnResetCar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetCar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetCar.Location = new System.Drawing.Point(774, 65);
            this.btnResetCar.Name = "btnResetCar";
            this.btnResetCar.Size = new System.Drawing.Size(129, 34);
            this.btnResetCar.TabIndex = 21;
            this.btnResetCar.Text = "Resetear Carro";
            this.btnResetCar.UseVisualStyleBackColor = false;
            this.btnResetCar.Click += new System.EventHandler(this.btnResetCar_Click);
            // 
            // btnComprarHome
            // 
            this.btnComprarHome.BackColor = System.Drawing.Color.DarkOrange;
            this.btnComprarHome.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComprarHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComprarHome.Location = new System.Drawing.Point(756, 378);
            this.btnComprarHome.Name = "btnComprarHome";
            this.btnComprarHome.Size = new System.Drawing.Size(133, 45);
            this.btnComprarHome.TabIndex = 20;
            this.btnComprarHome.Text = "COMPRAR";
            this.btnComprarHome.UseVisualStyleBackColor = false;
            this.btnComprarHome.Click += new System.EventHandler(this.btnComprarHome_Click);
            // 
            // lblSubTotalCifraHome
            // 
            this.lblSubTotalCifraHome.AutoSize = true;
            this.lblSubTotalCifraHome.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotalCifraHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalCifraHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSubTotalCifraHome.Location = new System.Drawing.Point(594, 389);
            this.lblSubTotalCifraHome.Name = "lblSubTotalCifraHome";
            this.lblSubTotalCifraHome.Size = new System.Drawing.Size(44, 20);
            this.lblSubTotalCifraHome.TabIndex = 19;
            this.lblSubTotalCifraHome.Text = "0,00";
            // 
            // lblSubTotalHome
            // 
            this.lblSubTotalHome.AutoSize = true;
            this.lblSubTotalHome.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTotalHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotalHome.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSubTotalHome.Location = new System.Drawing.Point(497, 389);
            this.lblSubTotalHome.Name = "lblSubTotalHome";
            this.lblSubTotalHome.Size = new System.Drawing.Size(81, 20);
            this.lblSubTotalHome.TabIndex = 18;
            this.lblSubTotalHome.Text = "SubTotal";
            // 
            // lblBienvenidoHome
            // 
            this.lblBienvenidoHome.AutoSize = true;
            this.lblBienvenidoHome.Font = new System.Drawing.Font("Bookman Old Style", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenidoHome.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblBienvenidoHome.Location = new System.Drawing.Point(594, 32);
            this.lblBienvenidoHome.Name = "lblBienvenidoHome";
            this.lblBienvenidoHome.Size = new System.Drawing.Size(103, 19);
            this.lblBienvenidoHome.TabIndex = 16;
            this.lblBienvenidoHome.Text = "Bienvenido";
            // 
            // dataGridViewCarrito
            // 
            this.dataGridViewCarrito.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCarrito.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCarrito.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dataGridViewCarrito.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewCarrito.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCarrito.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridViewCarrito.ColumnHeadersHeight = 30;
            this.dataGridViewCarrito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle17.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCarrito.DefaultCellStyle = dataGridViewCellStyle17;
            this.dataGridViewCarrito.EnableHeadersVisualStyles = false;
            this.dataGridViewCarrito.Location = new System.Drawing.Point(479, 105);
            this.dataGridViewCarrito.Name = "dataGridViewCarrito";
            this.dataGridViewCarrito.RowHeadersVisible = false;
            this.dataGridViewCarrito.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewCarrito.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCarrito.Size = new System.Drawing.Size(424, 250);
            this.dataGridViewCarrito.TabIndex = 15;
            this.dataGridViewCarrito.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewCarrito_CellMouseDoubleClick);
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToAddRows = false;
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.AllowUserToResizeColumns = false;
            this.dataGridViewProductos.AllowUserToResizeRows = false;
            this.dataGridViewProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProductos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.dataGridViewProductos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridViewProductos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle18.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dataGridViewProductos.ColumnHeadersHeight = 30;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProductos.DefaultCellStyle = dataGridViewCellStyle19;
            this.dataGridViewProductos.EnableHeadersVisualStyles = false;
            this.dataGridViewProductos.GridColor = System.Drawing.Color.Gray;
            this.dataGridViewProductos.Location = new System.Drawing.Point(12, 54);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridViewProductos.RowHeadersVisible = false;
            this.dataGridViewProductos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridViewProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProductos.Size = new System.Drawing.Size(446, 374);
            this.dataGridViewProductos.TabIndex = 14;
            this.dataGridViewProductos.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProductos_CellMouseClick);
            this.dataGridViewProductos.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewProductos_CellMouseDoubleClick);
            // 
            // menuStripHome
            // 
            this.menuStripHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStripHome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripHome.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarProductoToolStripMenuItem});
            this.menuStripHome.Location = new System.Drawing.Point(0, 0);
            this.menuStripHome.Name = "menuStripHome";
            this.menuStripHome.Size = new System.Drawing.Size(918, 24);
            this.menuStripHome.TabIndex = 27;
            this.menuStripHome.Text = "menuStrip";
            // 
            // agregarProductoToolStripMenuItem
            // 
            this.agregarProductoToolStripMenuItem.ForeColor = System.Drawing.Color.DarkOrange;
            this.agregarProductoToolStripMenuItem.Name = "agregarProductoToolStripMenuItem";
            this.agregarProductoToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.agregarProductoToolStripMenuItem.Text = "Agregar Producto";
            this.agregarProductoToolStripMenuItem.Click += new System.EventHandler(this.agregarProductoToolStripMenuItem_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(918, 481);
            this.Controls.Add(this.lblTitleShopCar);
            this.Controls.Add(this.lblTituloProductos);
            this.Controls.Add(this.txtCantidadHome);
            this.Controls.Add(this.lblCantidadHome);
            this.Controls.Add(this.btbAgregarAlCarro);
            this.Controls.Add(this.btnResetCar);
            this.Controls.Add(this.btnComprarHome);
            this.Controls.Add(this.lblSubTotalCifraHome);
            this.Controls.Add(this.lblSubTotalHome);
            this.Controls.Add(this.lblBienvenidoHome);
            this.Controls.Add(this.dataGridViewCarrito);
            this.Controls.Add(this.dataGridViewProductos);
            this.Controls.Add(this.menuStripHome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStripHome;
            this.MaximizeBox = false;
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lisbaldy.Ojeda.2D.TP4";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.menuStripHome.ResumeLayout(false);
            this.menuStripHome.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitleShopCar;
        private System.Windows.Forms.Label lblTituloProductos;
        private System.Windows.Forms.TextBox txtCantidadHome;
        private System.Windows.Forms.Label lblCantidadHome;
        private System.Windows.Forms.Button btbAgregarAlCarro;
        private System.Windows.Forms.Button btnResetCar;
        private System.Windows.Forms.Button btnComprarHome;
        private System.Windows.Forms.Label lblSubTotalCifraHome;
        private System.Windows.Forms.Label lblSubTotalHome;
        private System.Windows.Forms.Label lblBienvenidoHome;
        private System.Windows.Forms.DataGridView dataGridViewCarrito;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.MenuStrip menuStripHome;
        private System.Windows.Forms.ToolStripMenuItem agregarProductoToolStripMenuItem;
    }
}

