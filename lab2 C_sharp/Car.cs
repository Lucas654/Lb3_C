using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_C_sharp
{
    class Car
    {
        public enum Marka
        {
            Ford,
            KIA,
            BMW,
            Mercedes,
            Audi,
            Deo,
            Lamborgini,
            Mitsubishi,
            Nissan,
            Cherry
        };
        public string nameCar;
        public string MarkaM;
        public string TC;
        public string TF;
        public enum TypeControl
        {
            Mechanic,
            Auto,
            Variable
        };
        public enum TypeFuel
        {
            gasoline,
            diesel,
            electric
        };
        public double EngineVolume;
        public double FuelConsumption;
        public double CostForShop;
        public double Cost;

        public Car(string Marka,string nameCar,string TC,string TF, double EV,double FuelC,double CostForShop,double Cost)
        {
            MarkaM = Marka;
            this.nameCar = nameCar;
            this.TC = TC;
            this.TF = TF;
            EngineVolume = EV;
            FuelConsumption = FuelC;
            this.CostForShop = CostForShop;
            this.Cost = Cost;
        }

        public override string ToString()
        {
            return String.Format("Марка: {0},Модель: {1},Тип керування: {2},Тип палива: {3},Об'єм двигуна: {4},Споживаня палива: {5},Вартість придбання для магазину: {6},Вартість продажу для клієнтів: {7}",
                this.MarkaM, this.nameCar, this.TC, this.TF, this.EngineVolume.ToString(), this.FuelConsumption.ToString(), this.CostForShop.ToString(), this.Cost.ToString());
        }

    }
}
