using System;
using System.Collections.Generic;
using System.Text;
using OGTools.Shared.Enums;
using OGTools.Shared.Models;

namespace OGTools.Shared
{
    public class FleetFlightTime
    {
        public LocationProperties LocationProperties { get; set; }

        public PlayerClass PlayerClass { get; set; }
        public PlayerAllianceClass AllianceClass { get; set; }

        public PlayerTechnologies PlayerTechnologies { get; set; }

        public UniversumProperties UniversumProperties { get; set; }
    }
}
