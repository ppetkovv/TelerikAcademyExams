using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Models.Contracts;

namespace Agency.Models
{
    class Ticket : ITicket
    {
        private IJourney journey;
        private decimal administrativeCosts;

        public Ticket(IJourney journey, decimal administartiveCosts)
        {
            this.Journey = journey;
            this.AdministrativeCosts = administartiveCosts;
        }

        public IJourney Journey { get => this.journey; private set { this.journey = value; } }
        public decimal AdministrativeCosts { get => this.administrativeCosts; private set { this.administrativeCosts = value; } }
        public decimal CalculatePrice()
        {
            return this.AdministrativeCosts + (this.journey.CalculateTravelCosts());
        }

        public override string ToString()
        {
            StringBuilder ticketOutput = new StringBuilder();
            ticketOutput.AppendLine(string.Format("{0} ----", this.GetType().Name));
            ticketOutput.AppendLine(string.Format("Destination: {0}", this.Journey.Destination));
            ticketOutput.Append(string.Format("Price: {0}", this.CalculatePrice()));
            return ticketOutput.ToString();
        }
    }
}