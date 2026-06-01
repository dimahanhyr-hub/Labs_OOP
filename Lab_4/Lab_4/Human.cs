using System;

namespace Lab_4
{
    public class Human : IHumanAction
    {
        private string name;
        private int age;
        private decimal salary;

        public string Name { get { return name; } set { name = value; } }
        public int Age { get { return age; } set { age = value; } }
        public decimal Salary { get { return salary; } set { salary = value; } }

        // Конструктор без параметрів
        public Human() { }

        // Конструктор з параметрами
        public Human(string name, int age, decimal salary)
        {
            Name = name;
            Age = age;
            Salary = salary;
        }

        public virtual void Work()
        {
            Console.WriteLine($"{Name} виконує базову роботу.");
        }

        public virtual void Display()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}, Зарплата: {Salary} грн");
        }
    }
}