using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ONI_Movie_Cutter.Forms
{
    public partial class PreviewHistgramForm : Form
    {
        public PreviewHistgramForm()
        {
            InitializeComponent();
        }

        public PreviewHistgramForm(int[] histgram, Image image):this()
        {
            int x = 0;
            foreach (int point in histgram)
            {
                chart1.Series[0].Points.AddXY(x, point);
                x++;
            }
            pictureBox1.Image = image;
        }
    }
}
