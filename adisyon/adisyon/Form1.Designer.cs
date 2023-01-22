namespace adisyon
{
    partial class Form1
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
            this.tanımlamalarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masaTanımalarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünGrubuTanımlamalarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ürünTanımlamlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adisyonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masallarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tanımlamalarToolStripMenuItem,
            this.adisyonToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tanımlamalarToolStripMenuItem
            // 
            this.tanımlamalarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masaTanımalarıToolStripMenuItem,
            this.ürünGrubuTanımlamalarıToolStripMenuItem,
            this.ürünTanımlamlarıToolStripMenuItem});
            this.tanımlamalarToolStripMenuItem.Name = "tanımlamalarToolStripMenuItem";
            this.tanımlamalarToolStripMenuItem.Size = new System.Drawing.Size(111, 24);
            this.tanımlamalarToolStripMenuItem.Text = "tanımlamalar";
            // 
            // masaTanımalarıToolStripMenuItem
            // 
            this.masaTanımalarıToolStripMenuItem.Name = "masaTanımalarıToolStripMenuItem";
            this.masaTanımalarıToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.masaTanımalarıToolStripMenuItem.Text = "Masa Tanımaları";
            this.masaTanımalarıToolStripMenuItem.Click += new System.EventHandler(this.masaTanımalarıToolStripMenuItem_Click);
            // 
            // ürünGrubuTanımlamalarıToolStripMenuItem
            // 
            this.ürünGrubuTanımlamalarıToolStripMenuItem.Name = "ürünGrubuTanımlamalarıToolStripMenuItem";
            this.ürünGrubuTanımlamalarıToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.ürünGrubuTanımlamalarıToolStripMenuItem.Text = "Ürün Grubu Tanımlamaları";
            this.ürünGrubuTanımlamalarıToolStripMenuItem.Click += new System.EventHandler(this.ürünGrubuTanımlamalarıToolStripMenuItem_Click);
            // 
            // ürünTanımlamlarıToolStripMenuItem
            // 
            this.ürünTanımlamlarıToolStripMenuItem.Name = "ürünTanımlamlarıToolStripMenuItem";
            this.ürünTanımlamlarıToolStripMenuItem.Size = new System.Drawing.Size(264, 26);
            this.ürünTanımlamlarıToolStripMenuItem.Text = "Ürün Tanımlamları";
            this.ürünTanımlamlarıToolStripMenuItem.Click += new System.EventHandler(this.ürünTanımlamlarıToolStripMenuItem_Click);
            // 
            // adisyonToolStripMenuItem
            // 
            this.adisyonToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.masallarToolStripMenuItem});
            this.adisyonToolStripMenuItem.Name = "adisyonToolStripMenuItem";
            this.adisyonToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.adisyonToolStripMenuItem.Text = "adisyon";
            // 
            // masallarToolStripMenuItem
            // 
            this.masallarToolStripMenuItem.Name = "masallarToolStripMenuItem";
            this.masallarToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.masallarToolStripMenuItem.Text = "masallar";
            this.masallarToolStripMenuItem.Click += new System.EventHandler(this.masallarToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tanımlamalarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masaTanımalarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünGrubuTanımlamalarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ürünTanımlamlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adisyonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masallarToolStripMenuItem;
    }
}

