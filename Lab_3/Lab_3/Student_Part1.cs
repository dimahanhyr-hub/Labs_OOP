using System;

namespace Lab3
{
    // Завдання 8: Частковий клас (частина 1 - дані)
    public partial class Student
    {
        private string firstName;
        private string lastName;
        private string eduProgram;
        private int course;
        private double rating;

        public Student()
        {
            firstName = "";
            lastName = "";
            eduProgram = "";
            course = 1;
            rating = 0.0;
        }

        public Student(string fName, string lName, string program, int c)
        {
            firstName = fName;
            lastName = lName;
            eduProgram = program;
            course = c;

            // Виклик часткового методу для генерації рейтингу
            GenerateRating();
        }

        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string EduProgram { get { return eduProgram; } set { eduProgram = value; } }
        public int Course { get { return course; } set { course = value; } }
        public double Rating { get { return rating; } } // Тільки для читання

        // Оголошення часткового методу
        partial void GenerateRating();

        // Завдання 7: Вкладений (вбудований) клас
        public class ContestWork
        {
            public string ContestName { get; set; }
            public string WorkTitle { get; set; }

            public ContestWork(string contest, string title)
            {
                ContestName = contest;
                WorkTitle = title;
            }

            public void ShowWork()
            {
                Console.WriteLine($"Конкурсна робота: «{WorkTitle}» (Конкурс: {ContestName})");
            }
        }
    }
}