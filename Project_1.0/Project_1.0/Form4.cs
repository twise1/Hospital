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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a = ConSql.GetData("Select Fam from Table_1 Where Nomer like '" + textBox1.Text + "'");
            string b = ConSql.GetData("Select Ima from Table_1 Where Nomer like '" + textBox1.Text + "'");
            string c = ConSql.GetData("Select Ot from Table_1 Where Nomer like '" + textBox1.Text + "'");

            if (a!=null && b!= null && c!= null)
            {
                if (MessageBox.Show("Удалить пациента " + a + " " + b + " " + c + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ConSql.Zapros("Delete from Table_1 Where Nomer like '" + textBox1.Text + "'");
                    MessageBox.Show("Пациент успешно удален");
                }
            }
            else
            {
                MessageBox.Show("Такого пациента нет");
            }
         

               
            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
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

