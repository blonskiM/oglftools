using System;
using System.Collections.Generic;
using System.Text;

namespace OGTools.Shared
{
    public class ShipInfo
    {
        public string ShipName { get; set; }
        public decimal ShipBaseSpeed { get; set; }
        public decimal TechnologiesBonus { get; set; }
        public decimal PlayerClassBonus { get; set; }
        public decimal AllianceClassBonus { get; set; }
        public decimal LifeFormsTechnologyBonus { get; set; }
        public ShipDriveType ShipDriveType { get; set; }
        public decimal ShipFinalSpeed { get; set; }
    }

    public enum ShipDriveType
    {
        CombustionDrive = 0,
        ImpulseDrive = 1,
        HyperspaceDrive = 2
    }
}
