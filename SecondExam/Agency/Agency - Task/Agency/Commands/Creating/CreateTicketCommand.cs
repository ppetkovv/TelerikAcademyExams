using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using Agency.Models.Contracts;

namespace Traveller.Commands.Creating
{
    class CreateTicketCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public CreateTicketCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            int journeyId;
            IJourney journey;
            decimal administartiveCosts;

            try
            {
                journeyId = int.Parse(parameters[0]);
                journey = this.engine.Journeys[journeyId];
                administartiveCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.factory.CreateTicket(journey, administartiveCosts);
            this.engine.Tickets.Add(ticket);

            return $"Ticket with ID {engine.Tickets.Count - 1} was created.";
        }
    }
}