using System;

namespace Lab_6
{
    public class SmartSystem
    {
        public void ExecuteVoiceCommand(string command)
        {
            Console.WriteLine($"[Smart System]: Виконую команду: \"{command}\"");
        }

        public bool AnalyzeDriverCondition(Person driver)
        {
            Console.WriteLine($"[Smart System]: Біометричне сканування водія ({driver.Name})...");
            // Перевіряємо, чи водій виснажений
            return driver.IsExhausted;
        }
    }
}