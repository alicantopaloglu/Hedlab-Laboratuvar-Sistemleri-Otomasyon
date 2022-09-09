namespace SC_Stok_Takip
{
    partial class KullaniciGirisPaneli
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
            this.TextSifre = new System.Windows.Forms.TextBox();
            this.TextID = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.TextYetki = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextSifre
            // 
            this.TextSifre.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TextSifre.Location = new System.Drawing.Point(164, 75);
            this.TextSifre.Margin = new System.Windows.Forms.Padding(2);
            this.TextSifre.Name = "TextSifre";
            this.TextSifre.Size = new System.Drawing.Size(116, 24);
            this.TextSifre.TabIndex = 24;
            this.TextSifre.UseSystemPasswordChar = true;
            // 
            // TextID
            // 
            this.TextID.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TextID.Location = new System.Drawing.Point(164, 25);
            this.TextID.Margin = new System.Windows.Forms.Padding(2);
            this.TextID.Name = "TextID";
            this.TextID.Size = new System.Drawing.Size(116, 24);
            this.TextID.TabIndex = 23;
            this.TextID.TextChanged += new System.EventHandler(this.TextID_TextChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label20.Location = new System.Drawing.Point(90, 78);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 17);
            this.label20.TabIndex = 22;
            this.label20.Text = "ŞİFRE :";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label19.Location = new System.Drawing.Point(28, 28);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 17);
            this.label19.TabIndex = 21;
            this.label19.Text = "KULLANICI ID :";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(164, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 43);
            this.button1.TabIndex = 25;
            this.button1.Text = "GİRİŞ YAP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // TextYetki
            // 
            this.TextYetki.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TextYetki.Location = new System.Drawing.Point(311, 25);
            this.TextYetki.Margin = new System.Windows.Forms.Padding(2);
            this.TextYetki.Name = "TextYetki";
            this.TextYetki.Size = new System.Drawing.Size(116, 24);
            this.TextYetki.TabIndex = 26;
            this.TextYetki.Visible = false;
            // 
            // ID
            // 
            this.ID.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ID.Location = new System.Drawing.Point(311, 71);
            this.ID.Margin = new System.Windows.Forms.Padding(2);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(116, 24);
            this.ID.TabIndex = 27;
            this.ID.Visible = false;
            // 
            // KullaniciGirisPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 195);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.TextYetki);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextSifre);
            this.Controls.Add(this.TextID);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Name = "KullaniciGirisPaneli";
            this.Text = "KullaniciGirisPaneli";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextSifre;
        private System.Windows.Forms.TextBox TextID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TextYetki;
        private System.Windows.Forms.TextBox ID;
    }
}