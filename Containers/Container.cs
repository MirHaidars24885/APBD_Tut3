using System;
using APBD_Tut3.Exceptions;
using APBD_Tut3.Interfaces;

namespace APBD_Tut3
{
    public class Container : IContainer
    {
        public string ContainerNumber { get; }
        
        public int CargoMass { get; set; }
        public int Height { get; set; }
        public int TareWeight { get; set; }
        public int Depth { get; set; }
        public int Capacity { get; set; }

        public Container(int cargoMass, int height, int tareWeight, int depth, int capacity)
        {
            CargoMass = cargoMass;
            Height = height;
            TareWeight = tareWeight;
            Depth = depth;
            Capacity = capacity;

            // Generating a unique ID for the container
            ContainerNumber = GenerateContainerNumber();
        }

        // Generating a unique container number (you can customize this as needed)
        private string GenerateContainerNumber()
        {
            return Guid.NewGuid().ToString();
        }

        public virtual void Unload()
        {
            throw new NotImplementedException();
        }

        public virtual void Load(double cargoWeight)
        {
            if (CargoMass + cargoWeight >= Capacity)
            {
                throw new OverfillException();
            }
            else { CargoMass = (int)(CargoMass + cargoWeight); }
        }
    }
}