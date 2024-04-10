using System;
using APBD_Tut3.Exceptions;
using APBD_Tut3.Interfaces;

namespace APBD_Tut3.Containers
{
    public class GasContainer : Container, IHazardNotifier
    {
        public void NotifyHazard(string containerNumber, string message)
        {
            Console.WriteLine($"Container {containerNumber}: {message}");
        }

        public bool IsHazardousCargo { get; }

        public double Pressure { get; }

        private bool IsHazardous()
        {
            return IsHazardousCargo;
        }

        public override void Load(double cargoWeight)
        {
            if (IsHazardous())
            {
                if (cargoWeight > Capacity * 0.5)
                {
                    NotifyHazard(ContainerNumber, "Attempted to load hazardous cargo beyond 50% capacity");
                    throw new OverfillException();
                }
            }
            else
            {
                if (cargoWeight > Capacity * 0.9)
                {
                    NotifyHazard(ContainerNumber, "Attempted to load non-hazardous cargo beyond 90% capacity");
                    throw new OverfillException();
                }
            }

            base.Load(cargoWeight);
        }

        public override void Unload()
        {
            CargoMass = (int)(CargoMass * 0.05);
        }

        public GasContainer(int cargoMass, int height, int tareWeight, int depth, int capacity, double pressure, bool isHazardousCargo)
            : base(cargoMass, height, tareWeight, depth, capacity)
        {
            Pressure = pressure;
            IsHazardousCargo = isHazardousCargo;
        }
    }
}
