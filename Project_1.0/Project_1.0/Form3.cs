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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < Form1.N; i++)
            {
                listBox1.Items.Add(Form1.fio[i]);
                string[] FiO = new string[3];
                FiO = ConSql.FioDeterminate(listBox1.Items[i].ToString());
                listBox2.Items.Add(ConSql.GetData("Select Nomer from Table_1 Where Fam like '"+FiO[0]+"' and Ima like '"+FiO[1]+"' and Ot like '"+FiO[2]+"'"));
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = listBox1.SelectedIndex;
            listBox2.SelectedIndex = k;
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = listBox2.SelectedIndex;
            listBox1.SelectedIndex = k;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int k = 0;
            if (textBox1.Text != "")
            {

            foreach (string s in listBox1.Items)
            {
               
                    if (s.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        MessageBox.Show(listBox1.Items[k].ToString() + " - " + listBox2.Items[k].ToString());
                    }
                    k++;
            }

            }

            else
            {
                MessageBox.Show("Вы ничего не ввели");
            }


        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
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

