using System;
using System.IO;
using System.Text;

namespace Lab_6
{
    class Program
    {
        static SmartHome myHouse;
        static SmartHomeCar myCar;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            myHouse = new SmartHome();

            // Створення екіпажу (Агрегація)
            Person[] team = new Person[]
            {
                new Person("Дмитро"),
                new Person("Антон"),
                new Person("Олександр Панченко")
            };

            myCar = new SmartHomeCar(350, "Спортивне шасі", team, myHouse);

            // Підписка на події через делегати
            myCar.OnSystemMessage += ShowMessage;
            myCar.OnEmergency += TriggerAutopilot;

            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=============================================");
                Console.WriteLine("            ЛАБОРАТОРНА РОБОТА №6            ");
                Console.WriteLine(" Студент: Дмитро Гангур, Група ІПЗ-12/4, КНУ ");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Нормальний сценарій: Віддалений прогрів авто з дому");
                Console.WriteLine("2. Нормальний сценарій: Наближення авто додому");
                Console.WriteLine("3. Виняток 1: Перегрів двигуна (CarException)");
                Console.WriteLine("4. Виняток 2: Неіснуючий пасажир (IndexOutOfRange)");
                Console.WriteLine("5. Виняток 3: Помилка файлу (Ввід/Вивід)");
                Console.WriteLine("6. Подія: Фізичне виснаження водія (Автопілот + Дім)");
                Console.WriteLine("7. Вихід");
                Console.WriteLine("=============================================");
                Console.Write("Оберіть пункт меню (1-7): ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("--- ЗИМОВИЙ РАНОК ---");
                        myCar.RemoteWinterStart();
                        break;

                    case "2":
                        Console.WriteLine("--- ПОВЕРНЕННЯ ДОДОМУ ---");
                        team[0].IsExhausted = false;
                        myCar.StartJourney();
                        myCar.VoiceControl("Ввімкнути плейлист 'Golden Era Bodybuilding'");
                        myCar.ApproachingHome();
                        break;

                    case "3":
                        Console.WriteLine("--- КОРИСТУВАЦЬКИЙ ВИНЯТОК ---");
                        team[0].IsExhausted = false;
                        myCar.StartJourney();
                        try
                        {
                            Console.WriteLine("\n[Спроба]: Розігнатися до 250 км/год...");
                            myCar.Drive(250);
                        }
                        catch (CarException ex)
                        {
                            Console.WriteLine($"[Відловлено]: {ex.Message}");
                        }
                        finally
                        {
                            Console.WriteLine("[Блок Finally]: Примусове зниження швидкості та охолодження систем.");
                        }
                        break;

                    case "4":
                        Console.WriteLine("--- ОБРОБКА ПОМИЛКИ МАСИВУ ---");
                        try
                        {
                            Console.WriteLine("[Спроба]: Звернення до 5-го пасажира...");
                            myCar.CheckPassenger(5);
                        }
                        catch (IndexOutOfRangeException ex)
                        {
                            Console.WriteLine($"[Відловлено]: {ex.Message}");
                        }
                        break;

                    case "5":
                        Console.WriteLine("--- ОБРОБКА ПОМИЛКИ ФАЙЛУ ---");
                        try
                        {
                            Console.WriteLine("[Спроба]: Зчитування маршруту з диска Z:...");
                            string route = File.ReadAllText("Z:\\non_existent_route.txt");
                        }
                        catch (IOException ex)
                        {
                            Console.WriteLine($"[Відловлено]: Помилка читання файлу. {ex.Message}");
                        }
                        break;

                    case "6":
                        Console.WriteLine("--- РОБОТА ПОДІЙ ТА СИНХРОНІЗАЦІЯ ДОМУ ---");
                        team[0].IsExhausted = true; // Імітуємо втому після залу
                        myCar.StartJourney();
                        break;

                    case "7":
                        exit = true;
                        Console.WriteLine("Роботу успішно завершено!");
                        break;

                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНатисніть Enter для повернення в меню...");
                    Console.ReadLine();
                }
            }
        }

        // Обробник події інформаційного повідомлення
        static void ShowMessage(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO]: {msg}");
            Console.ResetColor();
        }

        // Обробник події екстреної ситуації (Автопілот)
        static void TriggerAutopilot(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[АВТОПІЛОТ]: {msg}");
            Console.Beep(800, 300);
            Console.ResetColor();

            // Синхронізуємо подію з розумним будинком
            myCar.SyncEmergencyWithHome("Водій повертається після виснажливого тренування");
        }
    }
}