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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static string[] fio;
        public static int N;

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 fr2 = new Form2();
            fr2.Show();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4();
            this.Hide();
            fr4.Show();
        }

        private void иНПациентовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fr3 = new Form3();
            fr3.Show();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int k = checkedListBox1.SelectedIndex;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                if (i!=k)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
            }

            string[] FiO = ConSql.FioDeterminate(checkedListBox1.SelectedItem.ToString());

            dataGridView1.DataSource = ConSql.otr("Select Table_2.Analiz,Table_2.EdinicaIzmereniya,Table_2.Min,Table_2.Max, Table_2.Rez,Table_2.Data from Table_2,Table_1 Where Table_2.Kl = Table_1.Nomer and Fam like '"+FiO[0]+"' and Ima like '"+FiO[1]+"' and Ot like '"+FiO[2]+"'");

            button2.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable dt = ConSql.otr("Select * from Table_1");
            N = dt.Rows.Count;
            fio = new string[N];

            for (int i = 0; i < N; i++)
            {
                fio[i] += dt.Rows[i][1].ToString() + " " + dt.Rows[i][2].ToString() + " " + dt.Rows[i][3].ToString();
                checkedListBox1.Items.Add(fio[i]);
           
            }
        }

        private void добавитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5();
            this.Hide();
            fr5.Show();
        }

        private void ооаоитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6();
            this.Hide();
            fr6.Show();
        }

        private void заполнитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 fr7 = new Form7();
            this.Hide();
            fr7.Show();
        }

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 fr8 = new Form8();
            this.Hide();
            fr8.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();

            for (int i = 0; i < Form1.N; i++)
            {
                checkedListBox1.Items.Add(Form1.fio[i]);
            }

            string s1 = "";

            if (textBox1.Text != "")
            {
                foreach (string s in checkedListBox1.Items)
                {
                    if (s.StartsWith(textBox1.Text, StringComparison.CurrentCultureIgnoreCase))
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

                for (int i = 0; i < N; i++)
                {
                    checkedListBox1.Items.Add(fio[i]);
                }
            }
    }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] FiO = ConSql.FioDeterminate(checkedListBox1.SelectedItem.ToString());

            DataTable dt1 = ConSql.otr("Select Table_2.Analiz,Table_2.Min,Table_2.Max,Table_2.Rez from Table_2,Table_1 Where Table_2.Kl = Table_1.Nomer and Fam like '" + FiO[0] + "' and Ima like '"+FiO[1]+"'  and Ot like '" + FiO[2] + "'");

            Perexod.prinal(dt1);

            Form9 fr9 = new Form9();
            this.Hide();
            fr9.Show();

        }
    }
}
