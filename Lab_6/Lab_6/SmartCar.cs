using System;

namespace Lab_6
{
    // Оголошення делегата
    public delegate void CarEventHandler(string message);

    public class SmartCar
    {
        // Оголошення подій
        public event CarEventHandler OnEmergency;
        public event CarEventHandler OnSystemMessage;

        protected Engine carEngine;
        protected Chassis carChassis;
        protected SmartSystem carSystem;
        protected Person[] passengers;

        public SmartCar(int enginePower, string chassisType, Person[] people)
        {
            carEngine = new Engine(enginePower);
            carChassis = new Chassis(chassisType);
            carSystem = new SmartSystem();
            passengers = people;
        }

        public void StartJourney()
        {
            OnSystemMessage?.Invoke("Ініціалізація поїздки...");

            if (passengers.Length == 0)
            {
                throw new CarException("Немає водія! Автомобіль не може їхати порожнім.");
            }

            Person driver = passengers[0];

            if (carSystem.AnalyzeDriverCondition(driver))
            {
                // Подія: якщо водій виснажений, керування блокується
                OnEmergency?.Invoke($"УВАГА! Водій {driver.Name} критично виснажений. Ручне керування заблоковано! Перехід на автопілот.");
                return;
            }

            carEngine.Start();
            carChassis.EngageSuspension();
            OnSystemMessage?.Invoke("Усі системи в нормі. Поїздка почалася.");
        }

        public void Drive(int speed)
        {
            carEngine.Accelerate(speed);
        }

        public void VoiceControl(string command)
        {
            carSystem.ExecuteVoiceCommand(command);
        }

        public void CheckPassenger(int index)
        {
            Console.WriteLine($"Перевірка пасажира: {passengers[index].Name}");
        }
    }
}