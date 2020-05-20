namespace Editor_de_Grafos
{
    partial class Form2
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirGrafoToolStripMenuItem,
            this.cerrarGrafoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirGrafoToolStripMenuItem
            // 
            this.abrirGrafoToolStripMenuItem.Name = "abrirGrafoToolStripMenuItem";
            this.abrirGrafoToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.abrirGrafoToolStripMenuItem.Text = "Abrir Grafo";
            this.abrirGrafoToolStripMenuItem.Click += new System.EventHandler(this.abrirGrafoToolStripMenuItem_Click);
            // 
            // cerrarGrafoToolStripMenuItem
            // 
            this.cerrarGrafoToolStripMenuItem.Name = "cerrarGrafoToolStripMenuItem";
            this.cerrarGrafoToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.cerrarGrafoToolStripMenuItem.Text = "Cerrar grafo";
            this.cerrarGrafoToolStripMenuItem.Click += new System.EventHandler(this.cerrarGrafoToolStripMenuItem_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form2";
            this.Text = "Form2";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarGrafoToolStripMenuItem;
    }
}