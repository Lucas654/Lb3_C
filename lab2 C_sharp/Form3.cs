using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2_C_sharp
{
    public partial class Form3 : Form
    {
        Form1 form;
        public Form3(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                comboBox1.Items.Add((Worker.Education)i);
                comboBox2.Items.Add((Worker.Position)i);
            }
           

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" && textBox2.Text!="" && comboBox1.SelectedIndex>-1 && int.TryParse(textBox3.Text,out int t3) && int.TryParse(textBox4.Text,out int t4) && int.TryParse(textBox5.Text,out int t5) && int.TryParse(textBox6.Text,out int t6) && comboBox2.SelectedIndex>-1 && double.TryParse(textBox8.Text,out double t8))
            {
                if (!Data.shops[form.comboBox1.SelectedIndex].people.ContainsKey(t6.ToString()))
                {
                    Data.shops[form.comboBox1.SelectedIndex].AddWorker(new Worker(textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), new DateTime(t5, t4, t3), t6.ToString(), comboBox2.SelectedItem.ToString(), t8));
                    this.Close();
                }
                else
                    MessageBox.Show("Даний ІПН вже зарегестрований");
            }
            else
            {
                MessageBox.Show("Error");
            }    

        }
    }
}
