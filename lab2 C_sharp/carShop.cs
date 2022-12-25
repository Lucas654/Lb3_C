using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_C_sharp
{
    class carShop
    {

        public int numberOfEmloyeers { get; set; }

        public string nameOfShop;
        public string shopAdress;
        public double averageIncomeShop;
        public double expenses;
        public double numberOfNames;
        public double IncomeEmpls;

        public List<Car> cars = new List<Car>();
        public Dictionary<string, Worker> people = new Dictionary<string, Worker>();
        public int numOfCars { get { return cars.Count; } set { } }
        public int noe { get { return people.Count; } set { } }



        public carShop(int numofdep, int numofempl, string nameshop, string adress, double numberNames, double avgincomeshop, double expns, double incomeEmpl)
        {
            numOfCars = numofdep;
            noe = numofempl;
            nameOfShop = nameshop;
            shopAdress = adress;
            averageIncomeShop = avgincomeshop;
            expenses = expns;
            numberOfNames = numberNames;
            IncomeEmpls = incomeEmpl;
        }


        public void AddWorker(Worker person)
        {
            people.Add(person.INN, person);
        }

        public bool FireWorker(string kod)
        {
            if (people.ContainsKey(kod))
            {
                people.Remove(kod);
                return true;
            }
            else
                return false;


        }
        public bool DeleteAllWorker()
        {
            if (people.Count > 0)
            {
                people.Clear();
                return true;
            }
            else
                return false;
            
        }



        public double nalog()
        {
            var nal = ((averageIncomeShop * 12) * 0.18) - (((averageIncomeShop * 12) - expenses - 1240) * 0.18);
            return nal;
        }

        public void BuyCar(Car car, int count)
        {
            for (int i = 0; i < count; i++)
            {
                cars.Add(car);
                expenses += car.CostForShop;
            }

        }

        public bool SaleCar(string name, string marka)
        {
           for (int i=0; i<cars.Count;i++)
            {
                if (cars[i].MarkaM == marka)
                {
                    if (cars[i].nameCar == name)
                    {
                        averageIncomeShop += cars[i].Cost;
                        cars.Remove(cars[i]);
                        return true;
                    }
                }
            }
            return false;
        }


        public override string ToString()
        {
            return String.Format("Назва заводу: {0},Адреса: {1},Кількість машин: {2},Кількість співробітників: {3},Середній дохід магазину за місяць: {4},Загальна заробітна плата співробітників: {5},Загальні витрати на купівлю товарів: {6},Кількість найменувань товарів: {7}",
                this.nameOfShop, this.shopAdress, this.numOfCars, this.noe, this.averageIncomeShop, this.IncomeEmpls, this.expenses, this.numberOfNames);
        }



    }
}
