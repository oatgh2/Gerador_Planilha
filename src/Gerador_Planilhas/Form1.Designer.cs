namespace Gerador_Planilhas
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
      components = new System.ComponentModel.Container();
      listBox1 = new ListBox();
      label1 = new Label();
      button1 = new Button();
      button2 = new Button();
      comboBox1 = new ComboBox();
      label2 = new Label();
      label3 = new Label();
      maskedTextBox1 = new MaskedTextBox();
      timer1 = new System.Windows.Forms.Timer(components);
      button3 = new Button();
      listBox2 = new ListBox();
      label4 = new Label();
      button4 = new Button();
      button5 = new Button();
      SuspendLayout();
      // 
      // listBox1
      // 
      listBox1.FormattingEnabled = true;
      listBox1.ItemHeight = 15;
      listBox1.Location = new Point(12, 24);
      listBox1.Name = "listBox1";
      listBox1.SelectionMode = SelectionMode.MultiExtended;
      listBox1.Size = new Size(330, 244);
      listBox1.TabIndex = 0;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(12, 6);
      label1.Name = "label1";
      label1.Size = new Size(63, 15);
      label1.TabIndex = 1;
      label1.Text = "Jogadores:";
      label1.Click += label1_Click;
      // 
      // button1
      // 
      button1.Location = new Point(348, 24);
      button1.Name = "button1";
      button1.Size = new Size(176, 23);
      button1.TabIndex = 2;
      button1.Text = "Adicionar Jogadores";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // button2
      // 
      button2.Location = new Point(348, 53);
      button2.Name = "button2";
      button2.Size = new Size(176, 23);
      button2.TabIndex = 3;
      button2.Text = "Remover Jogadores";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // comboBox1
      // 
      comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
      comboBox1.FormattingEnabled = true;
      comboBox1.Location = new Point(12, 415);
      comboBox1.Name = "comboBox1";
      comboBox1.Size = new Size(137, 23);
      comboBox1.TabIndex = 4;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(12, 397);
      label2.Name = "label2";
      label2.Size = new Size(32, 15);
      label2.TabIndex = 5;
      label2.Text = "Mes:";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(155, 397);
      label3.Name = "label3";
      label3.Size = new Size(29, 15);
      label3.TabIndex = 6;
      label3.Text = "Ano";
      label3.Click += label3_Click;
      // 
      // maskedTextBox1
      // 
      maskedTextBox1.Location = new Point(155, 415);
      maskedTextBox1.Mask = "0000";
      maskedTextBox1.Name = "maskedTextBox1";
      maskedTextBox1.Size = new Size(100, 23);
      maskedTextBox1.TabIndex = 7;
      maskedTextBox1.ValidatingType = typeof(int);
      // 
      // timer1
      // 
      timer1.Interval = 250;
      timer1.Tick += timer1_Tick;
      // 
      // button3
      // 
      button3.Location = new Point(261, 414);
      button3.Name = "button3";
      button3.Size = new Size(263, 23);
      button3.TabIndex = 8;
      button3.Text = "Gerar Planilha";
      button3.UseVisualStyleBackColor = true;
      button3.Click += button3_Click;
      // 
      // listBox2
      // 
      listBox2.FormattingEnabled = true;
      listBox2.ItemHeight = 15;
      listBox2.Location = new Point(12, 289);
      listBox2.Name = "listBox2";
      listBox2.SelectionMode = SelectionMode.MultiExtended;
      listBox2.Size = new Size(330, 94);
      listBox2.TabIndex = 9;
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(12, 271);
      label4.Name = "label4";
      label4.Size = new Size(50, 15);
      label4.TabIndex = 10;
      label4.Text = "Goleiros";
      // 
      // button4
      // 
      button4.Location = new Point(348, 289);
      button4.Name = "button4";
      button4.Size = new Size(176, 23);
      button4.TabIndex = 11;
      button4.Text = "Adicionar Goleiros";
      button4.UseVisualStyleBackColor = true;
      button4.Click += button4_Click;
      // 
      // button5
      // 
      button5.Location = new Point(348, 318);
      button5.Name = "button5";
      button5.Size = new Size(176, 23);
      button5.TabIndex = 12;
      button5.Text = "Remover Goleiros";
      button5.UseVisualStyleBackColor = true;
      button5.Click += button5_Click;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(540, 454);
      Controls.Add(button5);
      Controls.Add(button4);
      Controls.Add(label4);
      Controls.Add(listBox2);
      Controls.Add(button3);
      Controls.Add(maskedTextBox1);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(comboBox1);
      Controls.Add(button2);
      Controls.Add(button1);
      Controls.Add(label1);
      Controls.Add(listBox1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      MaximizeBox = false;
      Name = "Form1";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Gerador de planilha";
      Load += Form1_Load;
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private ListBox listBox1;
    private Label label1;
    private Button button1;
    private Button button2;
    private ComboBox comboBox1;
    private Label label2;
    private Label label3;
    private MaskedTextBox maskedTextBox1;
    private System.Windows.Forms.Timer timer1;
    private Button button3;
    private ListBox listBox2;
    private Label label4;
    private Button button4;
    private Button button5;
  }
}
