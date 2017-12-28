using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    public abstract class Vehicle : IVehicle
    {
        private int passangerCapacity;
        private decimal pricePerKilometer;
        private Type type;

        protected Vehicle(int passangerCapacity, decimal pricePerKilometer, Type type)
        {
            this.PassangerCapacity = passangerCapacity;
            this.PricePerKilometer = pricePerKilometer;
            this.Type = type;
        }

        public virtual int PassangerCapacity { get => this.passangerCapacity; protected set { if (value < 1 || value > 800) { throw new ArgumentException("A vehicle with less than 1 passengers or more than 800 passengers cannot exist!"); } this.passangerCapacity = value; } }
        public decimal PricePerKilometer { get => this.pricePerKilometer; private set { if (value < 0.10m || value > 2.50m) { throw new ArgumentException("A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!"); } this.pricePerKilometer = value; } }
        public Type Type { get => this.type; private set { this.type = value; } }

        public override string ToString()
        {
            StringBuilder vehicleOutput = new StringBuilder();
            vehicleOutput.AppendLine(string.Format("{0} ----", this.GetType().Name));
            vehicleOutput.AppendLine(string.Format("Passenger capacity: {0}", this.PassangerCapacity));
            vehicleOutput.AppendLine(string.Format("Price per kilometer: {0}", this.PricePerKilometer));
            vehicleOutput.Append(string.Format("Vehicle type: {0}", this.Type.ToString()));
            return vehicleOutput.ToString();
        }
    }
}