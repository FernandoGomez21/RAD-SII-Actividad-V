namespace RAD_SII_Actividad_V
{
    partial class MenuPrin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrin));
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gruposDeDescuentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItem});
            this.Menu.Location = new System.Drawing.Point(0, 0);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(800, 28);
            this.Menu.TabIndex = 2;
            this.Menu.Text = "Menu";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoriasToolStripMenuItem,
            this.clientesToolStripMenuItem1,
            this.gruposDeDescuentoToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(123, 24);
            this.clientesToolStripMenuItem.Text = "Menu de Renta";
            // 
            // categoriasToolStripMenuItem
            // 
            this.categoriasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("categoriasToolStripMenuItem.Image")));
            this.categoriasToolStripMenuItem.Name = "categoriasToolStripMenuItem";
            this.categoriasToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.categoriasToolStripMenuItem.Text = "Clientes";
            this.categoriasToolStripMenuItem.ToolTipText = "Todas las categorias de clientes";
            this.categoriasToolStripMenuItem.Click += new System.EventHandler(this.categoriasToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem1
            // 
            this.clientesToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("clientesToolStripMenuItem1.Image")));
            this.clientesToolStripMenuItem1.Name = "clientesToolStripMenuItem1";
            this.clientesToolStripMenuItem1.Size = new System.Drawing.Size(224, 26);
            this.clientesToolStripMenuItem1.Text = "Renta";
            this.clientesToolStripMenuItem1.Click += new System.EventHandler(this.clientesToolStripMenuItem1_Click);
            // 
            // gruposDeDescuentoToolStripMenuItem
            // 
            this.gruposDeDescuentoToolStripMenuItem.Name = "gruposDeDescuentoToolStripMenuItem";
            this.gruposDeDescuentoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.gruposDeDescuentoToolStripMenuItem.Text = "Peliculas";
            this.gruposDeDescuentoToolStripMenuItem.Click += new System.EventHandler(this.gruposDeDescuentoToolStripMenuItem_Click);
            // 
            // MenuPrin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Menu);
            this.Name = "MenuPrin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuPrin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gruposDeDescuentoToolStripMenuItem;
    }
}