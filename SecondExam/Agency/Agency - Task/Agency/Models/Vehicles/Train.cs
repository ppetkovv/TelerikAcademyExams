using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models.Vehicles
{
    class Train : Vehicle, ITrain
    {
        private int carts;

        public Train(int passangerCapacity, decimal pricePerKilometer, int carts) : base(passangerCapacity, pricePerKilometer, Type.Land)
        {
            this.Carts = carts;
        }

        public override int PassangerCapacity { get => base.PassangerCapacity; protected set { if (value < 30 || value > 150) { throw new ArgumentException("A train cannot have less than 30 passengers or more than 150 passengers."); } base.PassangerCapacity = value; } }

        public int Carts { get => this.carts; private set { if (value < 1 || value > 15) { throw new ArgumentException("A train cannot have less than 1 cart or more than 15 carts."); } this.carts = value; } }

        public override string ToString()
        {
            StringBuilder trainOuput = new StringBuilder();
            trainOuput.Append(base.ToString());
            trainOuput.Append(string.Format("\nCarts amount: {0}", this.Carts));
            return trainOuput.ToString();
        }
    }
}