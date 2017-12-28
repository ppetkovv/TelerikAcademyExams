using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Contracts;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Models
{
    class Journey : IJourney
    {
        private string startLocation;
        private string destination;
        private int distance;
        private IVehicle vehicle;

        public Journey(string startLocation, string destination, int distance, IVehicle vehicle)
        {
            this.StartLocation = startLocation;
            this.Destination = destination;
            this.Distance = distance;
            this.Vehicle = vehicle;
        }

        public string StartLocation { get => this.startLocation; private set { if (value.Length < 5 || value.Length > 25) { throw new ArgumentException("The StartingLocation's length cannot be less than 5 or more than 25 symbols long."); } this.startLocation = value; } }
        public string Destination { get => this.destination; private set { if (value.Length < 5 || value.Length > 25) { throw new ArgumentException("The Destination's length cannot be less than 5 or more than 25 symbols long."); } this.destination = value; } }
        public int Distance { get => this.distance; private set { if (value < 5 || value > 5000) { throw new ArgumentException("The Distance cannot be less than 5 or more than 5000 kilometers."); } this.distance = value; } }
        public IVehicle Vehicle { get => this.vehicle; private set { this.vehicle = value; } }

        public decimal CalculateTravelCosts()
        {
            return this.Distance * this.Vehicle.PricePerKilometer;
        }

        public override string ToString()
        {
            StringBuilder journeyOutput = new StringBuilder();
            journeyOutput.AppendLine(string.Format("{0} ----", this.GetType().Name));
            journeyOutput.AppendLine(string.Format("Start location: {0}", this.StartLocation));
            journeyOutput.AppendLine(string.Format("Destination: {0}", this.Destination));
            journeyOutput.AppendLine(string.Format("Vehicle type: {0}", this.Vehicle.Type.ToString()));
            journeyOutput.Append(string.Format("Travel costs: {0}", this.CalculateTravelCosts()));
            return journeyOutput.ToString();
        }
    }
}