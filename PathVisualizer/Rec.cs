using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathVisualizer
{
    public partial class Rec : Form
    {
        public event MouseEventHandler CustomMouseClick;
        public List<Rec> InComingNodes { get; set; }

        public string Value
        {
            get
            {
                return this.txtValue.Text;
            }
            set
            {
                this.txtValue.Text = value;
            }
        }
        public Rec()
        {
            InitializeComponent();
            InComingNodes = new List<Rec>();
            this.Load += Form_Load;
            this.MouseDown += Form_MouseDown;
        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int WM_LBUTTONDOWN = 0x0201;
        public const int HTCAPTION = 0x2;
        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int WM_NCHITTEST = 0x84;
        private const int WM_MOUSECLICK = 0x0201;
        private const int HTCLIENT = 0x1;

        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        void Form_Load(object sender, EventArgs e)
        {
            this.MouseDown += new MouseEventHandler(Form_MouseDown);
            this.txtValue.MouseDown += Form_MouseDown;
        }

        void Form_MouseDown(object sender, MouseEventArgs e)
        {
            var p = this.PointToClient(Cursor.Position);
            if (this.CustomMouseClick != null)
                CustomMouseClick(this,
                    new MouseEventArgs(e.Button, 1, p.X, p.Y, 0));
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}
