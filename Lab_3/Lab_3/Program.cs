using System;
using System.Text;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Підтримка української мови
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            string filePath = "Lab3_Data.txt";

            // Використання статичного класу
            FileManager.ClearFile(filePath);

            // Створення тестових об'єктів
            Department dept = new Department("Програмної інженерії", 25, 200, "Інженерія програмного забезпечення", 'A');
            Student student = new Student("Олександр", "Панченко", "Інженерія програмного забезпечення", 2);
            Student.ContestWork work = new Student.ContestWork("Hackathon 2026", "AI Assistant System");

            while (true)
            {
                Console.WriteLine("\n=========================================");
                Console.WriteLine("      ЛАБОРАТОРНА РОБОТА №3");
                Console.WriteLine("=========================================");
                Console.WriteLine("1 - Переглянути дані про кафедру");
                Console.WriteLine("2 - Оновити кількість студентів (за акредитацією)");
                Console.WriteLine("3 - Переглянути дані про студента та його рейтинг");
                Console.WriteLine("4 - Переглянути конкурсну роботу студента (Вкладений клас)");
                Console.WriteLine("5 - Записати всі дані у текстовий файл");
                Console.WriteLine("0 - Вихід");
                Console.WriteLine("=========================================");
                Console.Write("Оберіть дію: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        dept.Display();
                        break;
                    case "2":
                        dept.UpdateStudentsByAccreditation();
                        dept.Display();
                        break;
                    case "3":
                        student.Display();
                        break;
                    case "4":
                        work.ShowWork();
                        break;
                    case "5":
                        dept.SaveToFile(filePath);
                        student.SaveToFile(filePath);
                        // Зберігаємо і роботу
                        using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath, true))
                        {
                            sw.WriteLine($"[Конкурсна робота] {work.WorkTitle} ({work.ContestName})");
                        }
                        Console.WriteLine($"Дані успішно записано у файл: {filePath}");
                        break;
                    case "0":
                        Console.WriteLine("Завершення програми...");
                        return;
                    default:
                        Console.WriteLine("Помилка вводу. Спробуйте ще раз.");
                        break;
                }
            }
        }
    }
}