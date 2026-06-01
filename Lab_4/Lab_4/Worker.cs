using System;

namespace Lab_4
{
    public class Worker : Human, IComparable
    {
        private string technicalSkills;

        public string TechnicalSkills { get { return technicalSkills; } set { technicalSkills = value; } }

        public Worker(string name, int age, decimal salary, string skills)
            : base(name, age, salary)
        {
            TechnicalSkills = skills;
        }

        public string SetupEquipment()
        {
            return $"Робітник {Name} налаштовує обладнання. Навички: {TechnicalSkills}";
        }

        public override void Work()
        {
            Console.WriteLine($"Робітник {Name} працює на виробництві.");
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Навички: {TechnicalSkills} (Посада: Робітник)");
        }

        // Реалізація IComparable для сортування за віком
        public int CompareTo(object obj)
        {
            if (obj is Worker otherWorker)
            {
                return this.Age.CompareTo(otherWorker.Age);
            }
            return 0;
        }
    }
}