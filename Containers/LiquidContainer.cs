using System;
using APBD_Tut3.Exceptions;
using APBD_Tut3.Interfaces;

namespace APBD_Tut3.Containers
{
    public class LiquidContainer : Container, IHazardNotifier
    {
        // Implementing the IHazardNotifier interface
        public void NotifyHazard(string containerNumber, string message)
        {
            Console.WriteLine($"Container {containerNumber}: {message}");
        }

        // Property to indicate whether the cargo is hazardous
        public bool IsHazardousCargo { get; }

        // Method to determine if the cargo is hazardous
        private bool IsHazardous()
        {
            return IsHazardousCargo;
        }

        public override void Load(double cargoWeight)
        {
            // Checking if the cargo is hazardous
            if (IsHazardous())
            {
                // Hazardous cargo can only be filled to 50% of capacity
                if (cargoWeight > Capacity * 0.5)
                {
                    NotifyHazard(ContainerNumber, "Attempted to load hazardous cargo beyond 50% capacity");
                    throw new OverfillException();
                }
            }
            else
            {
                // Non-hazardous cargo can be filled up to 90% of capacity
                if (cargoWeight > Capacity * 0.9)
                {
                    NotifyHazard(ContainerNumber, "Attempted to load non-hazardous cargo beyond 90% capacity");
                    throw new OverfillException();
                }
            }

            // Proceed with loading if no overfill exception is thrown
            this.Load(cargoWeight);
        }

        public LiquidContainer(int cargoMass, int height, int tareWeight, int depth, int capacity, bool isHazardousCargo)
            : base(cargoMass, height, tareWeight, depth, capacity)
        {
            IsHazardousCargo = isHazardousCargo;
        }
    }
}