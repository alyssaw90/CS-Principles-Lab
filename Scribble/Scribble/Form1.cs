using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scribble
{
    public partial class Form1 : Form
    {
        List<Stroke> strokes = new List<Stroke>();
        Stack<Stroke> redo = new Stack<Stroke>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            foreach (Stroke s in strokes)
            {
                PaintRectangles(s, e.Graphics);
            }
            
        }

        void PaintRectangles(Stroke s, Graphics g)
        {
            foreach (Point point in s.points)
            {
                g.DrawEllipse(Pens.Green, point.X, point.Y, 50, 50);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.None && strokes.Count > 0)
            {
                strokes[strokes.Count - 1].points.Add(e.Location);
                redo.Clear();
                Invalidate();
            }
        }
       
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.Z)
            {
                Undo();
            }
            else if(e.Control && e.KeyCode == Keys.Y)
            {
                Redo();
            }
        }
       
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            strokes.Add(new Stroke());
            Form1_MouseMove(sender, e);
        }

        void Undo()
        {
            if (strokes.Count > 0)
            {
                redo.Push(strokes[strokes.Count - 1]);
                strokes.RemoveAt(strokes.Count - 1);
                Invalidate();
            }
        }

        void Redo()
        {
            if (redo.Count > 0)
            {
                strokes.Add(redo.Pop());
                Invalidate();
            }
        }
    }
}
