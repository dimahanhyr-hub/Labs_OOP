namespace Lab5_OOP
{
    public class Worker : Person
    {
        private int equipmentFixed;

        public Worker() : base() { equipmentFixed = 0; }

        public Worker(string name, int age, double baseSalary, int baseIQ, int eqFixed)
            : base(name, age, baseSalary, baseIQ)
        {
            equipmentFixed = eqFixed;
        }

        public Worker(Worker other) : base(other)
        {
            equipmentFixed = other.equipmentFixed;
        }

        public override double CalculatePayment()
        {
            return BaseSalary + (equipmentFixed * 500);
        }

        public override int CalculateIQ()
        {
            return BaseIQ + 2;
        }
    }
}