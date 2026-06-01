using System;

namespace Lab_6
{
    public class Chassis
    {
        public string Type { get; set; }

        public Chassis(string type)
        {
            Type = type;
        }

        public void EngageSuspension()
        {
            Console.WriteLine($"[Шасі]: Адаптивна підвіска типу '{Type}' активована.");
        }
    }
}