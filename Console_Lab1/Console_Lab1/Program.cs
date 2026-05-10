
using System;
using System.Text;

namespace Console_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Налаштування кодування UTF-8, щоб українські літери коректно відображалися в консолі
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // Безкінечний цикл для роботи меню, щоб програма не закривалася після одного завдання
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Лабораторна робота №1. Варіант 17");
                Console.WriteLine("Виконав: Гангур Дмитро, група ІПЗ-12");
                Console.WriteLine("\nМеню завдань:");
                Console.WriteLine("1. Анкетні дані та розрахунок швидкості");
                Console.WriteLine("2. Обчислення математичного виразу");
                Console.WriteLine("3. Обчислення розгалуженої функції");
                Console.WriteLine("4. Назва пальця (switch)");
                Console.WriteLine("5. Сума ряду");
                Console.WriteLine("0. Вихід");
                Console.Write("\nВаш вибір: ");

                // Зчитуємо вибір користувача
                string key = Console.ReadLine();

                // Викликаємо потрібний метод залежно від того, що ввів користувач
                switch (key)
                {
                    case "1":
                        Task1();
                        break;
                    case "2":
                        Task2();
                        break;
                    case "3":
                        Task3();
                        break;
                    case "4":
                        Task4();
                        break;
                    case "5":
                        Task5();
                        break;
                    case "0":
                        return; // Вихід з програми
                    default:
                        Console.WriteLine("Невірний вибір.");
                        break;
                }
                Console.WriteLine("\nНатисніть будь-яку клавішу...");
                Console.ReadKey();
            }
        }

        // --- ЗАВДАННЯ 1 ---
        static void Task1()
        {
            Console.WriteLine("\n--- Завдання 1 ---");
            // Просте виведення анкетних даних
            Console.WriteLine("Прізвище: Гангур");
            Console.WriteLine("Ім'я: Дмитро");
            Console.WriteLine("Вік: 17");
            Console.WriteLine("Група: ІПЗ-12");
            Console.WriteLine("Курс: 1");
            Console.WriteLine("E-mail: dmytro.hanhyr@knu.ua");

            Console.WriteLine("\nРозрахунок швидкості (v):");
            Console.Write("Введіть висоту n (м): ");
            // Перетворюємо введений рядок у дробове число
            double n = Convert.ToDouble(Console.ReadLine());

            // Розрахунок швидкості вільного падіння за формулою v = sqrt(2 * g * n), де g = 9.81
            double v = Math.Sqrt(2 * 9.81 * n);

            // Виводимо результат, обмеживши до двох знаків після коми (F2)
            Console.WriteLine($"Швидкість входження у воду: {v:F2} м/с");
        }

        // --- ЗАВДАННЯ 2 ---
        static void Task2()
        {
            Console.WriteLine("\n--- Завдання 2 ---");
            Console.Write("Введіть a: ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введіть b: ");
            double b = Convert.ToDouble(Console.ReadLine());

            // Щоб не заплутатися в дужках, розбиваємо складний вираз на дві частини
            // part1: Модуль (Abs) від a - 1/b^2
            double part1 = Math.Abs(a - (1 / (b * b)));
            // part2: Косинус(a) ділений на натуральний логарифм (Log) від тангенса(b)
            double part2 = Math.Cos(a) / Math.Log(Math.Tan(b));

            // Додаємо обидві частини
            double x = part1 + part2;

            Console.WriteLine($"Результат x = {x:F4}");
        }

        // --- ЗАВДАННЯ 3 ---
        static void Task3()
        {
            Console.WriteLine("\n--- Завдання 3 ---");
            Console.Write("Введіть x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            double f;

            // Перевіряємо, в який діапазон потрапляє x, і за відповідною формулою рахуємо f
            if (x > 0 && x < 4)
            {
                f = 4 - (x * x);
            }
            else if (x == 0)
            {
                f = 0;
            }
            else if (x < 0)
            {
                f = Math.Pow(x, 3); // x в кубі
            }
            else
            {
                f = 1; // Для x > 4
            }

            Console.WriteLine($"f({x}) = {f}");
        }

        // --- ЗАВДАННЯ 4 ---
        static void Task4()
        {
            Console.WriteLine("\n--- Завдання 4 ---");
            Console.Write("Введіть номер пальця (1-5): ");
            int finger = Convert.ToInt32(Console.ReadLine());

            // Використовуємо switch для простого вибору рядка за числом
            switch (finger)
            {
                case 1: Console.WriteLine("Великий"); break;
                case 2: Console.WriteLine("Вказівний"); break;
                case 3: Console.WriteLine("Середній"); break;
                case 4: Console.WriteLine("Безіменний"); break;
                case 5: Console.WriteLine("Мізинець"); break;
                default: Console.WriteLine("Помилка: введіть число від 1 до 5"); break;
            }
        }

        // --- ЗАВДАННЯ 5 ---
        static void Task5()
        {
            Console.WriteLine("\n--- Завдання 5 ---");
            Console.Write("Введіть n (натуральне число): ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть x (x > 0): ");
            double x = Convert.ToDouble(Console.ReadLine());

            // Змінна для накопичення загальної суми ряду
            double sum = 0;

            // Цикл від 1 до n включно
            for (int i = 1; i <= n; i++)
            {
                // Рахуємо чисельник: (-1)^i * корінь((x+1)^i)
                double numerator = Math.Pow(-1, i) * Math.Sqrt(Math.Pow(x + 1, i));

                // Рахуємо знаменник: i^x - x^i
                double denominator = Math.Pow(i, x) - Math.Pow(x, i);

                // Обов'язкова перевірка, щоб уникнути ділення на нуль і "вильоту" програми
                if (denominator != 0)
                {
                    sum += numerator / denominator;
                }
                else
                {
                    Console.WriteLine($"При i={i} знаменник дорівнює 0, пропускаємо.");
                }
            }

            Console.WriteLine($"Сума S = {sum:F4}");
        }
    }
}