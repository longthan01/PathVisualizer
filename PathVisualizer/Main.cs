using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathVisualizer
{
    public partial class Main : Form
    {
        Rec ControlSource = null;
        int CurrentShapeCount = 0;
        Stack<List<Rec>> ConnectedRecs { get; set; }
        private void Create(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Rec r = new Rec();
                r.Move += r_Move;
                r.CustomMouseClick += r_CustomMouseClick;
                r.TopLevel = false;
                r.Parent = this;
                r.Value = (CurrentShapeCount++).ToString();
                this.Controls.Add(r);
                r.Show();
            }
        }
        private void ResetSource()
        {
            ControlSource = null;
        }
        private void CreateConnectedLine(bool refresh = true)
        {
            if (refresh)
            {
                Refresh();
            }
            Graphics g = this.CreateGraphics();
            for (int i = 0; i < this.Controls.Count; i++)
            {
                Control c = this.Controls[i];
                if (c is Rec)
                {
                    Rec current = c as Rec;
                    foreach (Rec from in current.InComingNodes)
                    {
                        Pen p = new Pen(Brushes.Black);
                        g.DrawLine(p, current.Location, from.Location);
                    }
                }
            }
        }
        private void CreateLine(Brush color, Point from, Point to)
        {
            Refresh();
            Graphics g = this.CreateGraphics();
            Pen p = new Pen(color);
            g.DrawLine(p, from, to);
            CreateConnectedLine(false);
        }
        private void ResetSourceOnRightClick(MouseButtons button)
        {
            if (button == System.Windows.Forms.MouseButtons.Right)
            {
                ResetSource();
                CreateConnectedLine();
            }
        }
        private void Undo_Click(object sender, EventArgs e)
        {
            if (ConnectedRecs.Count != 0)
            {
                var lastConnectedRecs = ConnectedRecs.Pop();
                lastConnectedRecs[1].InComingNodes.Remove(lastConnectedRecs[0]);
                CreateConnectedLine();
            }
        }

        public Main()
        {
            InitializeComponent();
            ConnectedRecs = new Stack<List<Rec>>();
            button1.MouseClick += button1_MouseClick;
            this.MouseMove += Main_MouseMove;
            this.MouseDown += Main_MouseDown;
            this.btnUndo.MouseClick += Undo_Click;
            this.Resize += Main_Resize;
        }
        private void Main_Resize(object sender, EventArgs e)
        {
            button1.Location = new Point(this.Size.Width - 30 - button1.Size.Width,
            button1.Location.Y);
            btnUndo.Location = new Point(this.Size.Width - 30 - btnUndo.Size.Width,
            btnUndo.Location.Y);
            chkClickConnect.Location = new Point(this.Size.Width - 30 - chkClickConnect.Size.Width,
            chkClickConnect.Location.Y);
            Refresh();
        }
        private void button1_MouseClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Create(1);
        }
        private void Main_MouseDown(object sender, MouseEventArgs e)
        {
            ResetSourceOnRightClick(e.Button);
        }
        private void Main_MouseMove(object sender, MouseEventArgs e)
        {
            if (ControlSource != null)
            {
                CreateLine(Brushes.Black, ControlSource.Location, this.PointToClient(Cursor.Position));
            }
        }
        private void r_CustomMouseClick(object sender, MouseEventArgs e)
        {
            if (!chkClickConnect.Checked) { return; }
            var source = sender as Rec;
            ResetSourceOnRightClick(e.Button);
            if (ControlSource == null)
            {
                ControlSource = source;
                source.BackColor = Color.Red;
            }
            else
            {
                if (source != ControlSource)
                {
                    source.InComingNodes.Add(ControlSource);
                    ConnectedRecs.Push(new List<Rec>() { ControlSource, source });
                    ResetSource();
                    CreateConnectedLine();
                }
            }
        }

        private void r_Move(object sender, EventArgs e)
        {
            CreateConnectedLine();
        }
    }
}
