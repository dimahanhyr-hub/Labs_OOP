namespace Lab5_OOP
{
    public class Engineer : Person
    {
        private int projectsDelivered;

        public Engineer() : base() { projectsDelivered = 0; }

        public Engineer(string name, int age, double baseSalary, int baseIQ, int projects)
            : base(name, age, baseSalary, baseIQ)
        {
            projectsDelivered = projects;
        }

        public Engineer(Engineer other) : base(other)
        {
            projectsDelivered = other.projectsDelivered;
        }

        public override double CalculatePayment()
        {
            return BaseSalary + (projectsDelivered * 5000);
        }

        public override int CalculateIQ()
        {
            return BaseIQ + 15;
        }
    }
}