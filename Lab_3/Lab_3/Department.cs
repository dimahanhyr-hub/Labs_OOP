using System;
using System.IO;

namespace Lab3
{
    public class Department
    {
        // Закриті поля
        private string name;
        private int teachersCount;
        private int studentsCount;
        private string eduProgram;
        private char accreditation; // 'A', 'B', 'E'

        // Конструктор за замовчуванням
        public Department()
        {
            name = "";
            teachersCount = 0;
            studentsCount = 0;
            eduProgram = "";
            accreditation = 'B';
        }

        // Конструктор з параметрами
        public Department(string name, int teachers, int students, string program, char acc)
        {
            this.name = name;
            this.teachersCount = teachers;
            this.studentsCount = students;
            this.eduProgram = program;
            this.accreditation = acc;
        }

        // Властивості
        public string Name { get { return name; } set { name = value; } }
        public int TeachersCount { get { return teachersCount; } set { teachersCount = value; } }
        public int StudentsCount { get { return studentsCount; } set { studentsCount = value; } }
        public string EduProgram { get { return eduProgram; } set { eduProgram = value; } }
        public char Accreditation { get { return accreditation; } set { accreditation = value; } }

        // Метод зміни кількості студентів (за умовою задачі)
        public void UpdateStudentsByAccreditation()
        {
            if (accreditation == 'A')
            {
                studentsCount = (int)(studentsCount * 1.20); // +20%
                Console.WriteLine("Акредитація 'A': кількість студентів збільшено на 20%.");
            }
            else if (accreditation == 'E')
            {
                studentsCount = (int)(studentsCount * 0.90); // -10%
                Console.WriteLine("Акредитація 'E': кількість студентів зменшено на 10%.");
            }
            else
            {
                Console.WriteLine("Акредитація 'B': кількість студентів не змінилася.");
            }
        }

        public void Display()
        {
            Console.WriteLine($"Кафедра: {name}, Програма: {eduProgram}");
            Console.WriteLine($"Викладачів: {teachersCount}, Студентів: {studentsCount}, Акредитація: {accreditation}");
        }

        public void SaveToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"[Кафедра] Назва: {name}, Програма: {eduProgram}, Викладачів: {teachersCount}, Студентів: {studentsCount}, Акредитація: {accreditation}");
            }
        }
    }
}