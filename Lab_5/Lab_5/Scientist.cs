using System;

namespace Lab5_OOP
{
    public class Scientist : Person
    {
        private int patentsDefended;

        public int PatentsDefended
        {
            get { return patentsDefended; }
            set { patentsDefended = value; }
        }

        public Scientist() : base() { patentsDefended = 0; }

        public Scientist(string name, int age, double baseSalary, int baseIQ, int patents)
            : base(name, age, baseSalary, baseIQ)
        {
            patentsDefended = patents;
        }

        public Scientist(Scientist other) : base(other)
        {
            patentsDefended = other.patentsDefended;
        }

        public override double CalculatePayment()
        {
            return BaseSalary + (patentsDefended * 15000);
        }

        public override int CalculateIQ()
        {
            return BaseIQ + 30;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Науковець: {Name}, IQ: {CalculateIQ()}, ЗП: {CalculatePayment()} грн, Патентів: {patentsDefended}");
        }

        // Бінарні оператори
        public static Scientist operator +(Scientist s1, Scientist s2)
        {
            return new Scientist(s1.Name + " & " + s2.Name, Math.Max(s1.Age, s2.Age),
                                 s1.BaseSalary + s2.BaseSalary, Math.Max(s1.BaseIQ, s2.BaseIQ),
                                 s1.patentsDefended + s2.patentsDefended);
        }

        public static Scientist operator -(Scientist s1, Scientist s2)
        {
            return new Scientist("Різниця", 0, Math.Abs(s1.BaseSalary - s2.BaseSalary), 0, Math.Abs(s1.patentsDefended - s2.patentsDefended));
        }

        public static bool operator >(Scientist s1, Scientist s2) => s1.CalculatePayment() > s2.CalculatePayment();
        public static bool operator <(Scientist s1, Scientist s2) => s1.CalculatePayment() < s2.CalculatePayment();

        public static bool operator ==(Scientist s1, Scientist s2) => s1.CalculatePayment() == s2.CalculatePayment();
        public static bool operator !=(Scientist s1, Scientist s2) => !(s1 == s2);

        public override bool Equals(object obj)
        {
            if (obj is Scientist s) return this == s;
            return false;
        }

        public override int GetHashCode() => CalculatePayment().GetHashCode();

        // Унарні оператори
        public static Scientist operator ++(Scientist s)
        {
            s.patentsDefended++;
            return s;
        }

        public static Scientist operator --(Scientist s)
        {
            if (s.patentsDefended > 0) s.patentsDefended--;
            return s;
        }

        public static Scientist operator -(Scientist s)
        {
            s.BaseSalary = -s.BaseSalary;
            return s;
        }
    }
}