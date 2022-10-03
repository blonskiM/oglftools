using System;
using System.Collections.Generic;
using System.Text;

namespace OGTools.Shared
{
    public class FleetFlightTime
    {
        // basic location information
        public int StartingGalaxy { get; set; }
        public int StartingSystem { get; set; }
        public int StartingPosition { get; set; }
        public int TargetGalaxy { get; set; }
        public int TargetSystem { get; set; }
        public int TargetPosition { get; set; }

        // classes
        public PlayerClass PlayerClass { get; set; }
        public AllianceClass AllianceClass { get; set; }

        // techs
        public int CombustionDriveLevel { get; set; }
        public int ImpulseDriveLevel { get; set; }
        public int HyperspaceDriveLevel { get; set; }
        public int HyperspaceTechnology { get; set; }

        // uni props
        public bool IsDonutSystem { get; set; }
        public bool IsDonutGalaxy { get; set; }
        public int NumberOfSystems { get; set; }
        public int NumberOfGalaxies { get; set; }
    }

    public enum PlayerClass
    {
        General = 1,
        Collector = 2,
        Discoverer = 3
    }

    public enum AllianceClass
    {
        Warriors = 1,
        Traders = 2
    }
}
