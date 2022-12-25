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
    public partial class Form4 : Form
    {
        Form1 form;
        public Form4(Form1 f)
        {
            InitializeComponent();
            form = f;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (int i in Enum.GetValues(typeof(Car.Marka)))
                comboBox1.Items.Add((Car.Marka)i);
            foreach (int i in Enum.GetValues(typeof(Car.TypeControl)))
                comboBox2.Items.Add((Car.TypeControl)i);
            foreach (int i in Enum.GetValues(typeof(Car.TypeFuel)))
                comboBox3.Items.Add((Car.TypeFuel)i);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1 && textBox1.Text != "" && comboBox2.SelectedIndex > -1 && comboBox3.SelectedIndex > -1 && double.TryParse(textBox2.Text, out double t2) && double.TryParse(textBox3.Text, out double t3) && double.TryParse(textBox4.Text, out double t4) && double.TryParse(textBox5.Text, out double t5) && int.TryParse(textBox6.Text, out int t6))
            {
                if (t5 > t4)
                {
                    Data.shops[form.comboBox1.SelectedIndex].BuyCar(new Car(comboBox1.SelectedItem.ToString(), textBox1.Text, comboBox2.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), t2, t3, t4, t5), t6);
                    this.Close();
                }
                else
                    MessageBox.Show("Вартість продажу для клієнтів повинна бути більшою ніж для магазину");
            }
            else
                MessageBox.Show("Некорректно");
  
        }
    }
}
