
namespace SeyahatDefterim
{
    partial class ParolaDegistir
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.eskiParolaTextBox = new System.Windows.Forms.TextBox();
            this.yeniParolaTextBox = new System.Windows.Forms.TextBox();
            this.yeniParolaTekrarTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.captchaTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelMesaj = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(36, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Eski Parola";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(36, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yeni Parola";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(36, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yeni Parola(tekrar)";
            // 
            // eskiParolaTextBox
            // 
            this.eskiParolaTextBox.Location = new System.Drawing.Point(203, 51);
            this.eskiParolaTextBox.Multiline = true;
            this.eskiParolaTextBox.Name = "eskiParolaTextBox";
            this.eskiParolaTextBox.PasswordChar = '*';
            this.eskiParolaTextBox.Size = new System.Drawing.Size(151, 29);
            this.eskiParolaTextBox.TabIndex = 3;
            // 
            // yeniParolaTextBox
            // 
            this.yeniParolaTextBox.Location = new System.Drawing.Point(203, 108);
            this.yeniParolaTextBox.Multiline = true;
            this.yeniParolaTextBox.Name = "yeniParolaTextBox";
            this.yeniParolaTextBox.PasswordChar = '*';
            this.yeniParolaTextBox.Size = new System.Drawing.Size(151, 29);
            this.yeniParolaTextBox.TabIndex = 4;
            // 
            // yeniParolaTekrarTextBox
            // 
            this.yeniParolaTekrarTextBox.Location = new System.Drawing.Point(203, 163);
            this.yeniParolaTekrarTextBox.Multiline = true;
            this.yeniParolaTekrarTextBox.Name = "yeniParolaTekrarTextBox";
            this.yeniParolaTekrarTextBox.PasswordChar = '*';
            this.yeniParolaTekrarTextBox.Size = new System.Drawing.Size(151, 29);
            this.yeniParolaTekrarTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(110, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "label4";
            // 
            // captchaTextBox
            // 
            this.captchaTextBox.Location = new System.Drawing.Point(203, 213);
            this.captchaTextBox.Multiline = true;
            this.captchaTextBox.Name = "captchaTextBox";
            this.captchaTextBox.Size = new System.Drawing.Size(96, 29);
            this.captchaTextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 212);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(342, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(12, 10);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // labelMesaj
            // 
            this.labelMesaj.AutoSize = true;
            this.labelMesaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMesaj.ForeColor = System.Drawing.Color.DarkRed;
            this.labelMesaj.Location = new System.Drawing.Point(36, 268);
            this.labelMesaj.Name = "labelMesaj";
            this.labelMesaj.Size = new System.Drawing.Size(52, 17);
            this.labelMesaj.TabIndex = 10;
            this.labelMesaj.Text = "label5";
            // 
            // ParolaDegistir
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(493, 311);
            this.Controls.Add(this.labelMesaj);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.captchaTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.yeniParolaTekrarTextBox);
            this.Controls.Add(this.yeniParolaTextBox);
            this.Controls.Add(this.eskiParolaTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ParolaDegistir";
            this.Text = "ParolaDegistir";
            this.Load += new System.EventHandler(this.ParolaDegistir_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox eskiParolaTextBox;
        private System.Windows.Forms.TextBox yeniParolaTextBox;
        private System.Windows.Forms.TextBox yeniParolaTekrarTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox captchaTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelMesaj;
    }
}