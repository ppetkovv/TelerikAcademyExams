﻿using Agency.Commands.Contracts;
using Agency.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Agency.Commands.Creating
{
    class ListVehiclesCommand : ICommand
    {
        private readonly IAgencyFactory factory;
        private readonly IEngine engine;

        public ListVehiclesCommand(IAgencyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var vehicles = this.engine.Vehicles;

            if (vehicles.Count == 0)
            {
                return "There are no registered vehicles.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, vehicles);
        }
    }
}