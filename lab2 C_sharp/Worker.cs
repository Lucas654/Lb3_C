using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_C_sharp
{
    class Worker
    {
        public string SecondName;
        public string FirstName;
        public string Educ;
        public enum Education
        {
            None,
            Techniсal,
            Liberal,
            Financial,
            Legal
        }
        public DateTime DateTime;
        public string INN;
        public enum Position
        {
            Director,
            HR,
            SeniorSeller,
            Seller,
            Security
        }
        public string Pos;
        public double Salary;

        public Worker( string SecondName, string FirstName, string Education, DateTime dateTime,string INN,string Pos,double Salary)
        {
            this.SecondName = SecondName;
            this.FirstName = FirstName;
            this.Educ = Education;
            this.INN = INN;
            this.Pos = Pos;
            this.Salary = Salary;
            this.DateTime = dateTime;
        }


        public override string ToString()
        {
            return String.Format("Призвіще: {0},Ім'я: {1},Вища освіта: {2},Дата народження: {3},ІПН: {4},Посада:{5},Заробітня плата: {6}",
                this.SecondName, this.FirstName, this.Educ, this.DateTime.ToString("d"), this.INN, this.Pos, Salary.ToString());
        }


    }
}
