using System;
using System.Collections;

namespace Lab_4
{
    // Інтерфейс для завдання 7
    public interface IHumanAction
    {
        void Work();
        void Display();
    }

    // Компаратор для завдання 9 (сортування за зарплатою)
    public class SalaryComparer : IComparer
    {
        public int Compare(object? x, object? y)
        {
            Worker? w1 = x as Worker;
            Worker? w2 = y as Worker;

            if (w1 != null && w2 != null)
                return w1.Salary.CompareTo(w2.Salary);

            return 0;
        }
    }

    // Клас-колекція для завдання 9 (IEnumerable)
    public class WorkerTeam : IEnumerable
    {
        private Worker[] workers;

        public WorkerTeam(Worker[] workerArray)
        {
            workers = workerArray;
        }

        public IEnumerator GetEnumerator()
        {
            return workers.GetEnumerator();
        }
    }
}