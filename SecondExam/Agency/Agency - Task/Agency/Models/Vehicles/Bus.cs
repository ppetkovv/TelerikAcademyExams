using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    class Bus : Vehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer) : base(passangerCapacity, pricePerKilometer, Type.Land)
        {
        }

        public override int PassangerCapacity { get => base.PassangerCapacity; protected set { if (value < 10 || value > 50) { throw new ArgumentException("A bus cannot have less than 10 passengers or more than 50 passengers."); } base.PassangerCapacity = value; } }
    }
}