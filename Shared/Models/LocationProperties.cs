using System;
using System.Collections.Generic;
using System.Text;

namespace OGTools.Shared.Models
{
    public class LocationProperties
    {
        public int StartingGalaxy { get; set; }
        public int StartingSystem { get; set; }
        public int StartingPosition { get; set; }
        public int TargetGalaxy { get; set; }
        public int TargetSystem { get; set; }
        public int TargetPosition { get; set; }
    }
}
