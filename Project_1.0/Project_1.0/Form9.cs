using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_1._0
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public Graphics g;
        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть?", "Закрытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form1 fr1 = new Form1();
                fr1.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = listBox1.CreateGraphics();

            DataTable dt = Perexod.vernul();

            int r = dt.Rows.Count;

            Pen p = new Pen(Color.Green, 3);
            Brush[] B = new Brush[3];
            B[0] = Brushes.Navy;
            B[1] = Brushes.Purple;
            B[2] = Brushes.Red;
            Font F = new Font("Arial", 8);

            string[] norm = { "Мин", "Макс", "Рез" };
            string[] analizi = new string[r];

            int x;

            for (int i = 0; i < r; i++)
            {
                analizi[i] = dt.Rows[i][0].ToString();
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    x = Convert.ToInt32(dt.Rows[i][j].ToString());
                    g.DrawRectangle(p, 50 + i * 160 + j * 45, listBox1.Height - 60 - x, 45, x + 70);
                    g.FillRectangle(B[j - 1], 50 + i * 160 + j * 45, listBox1.Height - 60 - x, 45, x + 70);
                    g.DrawString(norm[j - 1], F, B[j - 1], 50 + i * 165 + j * 45, listBox1.Height - 80 - x);

                    if (j == 1)
                    {
                        g.DrawString(analizi[i], F, Brushes.Blue, 50 + i * 165 + j * 120, listBox1.Height - 120 - x);
                    }
                }
            }
        }
    }
}
