using System;

namespace Lab_6
{
    public class Engine
    {
        private int power;

        public Engine(int power)
        {
            this.power = power;
        }

        public void Start()
        {
            Console.WriteLine($"[Двигун]: Запущено. Потужність {power} к.с.");
        }

        public void Accelerate(int speed)
        {
            if (speed > 200)
            {
                throw new CarException("Двигун перегрівся від надмірної швидкості!");
            }
            Console.WriteLine($"[Двигун]: Працює стабільно. Швидкість {speed} км/год.");
        }
    }
}