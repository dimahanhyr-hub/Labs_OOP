using System;
using System.IO;

namespace Lab3
{
    // Завдання 8: Частковий клас (частина 2 - логіка)
    public partial class Student
    {
        // Реалізація часткового методу
        partial void GenerateRating()
        {
            Random rnd = new Random();
            int sum = 0;
            for (int i = 0; i < 10; i++)
            {
                sum += rnd.Next(60, 101); // Оцінки від 60 до 100
            }
            rating = sum / 10.0;
        }

        public void Display()
        {
            Console.WriteLine($"Студент: {firstName} {lastName}, Курс: {course}");
            Console.WriteLine($"Програма: {eduProgram}, Рейтинг: {rating}");
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"[Студент] {firstName} {lastName}, Курс: {course}, Програма: {eduProgram}, Рейтинг: {rating}");
            }
        }
    }
}