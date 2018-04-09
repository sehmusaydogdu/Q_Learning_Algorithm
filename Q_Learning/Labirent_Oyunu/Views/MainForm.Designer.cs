namespace Labirent_Oyunu
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CreateButttons = new System.Windows.Forms.Button();
            this.ClearButtons = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Start_Click = new System.Windows.Forms.Button();
            this.btnEngelEkle = new System.Windows.Forms.Button();
            this.btnBitis = new System.Windows.Forms.Button();
            this.btnBaslangic = new System.Windows.Forms.Button();
            this.txtMatris = new System.Windows.Forms.TextBox();
            this.panel = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CreateButttons);
            this.groupBox1.Controls.Add(this.ClearButtons);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtMatris);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 409);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seçenekler";
            // 
            // CreateButttons
            // 
            this.CreateButttons.BackColor = System.Drawing.Color.White;
            this.CreateButttons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.CreateButttons.Location = new System.Drawing.Point(12, 66);
            this.CreateButttons.Name = "CreateButttons";
            this.CreateButttons.Size = new System.Drawing.Size(160, 30);
            this.CreateButttons.TabIndex = 2;
            this.CreateButttons.Text = "Alanı Oluştur";
            this.CreateButttons.UseVisualStyleBackColor = false;
            this.CreateButttons.Click += new System.EventHandler(this.CreateButttons_Click);
            // 
            // ClearButtons
            // 
            this.ClearButtons.BackColor = System.Drawing.Color.White;
            this.ClearButtons.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClearButtons.Location = new System.Drawing.Point(12, 102);
            this.ClearButtons.Name = "ClearButtons";
            this.ClearButtons.Size = new System.Drawing.Size(160, 30);
            this.ClearButtons.TabIndex = 3;
            this.ClearButtons.Text = "Temizle";
            this.ClearButtons.UseVisualStyleBackColor = false;
            this.ClearButtons.Click += new System.EventHandler(this.ClearButtons_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Start_Click);
            this.groupBox2.Controls.Add(this.btnEngelEkle);
            this.groupBox2.Controls.Add(this.btnBitis);
            this.groupBox2.Controls.Add(this.btnBaslangic);
            this.groupBox2.Location = new System.Drawing.Point(6, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(174, 252);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Talimatlar";
            // 
            // Start_Click
            // 
            this.Start_Click.BackColor = System.Drawing.Color.White;
            this.Start_Click.Enabled = false;
            this.Start_Click.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Start_Click.Location = new System.Drawing.Point(6, 194);
            this.Start_Click.Name = "Start_Click";
            this.Start_Click.Size = new System.Drawing.Size(160, 38);
            this.Start_Click.TabIndex = 5;
            this.Start_Click.Text = "Başlat";
            this.Start_Click.UseVisualStyleBackColor = false;
            this.Start_Click.Click += new System.EventHandler(this.Start_Click_Click);
            // 
            // btnEngelEkle
            // 
            this.btnEngelEkle.BackColor = System.Drawing.Color.White;
            this.btnEngelEkle.Enabled = false;
            this.btnEngelEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEngelEkle.Location = new System.Drawing.Point(6, 143);
            this.btnEngelEkle.Name = "btnEngelEkle";
            this.btnEngelEkle.Size = new System.Drawing.Size(160, 38);
            this.btnEngelEkle.TabIndex = 4;
            this.btnEngelEkle.Text = "Engelleri Ekle";
            this.btnEngelEkle.UseVisualStyleBackColor = false;
            // 
            // btnBitis
            // 
            this.btnBitis.BackColor = System.Drawing.Color.White;
            this.btnBitis.Enabled = false;
            this.btnBitis.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBitis.Location = new System.Drawing.Point(6, 92);
            this.btnBitis.Name = "btnBitis";
            this.btnBitis.Size = new System.Drawing.Size(160, 38);
            this.btnBitis.TabIndex = 4;
            this.btnBitis.Text = "Bitiş Noktası ";
            this.btnBitis.UseVisualStyleBackColor = false;
            // 
            // btnBaslangic
            // 
            this.btnBaslangic.BackColor = System.Drawing.Color.White;
            this.btnBaslangic.Enabled = false;
            this.btnBaslangic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBaslangic.Location = new System.Drawing.Point(6, 39);
            this.btnBaslangic.Name = "btnBaslangic";
            this.btnBaslangic.Size = new System.Drawing.Size(160, 38);
            this.btnBaslangic.TabIndex = 3;
            this.btnBaslangic.Text = "Başlangıç Noktası ";
            this.btnBaslangic.UseVisualStyleBackColor = false;
            // 
            // txtMatris
            // 
            this.txtMatris.Location = new System.Drawing.Point(12, 36);
            this.txtMatris.Name = "txtMatris";
            this.txtMatris.Size = new System.Drawing.Size(160, 24);
            this.txtMatris.TabIndex = 5;
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(200, 20);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(10, 10);
            this.panel.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.TextBox txtMatris;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button CreateButttons;
        private System.Windows.Forms.Button Start_Click;
        private System.Windows.Forms.Button btnEngelEkle;
        private System.Windows.Forms.Button btnBitis;
        private System.Windows.Forms.Button btnBaslangic;
        private System.Windows.Forms.Button ClearButtons;
    }
}

