namespace MemorizeNumber
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PanelInicio = new Panel();
            PanelJuego = new Panel();
            PanelImp = new Panel();
            button5 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button4 = new Button();
            button3 = new Button();
            label3 = new Label();
            button2 = new Button();
            PanelOptions = new Panel();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            PanelInicio.SuspendLayout();
            PanelJuego.SuspendLayout();
            PanelImp.SuspendLayout();
            PanelOptions.SuspendLayout();
            SuspendLayout();
            // 
            // PanelInicio
            // 
            PanelInicio.BackColor = Color.White;
            PanelInicio.BackgroundImageLayout = ImageLayout.None;
            PanelInicio.Controls.Add(PanelJuego);
            PanelInicio.Controls.Add(PanelOptions);
            PanelInicio.Dock = DockStyle.Fill;
            PanelInicio.Location = new Point(0, 0);
            PanelInicio.Name = "PanelInicio";
            PanelInicio.Size = new Size(1147, 619);
            PanelInicio.TabIndex = 1;
            PanelInicio.Paint += panel1_Paint;
            // 
            // PanelJuego
            // 
            PanelJuego.BackColor = Color.MintCream;
            PanelJuego.Controls.Add(PanelImp);
            PanelJuego.Controls.Add(button2);
            PanelJuego.Dock = DockStyle.Fill;
            PanelJuego.Location = new Point(0, 0);
            PanelJuego.Name = "PanelJuego";
            PanelJuego.Size = new Size(1147, 619);
            PanelJuego.TabIndex = 4;
            PanelJuego.Visible = false;
            // 
            // PanelImp
            // 
            PanelImp.Controls.Add(button5);
            PanelImp.Controls.Add(textBox2);
            PanelImp.Controls.Add(label2);
            PanelImp.Controls.Add(button4);
            PanelImp.Controls.Add(button3);
            PanelImp.Controls.Add(label3);
            PanelImp.Location = new Point(312, 65);
            PanelImp.Name = "PanelImp";
            PanelImp.Size = new Size(474, 442);
            PanelImp.TabIndex = 6;
            PanelImp.Paint += PanelImp_Paint;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 22F);
            button5.Location = new Point(0, 371);
            button5.Name = "button5";
            button5.Size = new Size(474, 68);
            button5.TabIndex = 7;
            button5.Text = "Reiniciar";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(2, 297);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(244, 39);
            textBox2.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 22F);
            label2.Location = new Point(211, 95);
            label2.Name = "label2";
            label2.Size = new Size(0, 50);
            label2.TabIndex = 4;
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 16F);
            button4.Location = new Point(252, 297);
            button4.Name = "button4";
            button4.Size = new Size(219, 47);
            button4.TabIndex = 3;
            button4.Text = "Test \U0001f937‍♂️";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 22F);
            button3.Location = new Point(2, 68);
            button3.Name = "button3";
            button3.Size = new Size(136, 77);
            button3.TabIndex = 2;
            button3.Text = "See";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(3, 177);
            label3.Name = "label3";
            label3.Size = new Size(468, 98);
            label3.TabIndex = 1;
            label3.Text = "N";
            // 
            // button2
            // 
            button2.BackColor = Color.LightCyan;
            button2.Font = new Font("Segoe UI", 12F);
            button2.Location = new Point(3, 3);
            button2.Name = "button2";
            button2.Size = new Size(127, 66);
            button2.TabIndex = 0;
            button2.Text = "Return";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // PanelOptions
            // 
            PanelOptions.BackColor = Color.WhiteSmoke;
            PanelOptions.Controls.Add(label1);
            PanelOptions.Controls.Add(textBox1);
            PanelOptions.Controls.Add(button1);
            PanelOptions.Location = new Point(163, 90);
            PanelOptions.Name = "PanelOptions";
            PanelOptions.Size = new Size(652, 445);
            PanelOptions.TabIndex = 5;
            PanelOptions.Paint += PanelOptions_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F);
            label1.Location = new Point(103, 134);
            label1.Name = "label1";
            label1.Size = new Size(147, 54);
            label1.TabIndex = 2;
            label1.Text = "Length";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 16F);
            textBox1.Location = new Point(103, 210);
            textBox1.MaximumSize = new Size(230, 40);
            textBox1.MinimumSize = new Size(170, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(230, 40);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            button1.BackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.System;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(349, 210);
            button1.MaximumSize = new Size(250, 70);
            button1.MinimumSize = new Size(120, 35);
            button1.Name = "button1";
            button1.Size = new Size(250, 46);
            button1.TabIndex = 0;
            button1.Text = "Continue";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1147, 619);
            Controls.Add(PanelInicio);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "MemorizeNumber";
            Load += Form1_Load;
            PanelInicio.ResumeLayout(false);
            PanelJuego.ResumeLayout(false);
            PanelImp.ResumeLayout(false);
            PanelImp.PerformLayout();
            PanelOptions.ResumeLayout(false);
            PanelOptions.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel PanelInicio;
        private Button button1;
        private TextBox textBox1;
        private Label label1;
        private Panel PanelJuego;
        private Button button2;
        private Label label3;
        private Button button3;
        private Button button4;
        private Label label2;
        private TextBox textBox2;
        private Panel PanelImp;
        private Button button5;
        private Panel PanelOptions;
    }
}
