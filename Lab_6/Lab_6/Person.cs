namespace Lab_6
{
    public class Person
    {
        public string Name { get; set; }
        public bool IsExhausted { get; set; } // Стан фізичного виснаження

        public Person(string name, bool isExhausted = false)
        {
            Name = name;
            IsExhausted = isExhausted;
        }
    }
}