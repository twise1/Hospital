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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = ConSql.GetData("Select Analiz from Table_3 Where Analiz like '" + textBox1.Text + "'");

            if (a!=null)
            {
                if (MessageBox.Show("Вы уверены, что хотите удалить данные об анализе " + a + "?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConSql.Zapros("Delete from Table_3 Where Analiz like '" + textBox1.Text + "'");
                    MessageBox.Show("Анализы успешно удалены");
                }
            }
            else
            {
                MessageBox.Show("Анализа с таким названием нет в базе данных");
            }
            
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
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
