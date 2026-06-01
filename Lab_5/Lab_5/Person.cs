using System;

namespace Lab5_OOP
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public double BaseSalary { get; set; }
        public int BaseIQ { get; set; }

        public Person()
        {
            Name = "Невідомо";
            Age = 0;
            BaseSalary = 0;
            BaseIQ = 100;
        }

        public Person(string name, int age, double baseSalary, int baseIQ)
        {
            Name = name;
            Age = age;
            BaseSalary = baseSalary;
            BaseIQ = baseIQ;
        }

        public Person(Person other)
        {
            Name = other.Name;
            Age = other.Age;
            BaseSalary = other.BaseSalary;
            BaseIQ = other.BaseIQ;
        }

        public virtual double CalculatePayment()
        {
            return BaseSalary;
        }

        public virtual int CalculateIQ()
        {
            return BaseIQ;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Ім'я: {Name}, Вік: {Age}, Базова ЗП: {BaseSalary}, IQ: {BaseIQ}");
        }
    }
}