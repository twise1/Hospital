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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
            button1.Enabled = true;
            int k = checkedListBox1.SelectedIndex;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i!=k)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < Form1.N; i++)
            {
                checkedListBox1.Items.Add(Form1.fio[i]);
            }

            DataTable dt = ConSql.otr("Select * from Table_3");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                comboBox1.Items.Add(dt.Rows[i][0]);
            }
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] FiO = new string[3];
                string nomer, EdIzm;
                double min, max;
                FiO = ConSql.FioDeterminate(checkedListBox1.Text);


                nomer = ConSql.GetData("Select Nomer from Table_1 Where Fam like '" + FiO[0] + "' and Ima like '" + FiO[1] + "' and Ot like '" + FiO[2] + "'");

                EdIzm = ConSql.GetData("Select EdinicaIzmereniya from Table_3 Where Analiz like '" + comboBox1.Text + "'");

                min = ConSql.GetData_2("Select Min from Table_3 Where Analiz like '" + comboBox1.Text + "'");

                max = ConSql.GetData_2("Select Max from Table_3 Where Analiz like '" + comboBox1.Text + "'");

                ConSql.Zapros("Insert into Table_2(Kl,Analiz,EdinicaIzmereniya,Min,Max,Rez,Data)values('" + nomer + "', '" + comboBox1.Text + "','" + EdIzm + "'," + min + "," + max + ", " + Convert.ToDouble(textBox1.Text) + " , '" + maskedTextBox1.Text + "')");
                MessageBox.Show("Данные успешно занесены в БД");
            }
            catch (Exception) { MessageBox.Show("Введите данные корректно"); }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();

            for (int i = 0; i < Form1.N; i++)
            {
                checkedListBox1.Items.Add(Form1.fio[i]);
            }

            string s1 = "";

            if (textBox2.Text != "")
            {
                foreach (string s in checkedListBox1.Items)
                {
                    if (s.StartsWith(textBox2.Text,StringComparison.CurrentCultureIgnoreCase))
                    {
                        s1 = s;
                    }
                }
                checkedListBox1.Items.Clear();
                checkedListBox1.Items.Add(s1);
            }
            else
            {
                MessageBox.Show("Вы ничего не ввели");
            }
            if (checkedListBox1.Items[0].ToString() == "")
            {
                MessageBox.Show("Такого пациента нет");

                checkedListBox1.Items.Clear();

                for (int i = 0; i < Form1.N; i++)
                {
                    checkedListBox1.Items.Add(Form1.fio[i]);
                }
            }
        }
    }
}
