using System;

namespace Lab_6
{
    public class CarException : ApplicationException
    {
        private string messageDetails;

        public CarException()
        {
            messageDetails = "Невідома помилка автомобіля";
        }

        public CarException(string message) : base(message)
        {
            messageDetails = message;
        }

        public override string Message
        {
            get
            {
                return string.Format("КРИТИЧНИЙ ЗБІЙ АВТО: {0}", messageDetails);
            }
        }
    }
}