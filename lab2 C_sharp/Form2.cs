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
    public partial class Form2 : Form
    {
        Form1 form;
        bool check = true;
        public Form2(Form1 f)
        {
            form = f;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "")
            if (check)
            {
                Data.shops.Add(new carShop(Int32.Parse(textBox3.Text), Int32.Parse(textBox4.Text), textBox1.Text, textBox2.Text, Double.Parse(textBox8.Text), Double.Parse(textBox7.Text), Double.Parse(textBox6.Text), Double.Parse(textBox5.Text)));
                form.comboBox1.Items.Add(Data.shops[Data.shops.Count - 1].nameOfShop);
                    this.Close();
                }
            else
                MessageBox.Show("huita");
            
               
            
            
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox3.Text, out int res) || textBox3.Text == null)
                check = false;
            else
                check = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox4.Text, out int res) || textBox4.Text == null)
                check = false;
            else
                check = true;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox5.Text, out int res) || textBox5.Text == null)
                check = false;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox6.Text, out int res) || textBox6.Text == null)
                check = false;
            else
                check = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox7.Text, out int res) || textBox7.Text == null)
                check = false;
            else
                check = true;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(textBox8.Text, out int res) || textBox8.Text == null)
                check = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
