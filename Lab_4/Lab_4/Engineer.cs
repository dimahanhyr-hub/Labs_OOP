using System;

namespace Lab_4
{
    public class Engineer : Human
    {
        private string currentProject;

        public string CurrentProject { get { return currentProject; } set { currentProject = value; } }

        public Engineer(string name, int age, decimal salary, string project)
            : base(name, age, salary)
        {
            CurrentProject = project;
        }

        public string DesignProject()
        {
            return $"Інженер {Name} розробляє проєкт: {CurrentProject}";
        }

        public override void Work()
        {
            Console.WriteLine($"Інженер {Name} робить креслення.");
        }

        public override void Display()
        {
            base.Display();
            Console.WriteLine($"Проєкт: {CurrentProject} (Посада: Інженер)");
        }
    }
}