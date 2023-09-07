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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Закрыть?", "Закрытие",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
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
           try
            {
                char[] s = new char[8];
                int k = textBox1.Text.Length; int l = textBox2.Text.Length; int m = textBox3.Text.Length; int n = textBox4.Text.Length;
                s[0] = textBox1.Text[0]; s[1] = textBox1.Text[k-1]; s[2] = textBox2.Text[0]; s[3] = textBox2.Text[l-1];
                s[4] = textBox3.Text[0]; s[5] = textBox3.Text[m-1]; s[6] = textBox4.Text[0]; s[7] = textBox4.Text[n-1];

                string nomer = "";

                for (int i = 0; i < 8; i++)
                {
                    nomer += s[i];
                }


                ConSql.Zapros("Insert into Table_1(Nomer,Fam,Ima,Ot,DataRojd,Telefon,Adress)values('" + nomer + "' , '" + textBox2.Text + "' , '" + textBox1.Text + "' , '" + textBox3.Text + "' , '" + maskedTextBox1.Text + "' , '" + maskedTextBox2.Text + "' , '" + textBox4.Text + "')");
                MessageBox.Show("Пациент успешно добавлен");
            }
            catch (Exception) { MessageBox.Show("Заполните все данные"); }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
