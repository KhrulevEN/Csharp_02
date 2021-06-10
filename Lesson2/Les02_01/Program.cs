using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
1. Построить три класса (базовый и 2 потомка), описывающих некоторых работников с почасовой оплатой (один из потомков) и 
фиксированной оплатой (второй потомок).
а) Описать в базовом классе абстрактный метод для расчёта среднемесячной заработной платы. 
Для «повременщиков» формула для расчета такова: «среднемесячная заработная плата = 20.8 * 8 * почасовая ставка», 
для работников с фиксированной оплатой «среднемесячная заработная плата = фиксированная месячная оплата».
б) Создать на базе абстрактного класса массив сотрудников и заполнить его.
в) *Реализовать интерфейсы для возможности сортировки массива, используя Array.Sort().
г) *Создать класс, содержащий массив сотрудников, и реализовать возможность вывода данных с использованием foreach.
*/


namespace Les02_01
{
    abstract class BaseEmployee : IComparable<BaseEmployee>
    {
        protected BaseEmployee(string a_strFIO)
        {
            FIO = a_strFIO;
        }
        public abstract void Calculate();
        public string FIO { get; set; }
        public double Salary{ get; set; }

        public int CompareTo(BaseEmployee other)
        {
            //сделаем на возрастание зарплаты - если совпадает то по алфавиту
            var res = Salary.CompareTo(other.Salary);
            if (res == 0)
            {
                res = FIO.CompareTo(other.FIO);
            }
            return res;
        }

        public override string ToString()
        {
            return Salary + " " + FIO;
        }
    }

    class AgeComparer : IComparer<BaseEmployee>
    {
        //сделаем на убывание зарплаты - если совпадает то по алфавиту
        public int Compare(BaseEmployee x, BaseEmployee y)
        {
            var res = -x.Salary.CompareTo(y.Salary);
            if (res == 0)
            {
                res = x.FIO.CompareTo(y.FIO);
            }
            return res;
        }
    }

    class HourlyEmployee : BaseEmployee
    {

        public double HourlySalary { get; set; }
        public HourlyEmployee(string a_strFIO, double a_dblHourlySalary) : base(a_strFIO)
        {
            HourlySalary = a_dblHourlySalary;
        }
        public override void Calculate()
        {
            Salary = 20.8 * 8 * HourlySalary;
        }
    }

    class SalaryEmployee : BaseEmployee
    {
        public SalaryEmployee(string a_strFIO, double a_dblSalary) : base(a_strFIO)
        {
            Salary = a_dblSalary;
        }
        public override void Calculate()
        {
        }

    }


    class ListEmployee : IEnumerable, IEnumerator
    {
        private string[] _employes;

        public ListEmployee(int n, string[] a_strFIO)
        {
            _employes = new string[n];
            for (var i=0; i<n; i++)
            {
                _employes[i] = a_strFIO[i];
            }            
        }

        private int _i = -1;

        public IEnumerator GetEnumerator()
        {
            return this;
        }     

        public bool MoveNext()
        {
            if (_i == _employes.Length - 1)
            {
                Reset();
                return false;
            }
            _i++;
            return true;
        }

        public void Reset()
        {
            _i = -1;
        }

        public object Current => _employes[_i];
        
    }


    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Массив сотрудников с расчитанными зарплатами за месяц:");
            var employes = new BaseEmployee[]
            {
                new HourlyEmployee("Дмитрий", 500),
                new HourlyEmployee("Евгений", 600),
                new HourlyEmployee("Светлана", 440),
                new HourlyEmployee("Маргарита", 550),
                new SalaryEmployee("Сергей", 70000),
                new SalaryEmployee("Екатерина", 75000),
                new SalaryEmployee("Вадим", 75000),                
                new SalaryEmployee("Мария", 65000)
            };

            foreach (var emp in employes)
            {
                emp.Calculate();
                //Console.WriteLine($"{emp.FIO} - {emp.Salary}");
                Console.WriteLine(emp.ToString());
            }
            Console.ReadLine();

            Console.WriteLine("Массив сотрудников по возрастанию зарплат, если равны то по алфавиту:");
            Array.Sort(employes);
            foreach (var emp in employes)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.ReadLine();

            Console.WriteLine("Массив сотрудников по убыванию зарплат, если равны то по алфавиту:");
            Array.Sort(employes, new AgeComparer());
            foreach (var emp in employes)
            {
                Console.WriteLine(emp.ToString());
            }
            Console.ReadLine();

            Console.WriteLine("Выводим массив сотрудников через foreach:");
            string[] arrFIO =
            {
                "Иванов Иван Иванович",
                "Петров Петр Петрович",
                "Пушкин Александр Сергеевич",
                "Хрулев Евгений Николаевич"
            };

            ListEmployee employes1 = new ListEmployee(arrFIO.Length, arrFIO);
            foreach (var emp in employes1)
            {
                Console.WriteLine(emp.ToString());
            }

            Console.ReadLine();
        }
    }
}

