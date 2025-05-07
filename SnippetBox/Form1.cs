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

        // Import Windows funkcí pro pøetahování okna
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        // Konstanty pro tahání formuláøe
        public const int WM_NCLBUTTONDOWN = 0xA1;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
            {
                m.Result = (IntPtr)HTCAPTION;
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MakeFormRounded(25);

            MakeButtonRounded(button1, 20);

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
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

    }
}
