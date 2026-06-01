using System;

namespace Lab_4
{
    // Завдання 8: Абстрактний базовий клас
    public abstract class AbstractHuman
    {
        public string Name { get; set; }

        public AbstractHuman(string name)
        {
            Name = name;
        }

        public abstract void PerformDuties();
    }

    public class AbstractWorker : AbstractHuman
    {
        public AbstractWorker(string name) : base(name) { }

        public override void PerformDuties()
        {
            Console.WriteLine($"{Name} виконує роботу на заводі (Реалізація абстрактного класу).");
        }
    }
}