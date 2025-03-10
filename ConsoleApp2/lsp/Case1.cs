using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.lsp
{
    internal class Case1
    {
        private class Vehicle
        {
            public string LicensePlate { get; set; }
            public double FuelLevel { get; set; }
            public double FuelCapacity { get; set; }

            public virtual void StartEngine()
            {
                Console.WriteLine("Engine started for vehicle " + LicensePlate);
            }

            public virtual void StopEngine()
            {
                Console.WriteLine("Engine stopped for vehicle " + LicensePlate);
            }

            public virtual void Refuel(double amount)
            {
                FuelLevel += amount;
                Console.WriteLine("Refueled " + amount + " liters for vehicle " + LicensePlate);
            }

            public virtual double GetFuelLevel()
            {
                return FuelLevel;
            }

            public virtual void Drive(double distance)
            {
                FuelLevel -= distance * 0.1;
                System.Console.WriteLine("Vehicle " + LicensePlate + " drove " + distance + " km");
            }
        }

        private class ElectricVehicle : Vehicle
        {
            public double BatteryLevel { get; set; }
            public double BatteryCapacity { get; set; }

            public override void Refuel(double amount)
            {
                throw new NotSupportedException("Electric vehicles cannot be refueled with fuel");
            }

            public override void StartEngine()
            {
                Console.WriteLine("Electric vehicle " + LicensePlate + " started silently");
            }
            public override void Drive(double distance)
            {
                BatteryLevel -= distance * 0.2;
                Console.WriteLine("Electric vehicle " + LicensePlate + " drove " + distance + " km");
            }

            public void Charge(double amount)
            {
                BatteryLevel += amount;
                Console.WriteLine("Charged " + amount + " kWh for electric vehicle " + LicensePlate);
            }

            public void GetBatteryInfo()
            {
                Console.WriteLine("Battery level: " + BatteryLevel + "/" + BatteryCapacity);
            }
        }
    }
}
