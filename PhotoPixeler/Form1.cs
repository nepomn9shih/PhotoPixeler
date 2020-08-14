using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhotoPixeler
{
    public partial class Form1 : Form
    {
        private List<Bitmap>_bitmaps = new List<Bitmap>(); 
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_bitmaps == null) return;
                pictureBox1.Image = _bitmaps[trackBar1.Value - 1];
            
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if( openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = null;
                _bitmaps.Clear();
                var bitmap = new Bitmap(openFileDialog1.FileName);
                RunPocessing(bitmap);
            }
        }

        private void RunPocessing(Bitmap bitmap)
        {
           
        }

        private List<Form1> GetPixels(Bitmap bitmap)
        {
            var pixels = new List<Form1>(bitmap.Width * bitmap.Height);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x <bitmap.Width; x++)
                {
                    pixels.Add(new Pixel()
                    {
                        Color = bitmap.GetPixel(x, y),
                        Point = new Point() { X = x, Y = y }
                    }); 
                }
            }
            return pixels;
        }
    }
}
