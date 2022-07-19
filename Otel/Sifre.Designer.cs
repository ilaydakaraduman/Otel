
namespace Otel
{
    partial class Sifre
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbxgir = new System.Windows.Forms.Button();
            this.tbxSifre = new System.Windows.Forms.TextBox();
            this.tbxKullanıcı = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.BackgroundImage = global::Otel.Properties.Resources.Giris;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.tbxgir);
            this.panel1.Controls.Add(this.tbxSifre);
            this.panel1.Controls.Add(this.tbxKullanıcı);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 367);
            this.panel1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(318, 311);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(127, 25);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Şifreyi Göster";
            this.checkBox1.UseVisualStyleBackColor = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbxgir
            // 
            this.tbxgir.BackColor = System.Drawing.Color.Transparent;
            this.tbxgir.FlatAppearance.BorderSize = 0;
            this.tbxgir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tbxgir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.tbxgir.Font = new System.Drawing.Font("Segoe Print", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.tbxgir.Location = new System.Drawing.Point(401, 260);
            this.tbxgir.Margin = new System.Windows.Forms.Padding(2);
            this.tbxgir.Name = "tbxgir";
            this.tbxgir.Size = new System.Drawing.Size(176, 47);
            this.tbxgir.TabIndex = 2;
            this.tbxgir.Text = "Giriş -->";
            this.tbxgir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.tbxgir.UseVisualStyleBackColor = false;
            this.tbxgir.Click += new System.EventHandler(this.tbxgir_Click_1);
            // 
            // tbxSifre
            // 
            this.tbxSifre.BackColor = System.Drawing.SystemColors.Menu;
            this.tbxSifre.Location = new System.Drawing.Point(218, 314);
            this.tbxSifre.Margin = new System.Windows.Forms.Padding(2);
            this.tbxSifre.Name = "tbxSifre";
            this.tbxSifre.Size = new System.Drawing.Size(96, 20);
            this.tbxSifre.TabIndex = 1;
            this.tbxSifre.Click += new System.EventHandler(this.tbxSifre_Click);
            // 
            // tbxKullanıcı
            // 
            this.tbxKullanıcı.BackColor = System.Drawing.SystemColors.Menu;
            this.errorProvider1.SetError(this.tbxKullanıcı, " İsim-Soyad büyük harflerle ve boşluklu yazılmalıdır!!!");
            this.tbxKullanıcı.Location = new System.Drawing.Point(190, 281);
            this.tbxKullanıcı.Margin = new System.Windows.Forms.Padding(2);
            this.tbxKullanıcı.Name = "tbxKullanıcı";
            this.tbxKullanıcı.Size = new System.Drawing.Size(124, 20);
            this.tbxKullanıcı.TabIndex = 0;
            // 
            // Sifre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 367);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Sifre";
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Sifre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button tbxgir;
        private System.Windows.Forms.TextBox tbxSifre;
        private System.Windows.Forms.TextBox tbxKullanıcı;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}