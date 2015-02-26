namespace Bludiste
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
            this.krPlocha = new System.Windows.Forms.Panel();
            this.bGenerujBludiste = new System.Windows.Forms.Button();
            this.zadavaciPanel = new System.Windows.Forms.Panel();
            this.bResetBludiste = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbVyska = new System.Windows.Forms.TextBox();
            this.tbSirka = new System.Windows.Forms.TextBox();
            this.zadavaciPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // krPlocha
            // 
            this.krPlocha.Location = new System.Drawing.Point(218, 12);
            this.krPlocha.Name = "krPlocha";
            this.krPlocha.Size = new System.Drawing.Size(642, 369);
            this.krPlocha.TabIndex = 0;
            this.krPlocha.Paint += new System.Windows.Forms.PaintEventHandler(this.krPlocha_Paint);
            // 
            // bGenerujBludiste
            // 
            this.bGenerujBludiste.Location = new System.Drawing.Point(3, 80);
            this.bGenerujBludiste.Name = "bGenerujBludiste";
            this.bGenerujBludiste.Size = new System.Drawing.Size(112, 45);
            this.bGenerujBludiste.TabIndex = 0;
            this.bGenerujBludiste.Text = "Generuj bludiště";
            this.bGenerujBludiste.UseVisualStyleBackColor = true;
            this.bGenerujBludiste.Click += new System.EventHandler(this.bGenerujBludiste_Click);
            // 
            // zadavaciPanel
            // 
            this.zadavaciPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.zadavaciPanel.Controls.Add(this.bResetBludiste);
            this.zadavaciPanel.Controls.Add(this.label3);
            this.zadavaciPanel.Controls.Add(this.label2);
            this.zadavaciPanel.Controls.Add(this.label1);
            this.zadavaciPanel.Controls.Add(this.tbVyska);
            this.zadavaciPanel.Controls.Add(this.tbSirka);
            this.zadavaciPanel.Controls.Add(this.bGenerujBludiste);
            this.zadavaciPanel.Location = new System.Drawing.Point(12, 12);
            this.zadavaciPanel.Name = "zadavaciPanel";
            this.zadavaciPanel.Size = new System.Drawing.Size(200, 369);
            this.zadavaciPanel.TabIndex = 1;
            // 
            // bResetBludiste
            // 
            this.bResetBludiste.Location = new System.Drawing.Point(3, 152);
            this.bResetBludiste.Name = "bResetBludiste";
            this.bResetBludiste.Size = new System.Drawing.Size(112, 45);
            this.bResetBludiste.TabIndex = 6;
            this.bResetBludiste.Text = "Reset bludiště";
            this.bResetBludiste.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "výška";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "šířka";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Rozměry bludiště:";
            // 
            // tbVyska
            // 
            this.tbVyska.Location = new System.Drawing.Point(50, 54);
            this.tbVyska.Name = "tbVyska";
            this.tbVyska.Size = new System.Drawing.Size(100, 20);
            this.tbVyska.TabIndex = 2;
            this.tbVyska.Text = "5";
            // 
            // tbSirka
            // 
            this.tbSirka.Location = new System.Drawing.Point(50, 28);
            this.tbSirka.Name = "tbSirka";
            this.tbSirka.Size = new System.Drawing.Size(100, 20);
            this.tbSirka.TabIndex = 1;
            this.tbSirka.Text = "5";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 393);
            this.Controls.Add(this.zadavaciPanel);
            this.Controls.Add(this.krPlocha);
            this.Name = "Form1";
            this.Text = "Bludiště";
            this.zadavaciPanel.ResumeLayout(false);
            this.zadavaciPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel krPlocha;
        private System.Windows.Forms.Button bGenerujBludiste;
        private System.Windows.Forms.Panel zadavaciPanel;
        private System.Windows.Forms.TextBox tbVyska;
        private System.Windows.Forms.TextBox tbSirka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bResetBludiste;
    }
}

