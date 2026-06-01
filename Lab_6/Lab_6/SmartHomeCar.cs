using System;

namespace Lab_6
{
    public class SmartHomeCar : SmartCar
    {
        private SmartHome linkedHome;

        public SmartHomeCar(int enginePower, string chassisType, Person[] people, SmartHome home)
            : base(enginePower, chassisType, people)
        {
            linkedHome = home;
        }

        public void RemoteWinterStart()
        {
            Console.WriteLine("[Віддалений доступ]: Активація зимового режиму з дому...");
            carEngine.Start();
            Console.WriteLine("[Smart System]: Клімат-контроль встановлено на 22°C. Підігрів сидінь та розморожування вікон увімкнено.");
        }

        public void ApproachingHome()
        {
            Console.WriteLine("[Smart System]: Геолокація фіксує наближення до дому (менше 1 км).");
            linkedHome.PrepareForArrival();
        }

        public void SyncEmergencyWithHome(string emergencyReason)
        {
            linkedHome.ActivateRecoveryProtocol(emergencyReason);
        }
    }
}