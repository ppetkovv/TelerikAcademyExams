using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    class Airplane : Vehicle, IAirplane
    {
        private bool hasFreeFood;

        public Airplane(int passangerCapacity, decimal pricePerKilometer, bool hasFreeFood) : base(passangerCapacity, pricePerKilometer, Type.Air)
        {
            this.HasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood { get => this.hasFreeFood; private set { this.hasFreeFood = value; } }

        public override string ToString()
        {
            StringBuilder airplaneOuput = new StringBuilder();
            airplaneOuput.Append(base.ToString());
            airplaneOuput.Append(string.Format("\nHas free food: {0}", this.HasFreeFood));
            return airplaneOuput.ToString();
        }
    }
}