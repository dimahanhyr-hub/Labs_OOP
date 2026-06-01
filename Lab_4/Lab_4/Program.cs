using System;
using System.IO;
using System.Text;

namespace Lab_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Вмикаємо підтримку української мови в консолі
            Console.OutputEncoding = Encoding.UTF8;
            string filePath = "Lab4_Results.txt";

            while (true)
            {
                // Виводимо меню
                Console.WriteLine("\n=========================================");
                Console.WriteLine("      ЛАБОРАТОРНА РОБОТА №4");
                Console.WriteLine("=========================================");
                Console.WriteLine("Оберіть завдання для перевірки:");
                Console.WriteLine("1 - Завдання 1-6 (Базове спадкування та методи)");
                Console.WriteLine("2 - Завдання 7 (Виклик через інтерфейс)");
                Console.WriteLine("3 - Завдання 8 (Абстрактний клас)");
                Console.WriteLine("4 - Завдання 9 (Стандартні інтерфейси)");
                Console.WriteLine("0 - Вихід з програми");
                Console.WriteLine("=========================================");
                Console.Write("Ваш вибір: ");

                // Зчитуємо вибір користувача
                string choice = Console.ReadLine();
                Console.WriteLine(); // Пустий рядок для краси

                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("--- 1. Завдання 1-6 (Базове спадкування та методи) ---");
                            Worker worker = new Worker("Олег", 30, 22000, "Токар");
                            Engineer engineer = new Engineer("Андрій", 27, 35000, "Автоматика");

                            worker.Display();
                            Console.WriteLine(worker.SetupEquipment());

                            Console.WriteLine();

                            engineer.Display();
                            Console.WriteLine(engineer.DesignProject());

                            // Записуємо результати саме цього завдання у файл
                            string fileData = "--- Результати Завдань 1-6 ---\n" +
                                              $"{worker.Name} (Вік: {worker.Age}, Зарплата: {worker.Salary})\n" +
                                              $"{engineer.Name} (Вік: {engineer.Age}, Зарплата: {engineer.Salary})\n";
                            File.WriteAllText(filePath, fileData);
                            Console.WriteLine($"\n[Дані успішно записано у файл: {filePath}]");
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("--- 2. Завдання 7 (Виклик через інтерфейс) ---");
                            Worker worker = new Worker("Олег", 30, 22000, "Токар");

                            IHumanAction action1 = worker;
                            action1.Work();
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine("--- 3. Завдання 8 (Абстрактний клас) ---");
                            AbstractHuman absWorker = new AbstractWorker("Іван");
                            absWorker.PerformDuties();
                            break;
                        }
                    case "4":
                        {
                            Console.WriteLine("--- 4. Завдання 9 (Стандартні інтерфейси) ---");
                            Worker[] team = new Worker[]
                            {
                            new Worker("Максим", 40, 25000, "Слюсар"),
                            new Worker("Денис", 22, 18000, "Зварювальник"),
                            new Worker("Тарас", 35, 30000, "Бригадир")
                            };

                            Array.Sort(team); // Сортування за віком (IComparable)
                            Console.WriteLine("Відсортовано за віком (IComparable):");
                            foreach (var w in team) { Console.WriteLine($"{w.Name} - {w.Age} років"); }

                            Array.Sort(team, new SalaryComparer()); // Сортування за зарплатою (IComparer)
                            Console.WriteLine("\nВідсортовано за зарплатою (IComparer):");

                            string fileData = "--- Результати Завдання 9 ---\n";

                            // Перебір через IEnumerable
                            WorkerTeam workerTeam = new WorkerTeam(team);
                            foreach (Worker w in workerTeam)
                            {
                                Console.WriteLine($"{w.Name} - {w.Salary} грн");
                                fileData += $"{w.Name} (Вік: {w.Age}, Зарплата: {w.Salary})\n";
                            }

                            // Записуємо результати саме цього завдання у файл
                            File.WriteAllText(filePath, fileData);
                            Console.WriteLine($"\n[Дані успішно записано у файл: {filePath}]");
                            break;
                        }
                    case "0":
                        {
                            Console.WriteLine("Вихід з програми. До побачення!");
                            return; // Повністю зупиняє програму
                        }
                    default:
                        {
                            Console.WriteLine("Помилка: Невірний вибір! Введіть цифру від 0 до 4.");
                            break;
                        }
                }
            }
        }
    }
}