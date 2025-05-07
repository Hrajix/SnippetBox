using System.Drawing.Drawing2D;
using System;
using System.Runtime.InteropServices;


namespace SnippetBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public const int WM_NCLBUTTONDOWN = 0xA1;

        private void Form1_Load(object sender, EventArgs e)
        {
            MakeFormRounded(25);

            MakeButtonRounded(button1, 20);

            MakeButtonRounded(button2, 20);

            MakeButtonRounded(button3, 20);
        }

        private void MakeFormRounded(int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90); // levý horní
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90); // pravý horní
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90); // pravý dolní
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90); // levý dolní
            path.CloseFigure();

            this.Region = new Region(path);
        }



        public void MakeButtonRounded(Button button, int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, button.Width, button.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            button.Region = new Region(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks < 2)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks < 2)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && e.Clicks < 2)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            AddSnippetCard("test1", "Lua", "desc");
        }



        private void AddSnippetCard(string name, string language, string description)
        {
            // Vytvoøí nový panel pro snippet
            Panel snippetPanel = new Panel
            {
                Width = 220,
                Height = 130,
                BackColor = Color.FromArgb(35, 35, 40), // Tmavší šedá, aby ladila s pozadím
                Margin = new Padding(10),
                Padding = new Padding(10),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            Label descriptionLabel = new Label
            {
                Width = 100,
                Height = 10,
                Text = description,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                AutoEllipsis = false // Tøi teèky, pokud je text delší než label
            };
            snippetPanel.Controls.Add(descriptionLabel);

            // Pøidá název snippetu
            Label nameLabel = new Label
            {
                Width = 100,
                Height = 30,
                Text = name,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Padding = new Padding(0)
            };
            snippetPanel.Controls.Add(nameLabel);

            // Pøidá jazyk
            Label languageLabel = new Label
            {
                Width = 100,
                Height = 30,
                Text = $"Jazyk: {language}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Top,
                Padding = new Padding(0)
            };
            snippetPanel.Controls.Add(languageLabel);

            // Pøidá hover efekt
            snippetPanel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            snippetPanel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            nameLabel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            nameLabel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            descriptionLabel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            descriptionLabel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            languageLabel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            languageLabel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            // Pøidá panel do FlowLayoutPanelu
            flowLayoutPanel1.Controls.Add(snippetPanel);
        }

        private void NameLabel_MouseEnter1(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NameLabel_MouseEnter(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
