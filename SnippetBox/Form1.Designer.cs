namespace SnippetBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            fontDialog1 = new FontDialog();
            panel1 = new Panel();
            button5 = new Button();
            label1 = new Label();
            button1 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            button3 = new Button();
            button4 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(68, 68, 68);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(803, 49);
            panel1.TabIndex = 0;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // button5
            // 
            button5.BackColor = Color.Gold;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Location = new Point(745, 14);
            button5.Name = "button5";
            button5.Size = new Size(20, 20);
            button5.TabIndex = 2;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.ForeColor = Color.White;
            label1.Location = new Point(354, 14);
            label1.Name = "label1";
            label1.Size = new Size(95, 21);
            label1.TabIndex = 1;
            label1.Text = "SnippetBox";
            label1.MouseDown += label1_MouseDown;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkRed;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button1.Location = new Point(771, 14);
            button1.Name = "button1";
            button1.Size = new Size(20, 20);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.MouseEnter += button1_MouseEnter;
            button1.MouseLeave += button1_MouseLeave;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.FromArgb(18, 18, 18);
            flowLayoutPanel1.Location = new Point(12, 55);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(3);
            flowLayoutPanel1.Size = new Size(263, 641);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(68, 68, 68);
            button2.BackgroundImageLayout = ImageLayout.None;
            button2.FlatAppearance.BorderColor = Color.FromArgb(176, 176, 176);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button2.ForeColor = Color.White;
            button2.Location = new Point(695, 644);
            button2.Name = "button2";
            button2.Size = new Size(96, 42);
            button2.TabIndex = 2;
            button2.Text = "SAVE";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(35, 35, 40);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 238);
            richTextBox1.ForeColor = Color.White;
            richTextBox1.Location = new Point(281, 84);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(510, 554);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(68, 68, 68);
            button3.BackgroundImageLayout = ImageLayout.None;
            button3.FlatAppearance.BorderColor = Color.FromArgb(176, 176, 176);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button3.ForeColor = Color.White;
            button3.Location = new Point(593, 644);
            button3.Name = "button3";
            button3.Size = new Size(96, 42);
            button3.TabIndex = 5;
            button3.Text = "COPY";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(68, 68, 68);
            button4.BackgroundImageLayout = ImageLayout.None;
            button4.FlatAppearance.BorderColor = Color.FromArgb(176, 176, 176);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 238);
            button4.ForeColor = Color.White;
            button4.Location = new Point(491, 644);
            button4.Name = "button4";
            button4.Size = new Size(96, 42);
            button4.TabIndex = 6;
            button4.Text = "DELETE";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(35, 35, 40);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBox1.ForeColor = Color.White;
            textBox1.Location = new Point(281, 55);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(127, 23);
            textBox1.TabIndex = 7;
            textBox1.Text = "Název";
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(35, 35, 40);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            textBox2.ForeColor = Color.White;
            textBox2.Location = new Point(414, 55);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(377, 23);
            textBox2.TabIndex = 8;
            textBox2.Text = "Popis";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.White;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 238);
            comboBox1.ForeColor = Color.Black;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Text", "C#", "HTML", "LUA", "JAVASCRIPT", "JSON", "PHP" });
            comboBox1.Location = new Point(298, 644);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 9;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // fastColoredTextBox1
            // 
            fastColoredTextBox1.AutoCompleteBracketsList = new char[]
    {
    '(',
    ')',
    '{',
    '}',
    '[',
    ']',
    '"',
    '"',
    '\'',
    '\''
    };
            fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;]+);\r\n";
            fastColoredTextBox1.AutoScrollMinSize = new Size(27, 14);
            fastColoredTextBox1.BackBrush = null;
            fastColoredTextBox1.BackColor = Color.FromArgb(35, 35, 40);
            fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            fastColoredTextBox1.CharHeight = 14;
            fastColoredTextBox1.CharWidth = 8;
            fastColoredTextBox1.DisabledColor = Color.FromArgb(100, 180, 180, 180);
            fastColoredTextBox1.ForeColor = Color.White;
            fastColoredTextBox1.IndentBackColor = Color.FromArgb(18, 18, 18);
            fastColoredTextBox1.IsReplaceMode = false;
            fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
            fastColoredTextBox1.LeftBracket = '(';
            fastColoredTextBox1.LeftBracket2 = '{';
            fastColoredTextBox1.Location = new Point(281, 84);
            fastColoredTextBox1.Name = "fastColoredTextBox1";
            fastColoredTextBox1.Paddings = new Padding(0);
            fastColoredTextBox1.RightBracket = ')';
            fastColoredTextBox1.RightBracket2 = '}';
            fastColoredTextBox1.SelectionColor = Color.FromArgb(60, 0, 0, 255);
            fastColoredTextBox1.ServiceColors = (FastColoredTextBoxNS.ServiceColors)resources.GetObject("fastColoredTextBox1.ServiceColors");
            fastColoredTextBox1.Size = new Size(510, 554);
            fastColoredTextBox1.TabIndex = 10;
            fastColoredTextBox1.Zoom = 100;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(18, 18, 18);
            ClientSize = new Size(803, 708);
            ControlBox = false;
            Controls.Add(fastColoredTextBox1);
            Controls.Add(comboBox1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Form1";
            Load += Form1_Load;
            MouseDown += Form1_MouseDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fastColoredTextBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontDialog fontDialog1;
        private Panel panel1;
        private Button button1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button button2;
        private RichTextBox richTextBox1;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
        private TextBox textBox2;
        private ComboBox comboBox1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private Button button5;
    }
}
