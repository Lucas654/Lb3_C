using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace lab2_C_sharp
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
           


        }
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (int i in Enum.GetValues(typeof(Car.Marka)))
                comboBox2.Items.Add((Car.Marka)i);
        }

        private void addShopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.ShowDialog();
            
            
            
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label5.Text = "Адреса магазину: " + Data.shops[comboBox1.SelectedIndex].shopAdress;
            label6.Text = "Кількість автомобілів: " + Data.shops[comboBox1.SelectedIndex].numOfCars;
            label7.Text = "Кількість співробітників: " + Data.shops[comboBox1.SelectedIndex].noe;
            label8.Text = "Заробітна плата співробітників: " + Data.shops[comboBox1.SelectedIndex].IncomeEmpls;
            label9.Text = "Загальні витрати на товари: " + Data.shops[comboBox1.SelectedIndex].expenses;
            label10.Text = "Середній дохід за місяць: " + Data.shops[comboBox1.SelectedIndex].averageIncomeShop;
            label11.Text = "Кількість найменувань товарів: " + Data.shops[comboBox1.SelectedIndex].numberOfNames;

            listBox1.Items.Clear();


            foreach (var worker in Data.shops[comboBox1.SelectedIndex].people)
            {
                    foreach (var output in Data.shops[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                        listBox1.Items.Add(output);
            }

            if (Data.shops[comboBox1.SelectedIndex].cars.Count > 0)
            {

                for (int i = 0; i < Data.shops[comboBox1.SelectedIndex].cars.Count; i++)
                {
                    string [] a = Data.shops[comboBox1.SelectedIndex].cars[i].ToString().Split(',');
                    listBox2.Items.AddRange(a);
                }
                    

            }


        }



            private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        

        private void добавитьРаботникаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                Form3 form3 = new Form3(this);
                form3.Show();
            }
            else
            {
                MessageBox.Show("Оберіть магазин");
            }
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            if (!Data.shops[comboBox1.SelectedIndex].FireWorker(textBox1.Text))
                MessageBox.Show("Не існує працівника за даним кодом");

        }

        private void додатиПартіюАвтоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                Form4 form4 = new Form4(this);
                form4.Show();
            }    
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex>-1)
            {
                if (Data.shops[comboBox1.SelectedIndex].SaleCar(textBox2.Text, comboBox2.SelectedItem.ToString()))
                {
                    MessageBox.Show("З покупкою");
                }
                else
                    MessageBox.Show("Даного авто немає в наявності");
                
            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void зберегтиДаніПрацівниківToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\FactoryData\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save Worker information";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var filepath = saveFileDialog1.FileName;

                if (comboBox1.SelectedIndex > -1)
                {
                    if (Data.shops[comboBox1.SelectedIndex].people.Count > 0)
                    {
                        using (var file = File.CreateText(filepath))
                        {
                            string[] output = Data.shops[comboBox1.SelectedIndex].ToString().Split(',');
                            foreach (var worker in Data.shops[comboBox1.SelectedIndex].people)
                            {
                                    foreach (var outPut in Data.shops[comboBox1.SelectedIndex].people[worker.Key].ToString().Split(','))
                                        file.WriteLine(outPut);
                            }
                        }

                    }
                }

            }



        }

        private void загрузитьДаніПрацівниківToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            { // щоб не забути закрити файл
                openFileDialog.InitialDirectory = "FactoryData\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    try
                    {
                        Dictionary<string, Worker> workersInput = new Dictionary<string, Worker>();
                        using (var file = new StreamReader(filePath))
                        {
                            for (int i = 0; i < File.ReadAllLines(filePath).Length / 6; i++)
                            {
                                string lastName = file.ReadLine();
                                string firstName = file.ReadLine();
                                string Educ = file.ReadLine();
                                string data_time = file.ReadLine();
                                string INN = file.ReadLine();
                                string Pos = file.ReadLine();
                                string Salary = file.ReadLine();
                                firstName = firstName.Split(':')[1];
                                lastName = lastName.Split(':')[1];
                                Educ = Educ.Split(':')[1];
                                data_time = data_time.Split(':')[1];
                                INN = INN.Split(':')[1];
                                Pos = Pos.Split(':')[1];
                                Salary = Salary.Split(':')[1];
                                INN = INN.Trim();

                                try
                                {
                                    long temp = uint.Parse(INN);
                                    int iterator = 0;
                                    while (temp > 0)
                                    {
                                        iterator++;
                                        temp /= 10;
                                    }
                                    if (iterator != 10)
                                    {
                                        MessageBox.Show("Індивідуальний податковий номер має складатись з 10 цифр",
                                        "Помилка введення даних",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                catch (Exception)
                                {
                                    MessageBox.Show("Індивідуальний податковий номер має складатись з 10 цифр",
                                    "Помилка введення даних",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                                    return;
                                }

                                foreach (var worker in Data.shops[comboBox1.SelectedIndex].people)
                                { // перевірка на унікальність ІПН
                                    if (INN == worker.Key)
                                    {
                                        MessageBox.Show("Однаковий індивідуальний податковий номер",
                                        "Помилка введення даних",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                                        return;
                                    }
                                }
                                string[] d = data_time.Trim().Split('.');
                                int a, b, c;
                                a = int.Parse(d[0]);
                                b = int.Parse(d[1]);
                                c = int.Parse(d[2]);
                                
                                Data.shops[comboBox1.SelectedIndex].people.Add(INN, new Worker(lastName.Trim(), firstName.Trim(), Educ.Trim(), new DateTime(c,b,a), INN.Trim(), Pos.Trim(),double.Parse(Salary.Trim())));
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка при читанні з файла",
                            "Помилка введення даних",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void зберегтиДаніАвтосалонуToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\ShopData\\";
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save shop information";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                var filepath = saveFileDialog1.FileName;

                if (comboBox1.SelectedIndex > -1)
                {
                    using (var file = File.CreateText(filepath))
                    {
                        string[] output = Data.shops[comboBox1.SelectedIndex].ToString().Split(',');
                        foreach (var item in output)
                        {
                            file.WriteLine(item);
                        }

                    }
                }

            }

        }

        private void загрузитиДаніАвтосалонуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            { // щоб не забути закрити файл
                openFileDialog.InitialDirectory = "C:\\Users\\lucaa\\source\\repos\\2lab_C_sharp — копия\\2lab_C_sharp\bin\\Debug\\FactoryData\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    try
                    {
                        using (var file = new StreamReader(filePath))
                        {

                            string name = file.ReadLine();
                            string adress = file.ReadLine();
                            string numOfCars = file.ReadLine();
                            string noe = file.ReadLine();
                            string avgin = file.ReadLine();
                            string incomeEmpl = file.ReadLine();
                            string expencess = file.ReadLine();
                            string numofnames = file.ReadLine();
                            name = name.Split(':')[1];
                            adress = adress.Split(':')[1];
                            numOfCars = numOfCars.Split(':')[1];
                            noe = noe.Split(':')[1];
                            avgin = avgin.Split(':')[1];
                            incomeEmpl = incomeEmpl.Split(':')[1];
                            expencess = expencess.Split(':')[1];
                            numofnames = numofnames.Split(':')[1];
                            name = name.Trim();
                            adress = adress.Trim();
                            numOfCars = numOfCars.Trim();
                            noe = noe.Trim();
                            avgin = avgin.Trim();
                            incomeEmpl = incomeEmpl.Trim();
                            expencess = expencess.Trim();
                            numofnames = numofnames.Trim();
                            Data.shops.Add(new carShop(int.Parse(numOfCars), int.Parse(noe), name, adress, double.Parse(numofnames), double.Parse(avgin), double.Parse(expencess), double.Parse(incomeEmpl)));
                            comboBox1.Items.Add(Data.shops[Data.shops.Count - 1].nameOfShop);



                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Помилка при читанні з файла",
                            "Помилка введення даних",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void зберегтиДаніПроАвтопаркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Stream file = saveFileDialog1.OpenFile();
                StreamWriter sw = new StreamWriter(file);

                foreach (var cars in Data.shops[comboBox1.SelectedIndex].cars)
                    sw.WriteLine(Data.shops[comboBox1.SelectedIndex].nameOfShop + " " + cars.MarkaM + " " + cars.nameCar + " " + cars.TC + " " + cars.TF + " " + cars.EngineVolume + " " + cars.FuelConsumption + " " + cars.CostForShop + " " + cars.Cost + " ");
                sw.Close();
                file.Close();


            }
        }

        private void загрузитиДаніПроАвтопаркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                string[] f = File.ReadAllLines(file);
                for (int i = 0; i < f.Length; i++)
                {
                    string[] words = f[i].Split(' ');
                    if (comboBox1.SelectedItem.ToString() == words[0])
                    {
                        Data.shops[comboBox1.SelectedIndex].cars.Add(new Car(words[1], words[2], words[3], words[4], double.Parse(words[5]), double.Parse(words[6]), double.Parse(words[7]), double.Parse(words[8])));
                    }
                    else
                    {
                        i = f.Length;
                        MessageBox.Show("автопарк не цього салону");
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex>-1)
            {
                if (Data.shops[comboBox1.SelectedIndex].DeleteAllWorker())
                    MessageBox.Show("Всі робітникі видалені");
                else
                    MessageBox.Show("Недостатня кількість робітників");
            }
           
        }
    }
}
