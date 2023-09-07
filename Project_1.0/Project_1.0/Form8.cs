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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox2.Visible = true;
            }
            else
            {
                textBox2.Visible = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                textBox3.Visible = true;
            }
            else
            {
                textBox3.Visible = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                textBox4.Visible = true;
            }
            else
            {
                textBox4.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                textBox5.Visible = true;
            }
            else
            {
                textBox5.Visible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                maskedTextBox1.Visible = true;
            }
            else
            {
                maskedTextBox1.Visible = false;
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                maskedTextBox2.Visible = true;
            }
            else
            {
                maskedTextBox2.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f = "where ", f1 = "", f2 = "", f3 = "", f4 = "", f5 = "", f6 = "", f7 = "";
            if (checkBox1.Checked) f1 = "Nomer like '" + textBox1.Text + "'";
            if (checkBox2.Checked) f2 = "Fam like '" + textBox2.Text + "'";
            if (checkBox3.Checked) f3 = "Ima like '" + textBox3.Text + "'";
            if (checkBox4.Checked) f4 = "Ot like '" + textBox4.Text + "'";
            if (checkBox5.Checked) f5 = "DataRojd like '" + textBox5.Text + "'";
            if (checkBox6.Checked) f6 = "Telefon like '" + maskedTextBox1.Text + "'";
            if (checkBox7.Checked) f7 = "Adress like '" + maskedTextBox2.Text + "'";


            if (f1!="")
            {
                if (f=="where ")
                {
                    f = f + f1;
                }
                else f = f + "or " + f1;
            }
           

            if (f2 != "")
            {
                if (f == "where ")
                {
                    f = f + f2;
                }
                else f = f + "or " + f2;
            }
            

            if (f3 != "")
            {
                if (f == "where ")
                {
                    f = f + f3;
                }
                else f = f + "or " + f3;
            }
            

            if (f4 != "")
            {
                if (f == "where ")
                {
                    f = f + f4;
                }
                else f = f + "or " + f4;
            }
           

            if (f5 != "")
            {
                if (f == "where ")
                {
                    f = f + f5;
                }
                else f = f + "or " + f5;
            }
            

            if (f6 != "")
            {
                if (f == "where ")
                {
                    f = f + f6;
                }
                else f = f + "or " + f6;
            }
            

            if (f7 != "")
            {
                if (f == "where ")
                {
                    f = f + f7;
                }
                else f = f + "or " + f7;
            }
           

            if (f!="where ")
            {
                dataGridView1.DataSource = ConSql.otr("Select * from Table_1 " + f );
            }
            else
            {
                dataGridView1.DataSource = ConSql.otr("Select * from Table_1");
            }
           

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form8_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ConSql.otr("Select * from Table_1");
        }

        private void Form8_FormClosing(object sender, FormClosingEventArgs e)
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
