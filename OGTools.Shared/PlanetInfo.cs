using System;

namespace OGTools.Shared
{
    public class PlanetInfo
    {
        // mines
        public int MetalMineLevel { get; set; }
        public int CrystalMineLevel { get; set; }
        public int DeuteriumMineLevel { get; set; }

        // planet props
        public int PlanetMaxTemp { get; set; }
        public int PlanetPosition { get; set; }

        // energy
        public int FusionReactorLevel { get; set; }

        // TODO: add crawlers
        // TODO: add boosters (10%, 20%, 30%, 40%)
    }
}