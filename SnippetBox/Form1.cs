using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace SnippetBox
{
    public partial class Form1 : Form
    {
        private const string SnippetFilePath = "snippets.json";

        Snippet currentSnippet;
        bool haveSelectedSnippet = false;
        string currentSnippetName;
        Panel currentPanel;

        public Form1()
        {
            InitializeComponent();
            LoadSnippetsOnStartup();
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
            MakeButtonRounded(button4, 20);
            MakeButtonRounded(button5, 20);
        }

        private void MakeFormRounded(int radius)
        {
            Rectangle bounds = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath path = new GraphicsPath();

            path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
            path.AddArc(bounds.Right - radius, bounds.Y, radius, radius, 270, 90);
            path.AddArc(bounds.Right - radius, bounds.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - radius, radius, radius, 90, 90);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
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
            string name = textBox1.Text;

            if (File.Exists("snippets.json"))
            {
                string json = File.ReadAllText("snippets.json");
                var snippets = JsonSerializer.Deserialize<List<Snippet>>(json);
                bool exists = snippets.Any(s => s.Name == name);

                if (name == string.Empty)
                {
                    MessageBox.Show("Název snippetu nemùže být nic!", "SnippetBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (exists)
                {
                    MessageBox.Show("Snippet s tímhle názvem již existuje!", "SnippetBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            string language = comboBox1.Text;
            string description = textBox2.Text;
            string code = comboBox1.Text == "Text" ? richTextBox1.Text : fastColoredTextBox1.Text;

            Snippet snippet = new Snippet
            {
                Name = name,
                Language = language,
                Description = description,
                Code = code
            };

            AddSnippetCard(snippet);

            SaveSnippetToFile(snippet);

            textBox1.Clear();
            textBox2.Clear();
            richTextBox1.Clear();
            fastColoredTextBox1.Clear();
        }

        private void AddSnippetCard(Snippet snippet)
        {
            Panel snippetPanel = new Panel
            {
                Width = 220,
                Height = 130,
                BackColor = Color.FromArgb(35, 35, 40),
                Margin = new Padding(10),
                Padding = new Padding(10),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand,
                Tag = snippet
            };

            Label descriptionLabel = new Label
            {
                Width = 100,
                Height = 10,
                Text = snippet.Description,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(0),
                AutoEllipsis = false
            };
            snippetPanel.Controls.Add(descriptionLabel);

            Label nameLabel = new Label
            {
                Width = 100,
                Height = 30,
                Text = snippet.Name,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Padding = new Padding(0)
            };
            snippetPanel.Controls.Add(nameLabel);

            Label languageLabel = new Label
            {
                Width = 100,
                Height = 30,
                Text = $"Jazyk: {snippet.Language}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Top,
                Padding = new Padding(0)
            };
            snippetPanel.Controls.Add(languageLabel);

            void PanelClickHandler(object sender, EventArgs e)
            {
                haveSelectedSnippet = true;
                currentSnippet = snippet;
                if (snippet.Language == "Text")
                {
                    richTextBox1.Text = snippet.Code;
                    richTextBox1.Visible = true;
                    fastColoredTextBox1.Visible = false;
                }
                else
                {
                    fastColoredTextBox1.Text = snippet.Code;
                    fastColoredTextBox1.Visible = true;
                    richTextBox1.Visible = false;
                }
                textBox1.Text = snippet.Name;
                currentSnippetName = snippet.Name.ToString();
                textBox2.Text = snippet.Description;
                comboBox1.Text = snippet.Language;
                currentPanel = snippetPanel;
            }

            snippetPanel.Click += PanelClickHandler;
            nameLabel.Click += PanelClickHandler;
            languageLabel.Click += PanelClickHandler;
            descriptionLabel.Click += PanelClickHandler;

            snippetPanel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            snippetPanel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            nameLabel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            nameLabel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            descriptionLabel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            descriptionLabel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            languageLabel.MouseEnter += (s, e) => snippetPanel.BackColor = Color.FromArgb(45, 45, 50);
            languageLabel.MouseLeave += (s, e) => snippetPanel.BackColor = Color.FromArgb(35, 35, 40);

            flowLayoutPanel1.Controls.Add(snippetPanel);
        }

        private void SaveSnippetToFile(Snippet snippet)
        {
            List<Snippet> snippets = LoadSnippetsFromFile();
            snippets.Add(snippet);
            string json = JsonSerializer.Serialize(snippets, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SnippetFilePath, json);
        }

        private void LoadSnippetsOnStartup()
        {
            List<Snippet> snippets = LoadSnippetsFromFile();
            foreach (var snippet in snippets)
            {
                AddSnippetCard(snippet);
            }
        }

        private List<Snippet> LoadSnippetsFromFile()
        {
            if (File.Exists(SnippetFilePath))
            {
                string json = File.ReadAllText(SnippetFilePath);
                return JsonSerializer.Deserialize<List<Snippet>>(json) ?? new List<Snippet>();
            }
            return new List<Snippet>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Text")
            {
                fastColoredTextBox1.Visible = false;
                richTextBox1.Visible = true;
            }
            else
            {
                fastColoredTextBox1.Visible = true;
                richTextBox1.Visible = false;
            }

            if (comboBox1.Text == "LUA")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.Lua;
            }
            else if (comboBox1.Text == "C#")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            }
            else if (comboBox1.Text == "HTML")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.HTML;
            }
            else if (comboBox1.Text == "JAVASCRIPT")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JS;
            }
            else if (comboBox1.Text == "JSON")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.JSON;
            }
            else if (comboBox1.Text == "PHP")
            {
                fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.PHP;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (fastColoredTextBox1.Visible)
            {
                fastColoredTextBox1.Copy();
            }
            else
            {
                richTextBox1.Copy();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // delete tlacitko
            string name = textBox1.Text;

            if (File.Exists("snippets.json"))
            {
                string json = File.ReadAllText("snippets.json");
                var snippets = JsonSerializer.Deserialize<List<Snippet>>(json);
                bool exists = snippets.Any(s => s.Name == name);

                if (!haveSelectedSnippet)
                {
                    MessageBox.Show("Pøed smazáním musíte zvolit snippet, který chcete smazat!", "SnippetBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    if (exists)
                    {
                        if (MessageBox.Show("Jste si jistí?", "SnippetBox", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            //delete
                            snippets = snippets.Where(s => s.Name != name).ToList();
                            var newJson = JsonSerializer.Serialize(snippets, new JsonSerializerOptions { WriteIndented = true });
                            File.WriteAllText("snippets.json", newJson);

                            if (currentPanel != null)
                            {
                                flowLayoutPanel1.Controls.Remove(currentPanel);
                                currentPanel.Dispose();
                                currentPanel = null;
                                haveSelectedSnippet = false;
                                MessageBox.Show("Snippet byl úspìšnì smazán!", "SnippetBox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                flowLayoutPanel1.Refresh();
                            }
                        }
                        else
                        {
                            MessageBox.Show("smazani zruseno");
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Název v poli pro název se neshoduje s žádným snippetem!", "SnippetBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            else
            {
                MessageBox.Show("Není co mazat", "SnippetBox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }    
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.Text = "X";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.Text = string.Empty;
        }
    }
}
