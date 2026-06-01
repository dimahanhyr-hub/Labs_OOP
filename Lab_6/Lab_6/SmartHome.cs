using System;

namespace Lab_6
{
    public class SmartHome
    {
        public void PrepareForArrival()
        {
            Console.WriteLine("[Розумний Дім]: Отримано сигнал від авто. Гараж відкрито, опалення та світло увімкнено. Чекаємо на господарів.");
        }

        public void ActivateRecoveryProtocol(string reason)
        {
            Console.WriteLine($"[Розумний Дім]: Отримано статус від автопілота: {reason}.");
            Console.WriteLine("[Розумний Дім]: Активовано протокол відновлення. Готується порція соєвого протеїнового ізоляту та набирається тепла ванна.");
        }
    }
}