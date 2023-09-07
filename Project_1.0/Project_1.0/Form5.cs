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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ConSql.Zapros("Insert into Table_3(Analiz,EdinicaIzmereniya,Min,Max)values('" + textBox1.Text + "','" + textBox2.Text + "'," + textBox3.Text + "," + textBox4.Text + ")");
                MessageBox.Show("Анализы успешно добавлены");
            }

            catch (Exception) { MessageBox.Show("Заполните все данные"); }

        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
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
    }
}

