using Lab5_OOP;
using System;
using System.IO;
using System.Text;

namespace Lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Виправлення проблеми зі знаками питання замість українських літер
            Console.OutputEncoding = Encoding.UTF8;

            string filePath = "Lab5_Output.txt";

            // Очищаємо файл при новому запуску і записуємо заголовок
            File.WriteAllText(filePath, "--- Результати виконання Лабораторної №5 ---\n\n");

            // Ініціалізуємо об'єкти один раз до початку меню, щоб вони зберігали свій стан
            Person worker = new Worker("Іван", 35, 15000, 100, 5);
            Person engineer = new Engineer("Олександр Панченко", 20, 25000, 115, 2);
            Scientist sci1 = new Scientist("Дмитро", 17, 20000, 120, 3);
            Scientist sci2 = new Scientist("Альберт", 50, 30000, 140, 10);

            Laboratory knuLab = new Laboratory(3);
            knuLab[0] = sci1;
            knuLab[1] = sci2;
            knuLab[2] = new Scientist("Марія", 28, 22000, 130, 5);

            bool exit = false;

            while (!exit)
            {
                Console.Clear(); // Очищення консолі перед кожним показом меню
                Console.WriteLine("=============================================");
                Console.WriteLine("            ЛАБОРАТОРНА РОБОТА №5            ");
                Console.WriteLine(" Студент: Дмитро Гангур, Група ІПЗ-12/4, КНУ ");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. Перевірка поліморфізму (ЗП та IQ)");
                Console.WriteLine("2. Перевантаження унарних операторів (++, -)");
                Console.WriteLine("3. Перевантаження бінарних операторів (+, >, <, ==)");
                Console.WriteLine("4. Робота з індексаторами (Масив об'єктів)");
                Console.WriteLine("5. Вихід");
                Console.WriteLine("=============================================");
                Console.Write("Оберіть пункт меню (1-5): ");

                string choice = Console.ReadLine();
                Console.WriteLine(); // Відступ для краси

                switch (choice)
                {
                    case "1":
                        Log("\n--- 1. Поліморфізм (ЗП та IQ) ---", filePath);
                        Person[] people = { worker, engineer, sci1 };
                        foreach (var p in people)
                        {
                            Log($"{p.Name} | IQ: {p.CalculateIQ()} | Фактична ЗП: {p.CalculatePayment()} грн", filePath);
                        }
                        break;

                    case "2":
                        Log("\n--- 2. Унарні оператори ---", filePath);
                        sci1++; // Збільшуємо кількість патентів
                        Log($"Після інкременту (++): {sci1.Name} має {sci1.PatentsDefended} патентів. Нова ЗП: {sci1.CalculatePayment()} грн", filePath);

                        Scientist debtor = new Scientist(sci2); // Робимо копію, щоб не псувати оригінал
                        debtor = -debtor;
                        Log($"Зміна знаку (-): Зарплата {debtor.Name} відображає борг: {debtor.BaseSalary} грн", filePath);
                        break;

                    case "3":
                        Log("\n--- 3. Бінарні оператори ---", filePath);
                        bool isGreater = sci2 > sci1;
                        Log($"Зарплата '{sci2.Name}' більша за зарплату '{sci1.Name}'? {isGreater}", filePath);

                        Scientist combined = sci1 + sci2;
                        Log($"Спільний проект (+): {combined.Name}, Загальна ЗП: {combined.CalculatePayment()} грн, Всього патентів: {combined.PatentsDefended}", filePath);
                        break;

                    case "4":
                        Log("\n--- 4. Індексатори ---", filePath);
                        for (int i = 0; i < knuLab.Length; i++)
                        {
                            Log($"Індекс [{i}]: {knuLab[i].Name}, Патентів: {knuLab[i].PatentsDefended}", filePath);
                        }
                        break;

                    case "5":
                        exit = true;
                        Console.WriteLine("=============================================");
                        Console.WriteLine($"Програма успішно завершена!");
                        Console.WriteLine($"Всі виконані дії збережено у файл: {filePath}");
                        Console.WriteLine("=============================================");
                        break;

                    default:
                        Console.WriteLine("Помилка: Невірний вибір. Спробуйте ще раз.");
                        break;
                }

                if (!exit)
                {
                    Console.WriteLine("\nНатисніть Enter для повернення в меню...");
                    Console.ReadLine();
                }
            }
        }

        // Допоміжний метод: виводить текст у консоль і одразу дописує його у файл
        static void Log(string message, string filePath)
        {
            Console.WriteLine(message);
            File.AppendAllText(filePath, message + "\n");
        }
    }
}